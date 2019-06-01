using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	public struct SearchResult
	{
		public string[] Keys { get; private set; }
		public Result[] Results;
		public int Count { get; private set; }
		public int TableCount { get; private set; } 

		public SearchResult(int tablecount, string[] keys)
		{
			Results = new Result[keys.Length];
			Count = keys.Length;
			TableCount = tablecount;

			for (int i = 0; i < Results.Length; i++) Results[i] = new Result(tablecount);

			Keys = keys;
		}

		public struct Result
		{
			public int Count { get; private set; }

			public string[] SheetNames;

			public Queue<string>[] CellNames;

			public ulong[] Counts;

			public Result(int tablecount)
			{
				Count = tablecount;

				SheetNames = new string[tablecount];

				CellNames = new Queue<string>[tablecount];
				for (int i = 0; i < tablecount; i++) CellNames[i] = new Queue<string>();

				Counts = new ulong[tablecount];
			}
		} 

		public Result this[int i]
		{
			get { return Results[i]; }
		}
	}
}
