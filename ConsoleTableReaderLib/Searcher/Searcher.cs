using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyConsoleAppAsignment
{
	public static class Searcher
	{
		public static SearchResult Search(string[] keys, LocalDataSet Set)
		{
			var data = (DataSet)Set;
			return Search(keys, data);
		}		
		private static SearchResult Search(string[] keys, DataSet Set)
		{
			SearchResult result = new SearchResult(Set.Tables.Count, keys);

			for (int t = 0; t < Set.Tables.Count; t++)
			{
				DataTable table = Set.Tables[t];

				DataRowCollection rows = table.Rows;

				StringBuilder columnName = new StringBuilder((char)64);

				for (int i = 0; i < table.Columns.Count; i++)
				{
					IncreaseColumnname(columnName, columnName.Length - 1);

					for (int j = 0; j < rows.Count; j++)
					{
						int keyindex;
						string currentCell = rows[j][i].ToString();

						if (Compare(result.Keys, currentCell, out keyindex))
						{
							result[keyindex].CellNames[t].Enqueue(columnName.ToString() + (j + 1));
							result[keyindex].Counts[t]++;
						}
					}
				}				
			}		

			for (int i = 0; i < result.Count; i++)
			{
				for (int t = 0; t < result.TableCount; t++)
				{
					if (result[i].Counts[t] > 0) result[i].SheetNames[t] = Set.Tables[t].TableName;
				}
			}

			return result;		
		}

		public static string[] GetKeys(string[] args)
		{
			int offset = args[0][0] == '-' ? 1 : 0;

			string[] result = new string[args.Length - offset - 1];

			for (int i = 0; i < result.Length; i++) result[i] = args[i + offset];

			return result;
		}

		private static bool Compare(string[] keys, string value, out int keyindex)
		{
			keyindex = 0;

			if (value == null) return false;

			for (	; keyindex < keys.Length; keyindex++)
			{
				if (keys[keyindex] == value) return true;
			}

			return false;
		}
		private static void IncreaseColumnname(StringBuilder name, int index)
		{
			if (index == -1)
			{
				name.Insert(0, 'A');
				return;
			}

			if (name[index] != 'Z')	name[index] = (char)(name[index] + 1);
			else
			{
				name[index] = 'A';
				IncreaseColumnname(name, --index);
			}
		}
	}
}
