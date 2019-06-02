using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// An interface, implemented by any <see cref="SearchResult"/> representer
	/// </summary>
	public interface IRepresenter
	{
		PrefixContainer Prefix { get; set; }

		/// <summary>
		/// Represents specified result on the level of the whole passed <paramref name="searchResult"/>
		/// </summary>
		/// <param name="searchResult"></param>
		/// <returns>Stringbuilder, representing result</returns>
		StringBuilder Represent(SearchResult searchResult);

		/// <summary>
		/// Represents specified result on the level of keyword
		/// </summary>
		/// <param name="result"></param>
		/// <returns>Stringbuilder, representing result</returns>
		StringBuilder Represent(SearchResult.Result result);

		/// <summary>
		/// Represents specified result on the level of concrete table sheet (doesn't depend on keyword)
		/// </summary>
		/// <param name="searchResult"></param>
		/// <param name="t"></param>
		/// <returns></returns>
		StringBuilder Represent(SearchResult searchResult, int t);

		/// <summary>
		/// Represents specified result on the level of concrete table sheet and keyword
		/// </summary>
		/// <param name="result"></param>
		/// <param name="t"></param>
		/// <returns></returns>
		StringBuilder Represent(SearchResult.Result result, int t);
	}
}
