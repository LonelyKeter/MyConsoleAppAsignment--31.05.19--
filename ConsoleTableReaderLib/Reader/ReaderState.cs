using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	public struct ReaderState
	{
		public static ReaderState Default = new ReaderState { Options = ReadOptions.RestrictFileType };

		public ReadOptions Options;	
	}
}
