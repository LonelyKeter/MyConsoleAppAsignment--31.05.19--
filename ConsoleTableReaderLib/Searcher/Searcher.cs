//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;

//namespace MyConsoleAppAsignment
//{
//	public class Searcher
//	{
//		public SearcherState State { get; protected set; }

//		string Search(string[] keys, LocalDataSet Set, ActionFlags Flags)
//		{
//			var data = (DataSet)Set;
//			return Search(keys, data, Flags);
//		}
//		string Search(string[] keys, DataSet Set, ActionFlags Flags)
//		{
//			if (ContainsFlag(Flags, ActionFlags.Accurate)) return AccurateSearh(keys, Set, Flags);

//			StringBuilder result = new StringBuilder();

//			Action<StringBuilder, string> AddSheetName;
//			Action<StringBuilder, int, int> AddCellName;
//			Action<StringBuilder, int> AddCount;

//			if (ContainsFlag(Flags, ActionFlags.Sheets))  AddSheetName = (StringBuilder builder, string sheetname) => AddSheetName 

//			foreach (DataTable table in Set.Tables)
//			{
				
//			}
//		}

//		string AccurateSearh(string[] keys, DataSet Set, ActionFlags Flags)
//		{

//		}	
		
//		public Action<StringBuilder> SearchBuilder(ActionFlags Flags)
//		{
//			Action<StringBuilder, string> AddSheetName;
//			Action<StringBuilder, int, string> AddCellName;
//			Action<StringBuilder, int> AddCount;

//			if (ContainsFlag(Flags, ActionFlags.Sheets)) AddSheetName = (StringBuilder builder, string sheetname) =>
//			{
//				builder.Append(sheetname);
//				builder.AppendLine();
//			};

//			if (ContainsFlag(Flags, ActionFlags.Names)) AddCellName = (StringBuilder builder, int raw, string column) =>
//			{
//				builder.Append();
//				builder.AppendLine();
//			};
			

//		}

//		static bool ContainsFlag(ActionFlags obj, ActionFlags prototype)
//		{
//			return ((obj & prototype) > 0);
//		}
//	}
//}
