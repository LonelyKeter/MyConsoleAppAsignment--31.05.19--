using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	internal class CountRepresenter : Representer, IWrapper<IRepresenter>
	{
		public IRepresenter Base { get; set; }

		public CountRepresenter(IRepresenter Base)
		{
			this.Base = Base;
			this.Prefix = Base.Prefix;
		}

		public override StringBuilder Represent(SearchResult searchResult)
		{
			StringBuilder builder = Base.Represent(searchResult);

			ulong count = 0;

			for (int t = 0; t < searchResult.TableCount; t++)
			{
				for (int k = 0; k < searchResult.Count; k++)
				{
					count += searchResult[k].Counts[t];
				}
			}

			builder.AppendLine(count.ToString());

			return builder;
		}

		public override StringBuilder Represent(SearchResult.Result result)
		{
			StringBuilder builder = Base.Represent(result);

			ulong count = 0;

			for (int t = 0; t < result.Count; t++)
			{
				count += result.Counts[t];
			}

			builder.AppendLine(count.ToString());

			return builder;
		}

		public override StringBuilder Represent(SearchResult.Result result, int table)
		{
			StringBuilder builder = Base.Represent(result);

			string ownPrefix = null;
			builder.AppendLine(ownPrefix + result.Counts[table].ToString());

			return builder;
		}

		public override StringBuilder Represent(SearchResult searchResult, int table)
		{
			StringBuilder builder = Base.Represent(searchResult);

			string ownPrefix = null;

			ulong count = 0;
			
			for (int k = 0; k < searchResult.Count; k++) count += searchResult[k].Counts[table];

			builder.AppendLine(ownPrefix + count.ToString());

			return builder;
		}
	}
}
