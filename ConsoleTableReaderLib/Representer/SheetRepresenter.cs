using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	internal class SheetRepresenter : Representer, IWrapper<IRepresenter>
	{
		public IRepresenter Base { get; set; }

		public SheetRepresenter(IRepresenter Base)
		{
			this.Base = Base;
			this.Prefix = Base.Prefix;
		}

		public override StringBuilder Represent(SearchResult searchResult)
		{
			StringBuilder builder = new StringBuilder();

			for (int t = 0; t < searchResult.TableCount; t++)
			{
				int k = 0;

				for (; k < searchResult.Count; k++) if (searchResult[k].SheetNames[t] != null) break;

				if (k >= searchResult.Count) continue;

				Base.Prefix.Prefix = searchResult[k].SheetNames[t];

				builder.Append(Base.Represent(searchResult, t));
			}		

			return builder;
		}

		public override StringBuilder Represent(SearchResult.Result result)
		{
			StringBuilder builder = new StringBuilder();

			for (int t = 0; t < result.Count; t++)
			{
				if (result.SheetNames[t] == null) continue;

				Prefix.Prefix = result.SheetNames[t];
				builder.Append(Base.Represent(result, t));
			}

			return builder;
		}

		public override StringBuilder Represent(SearchResult searchResult, int t)
		{
			throw new NotSupportedException();
		}
		public override StringBuilder Represent(SearchResult.Result result, int t)
		{
			throw new NotSupportedException();
		}
	}
}
