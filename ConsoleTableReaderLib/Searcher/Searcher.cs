using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyConsoleAppAsignment
{
	public class Searcher
	{
		public SearchResult Search(string[] keys, LocalDataSet Set)
		{
			var data = (DataSet)Set;
			return Search(keys, data);
		}		
		public SearchResult Search(string[] keys, DataSet Set)
		{
			SearchResult result = new SearchResult(Set.Tables.Count);



			return result;
		}
	}
}
