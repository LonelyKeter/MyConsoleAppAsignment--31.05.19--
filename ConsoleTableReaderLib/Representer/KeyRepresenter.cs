using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	internal class KeyRepresenter : Representer, IWrapper<IRepresenter>
	{
		public IRepresenter Base { get; set;}

		public KeyRepresenter(IRepresenter Base)
		{
			this.Base = Base;
			this.Prefix = Base.Prefix;
		}

		public override StringBuilder Represent(SearchResult searchResult)
		{
			StringBuilder builder = new StringBuilder();

			for (int k = 0; k < searchResult.Count; k++)
			{
				builder.AppendLine(searchResult.Keys[k] + " :");
				builder.Append(Base.Represent(searchResult[k]));
				builder.AppendLine();
			}

			return builder;
		}

		public override StringBuilder Represent(SearchResult.Result result)
		{
			throw new NotSupportedException();
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
