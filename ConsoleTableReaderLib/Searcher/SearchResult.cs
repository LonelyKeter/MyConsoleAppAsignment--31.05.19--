using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	public struct SearchResult
	{
		public string[] SheetNames;

		public Queue<string>[] CellNames;

		public long[] Counts;

		public SearchResult(int i)
		{
			SheetNames = new string[i];
			CellNames = new Queue<string>[i];
			Counts = new long[i];
		}
	}
}
