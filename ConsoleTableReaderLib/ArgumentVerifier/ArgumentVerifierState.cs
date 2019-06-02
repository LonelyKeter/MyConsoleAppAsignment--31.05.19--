using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// State container for an <see cref="ArgumentVerifier"/>  object
	/// </summary>
	public struct ArgumentVerifierState
	{
		/// <summary>
		/// Default <see cref="ArgumentVerifier"/> state
		/// </summary>
		public static ArgumentVerifierState Default = new ArgumentVerifierState()
		{
			Options = VerifyOptions.ForbidExtraChars | VerifyOptions.ForbidRepeatingArgs
		};
		
		public VerifyOptions Options;
	}
}
