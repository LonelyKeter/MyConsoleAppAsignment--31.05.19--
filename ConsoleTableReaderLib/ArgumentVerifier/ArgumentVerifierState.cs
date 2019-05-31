using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// State container for an <c>ArgumentVeirfier</c>  object
	/// </summary>
	public struct ArgumentVerifierState
	{
		/// <summary>
		/// Default <c>ArgumentVerifier</c> state
		/// </summary>
		public static ArgumentVerifierState Default = new ArgumentVerifierState()
		{
			Options = VerifyOptions.ForbidExtraChars | VerifyOptions.ForbidRepeatingArgs
		};
		
		public VerifyOptions Options;
	}
}
