using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// A state container for an <c>IReader</c> object
	/// </summary>
	public struct ReaderState
	{
		/// <summary>
		/// Deafault <see cref="IReader"/> state
		/// </summary>
		public static ReaderState Default = new ReaderState { Options = ReadOptions.RestrictFileType };

		public ReadOptions Options;	
	}
}
