using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// Inherited wrapped class for any custom <see cref="IRepresenter"/>
	/// </summary>
	internal class Representer: IRepresenter
	{
		public PrefixContainer Prefix { get; set; } = new PrefixContainer() { Prefix = null };		

		public virtual StringBuilder Represent(SearchResult searchResult)
		{
			return new StringBuilder();
		}
		public virtual StringBuilder Represent(SearchResult.Result result)
		{
			return new StringBuilder();
		}
		public virtual StringBuilder Represent(SearchResult searchResult, int t)
		{
			return new StringBuilder();
		}
		public virtual StringBuilder Represent(SearchResult.Result result, int t)
		{
			return new StringBuilder();
		}
	}
}
