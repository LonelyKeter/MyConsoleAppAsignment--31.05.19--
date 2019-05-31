using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using ExcelDataReader;
using MyConsoleAppAsignment;

namespace Test
{
	class Test
	{
		static void Main(string[] args)
		{
			var reader = EDRReader.Factory.GetEDRReader(LocalDataSet.Factory.GetLocalDataSet());
			Console.WriteLine(reader.Read("Книга.xlsx"));

			var result = (DataSet)reader.Set;

			Console.WriteLine(result.DataSetName);
			foreach (DataTable a in result.Tables)
			{
				Console.WriteLine(a.TableName);
				foreach (DataColumn c in a.Columns) Console.Write($"|{c,10}|");
				Console.WriteLine();
				foreach (DataRow r in a.Rows)
				{
					foreach (object i in r.ItemArray) Console.Write($"|{i,10}|");
					Console.WriteLine();
				}
			}
		}
	}
}
