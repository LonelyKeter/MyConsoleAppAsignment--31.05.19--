using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExcelDataReader;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// Reads a file using ExcelDataReader library
	/// </summary>
	public class EDRReader : IReader
	{
		public LocalDataSet Set { get; internal set; }
		
		public ReaderState State { get; protected set; }

		public bool Read(string filepath)
		{
			if (ContainsFlag(State.Options, ReadOptions.RestrictFileType)) return RestrictedRead(filepath);
			else return UnrestrictedRead(filepath);
		}

		/// <summary>
		/// Reads only those files, that have supported extension (*.txt files are also interpreted as CSV files)
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns>True, if file was succesgully read, otherwise False</returns>
		private bool RestrictedRead(string filepath)
		{
			string ext = filepath.Substring(filepath.LastIndexOf('.'));

			if (ext == ".xls" || ext == ".xlsx")
			{
				using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
				{					
					using (var reader = ExcelReaderFactory.CreateReader(stream))
					{
						do
						{
							while (reader.Read()) { }
						}
						while (reader.NextResult());
						
						this.Set.Set = reader.AsDataSet(Config);
					}
				}
				return true;
			}

			if (ext == ".csv" || ext == ".txt")
			{
				using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
				{
					using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
					{
						do
						{
							while (reader.Read()) { }
						}
						while (reader.NextResult());

						this.Set.Set = reader.AsDataSet();
					}
				}
				return true;
			}

			return false;
		}

		/// <summary>
		/// <para>Tries to read file regardless of its type</para>
		/// <para>First, as xml\xmls file </para>
		/// <para>Then, as CSV file (can lead to an unpredictible result)</para>
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns></returns>
		private bool UnrestrictedRead(string filepath)
		{
			using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
			{
				try
				{
					using (var reader = ExcelReaderFactory.CreateReader(stream))
					{
						do
						{
							while (reader.Read()) { }
						}						
						while (reader.NextResult());

						this.Set.Set = reader.AsDataSet();
					}

					return true;
				}
				catch { }

				using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
				{
					do
					{
						while (reader.Read()) { }
					}
					while (reader.NextResult());

					this.Set.Set = reader.AsDataSet();
				}

				return true;
			}
		}

		static bool ContainsFlag(ReadOptions obj, ReadOptions prototype)
		{
			return ((obj & prototype) > 0);
		}

		static ExcelDataSetConfiguration Config = new ExcelDataSetConfiguration()
		{
			UseColumnDataType = false,
			FilterSheet = (tableReader, sheetIndex) => true,
			ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
			{
				EmptyColumnNamePrefix = "",
				UseHeaderRow = false,
				ReadHeaderRow = (rowReader) =>{	},

				FilterRow = (rowReader) =>
				{
					return true;
				},
				FilterColumn = (rowReader, columnIndex) =>
				{
					return true;
				}
			}
		};

		public static class Factory
		{
			/// <summary>
			/// Creates custom instance of EDRReader coresponding to passed <paramref name="state"/> struct and bindes <paramref name="set"/> to created instance 
			/// </summary>
			/// <param name="State">ReaderState struct containing needed state</param>
			/// <param name="set"></param>
			/// <returns>New instance of an EDRReader</returns>
			public static EDRReader GetEDRReader(ReaderState state, LocalDataSet set)
			{
				return new EDRReader { State = state, Set = set };
			}

			/// <summary>
			/// Creates default instance of EDRReader coresponding to passed <paramref name="state"/> struct and bindes <paramref name="set"/> to created instance 
			/// </summary>
			/// <param name="set">ReaderState struct containing needed state</param>
			/// <returns>New default instance of an EDRReader</returns>
			public static EDRReader GetEDRReader(LocalDataSet set)
			{
				return GetEDRReader(ReaderState.Default, set);
			}
		}
	}
}
