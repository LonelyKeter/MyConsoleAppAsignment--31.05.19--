using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	internal class CellNameRepresenter : Representer, IWrapper<IRepresenter>
	{
		public IRepresenter Base { get; set; }

		public CellNameRepresenter(IRepresenter Base)
		{
			this.Base = Base;
			this.Prefix = Base.Prefix;
		}

		public override StringBuilder Represent(SearchResult searchResult)
		{
			StringBuilder builder = Base.Represent(searchResult);

			string OwnPrefix = Prefix.Prefix == null ? null : Prefix + ".";
			for (int t = 0; t < searchResult.TableCount; t++)
			{
				for (int k = 0; k < searchResult.Count; k++)
				{
					foreach (string s in searchResult[k].CellNames[t]) builder.AppendLine(OwnPrefix + s);
				}
			}

			return builder;
		}

		public override StringBuilder Represent(SearchResult.Result result)
		{
			StringBuilder builder = Base.Represent(result);
			string OwnPrefix = Prefix.Prefix == null ? null : Prefix + ".";

			for (int t = 0; t < result.Count; t++)
			{
				foreach (string s in result.CellNames[t]) builder.AppendLine(OwnPrefix + s);
			}

			return builder;
		}

		public override StringBuilder Represent(SearchResult searchResult, int table)
		{
			StringBuilder builder = Base.Represent(searchResult);
			string OwnPrefix = Prefix.Prefix == null ? null : Prefix + ".";

			for (int k = 0; k < searchResult.Count; k++)
				{
					foreach (string s in searchResult[k].CellNames[table]) builder.AppendLine(OwnPrefix + s);
				}			

			return builder;
		}

		public override StringBuilder Represent(SearchResult.Result result, int table)
		{
			StringBuilder builder = Base.Represent(result);
			string OwnPrefix = Prefix.Prefix == null ? null : Prefix + ".";

			foreach (string s in result.CellNames[table]) builder.AppendLine(OwnPrefix + s);			

			return builder;
		}
	}
}
