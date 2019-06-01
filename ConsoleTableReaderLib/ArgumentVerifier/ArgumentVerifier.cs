using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// Contains methods and state for argument verification
	/// </summary>
	 public class ArgumentVerifier
	{
		public ArgumentVerifierState State { get; protected set; }

		/// <summary>
		/// Verifies passed filepath (last <c>string</c> in <c>Args</c>)
		/// </summary>
		/// <param name="Args">sArguments passed to program</param>
		/// <returns>
		/// <para>If file exists returns <c>VerifyResult.Success</c></para>
		/// <para>If only one argument was passed returns <c>VerifyResult.NotEnoughArguments</c></para> 
		/// <para>If file doesn't exist returns <c>VerifyResult.IvalidFilePath</c></para>
		/// </returns>
		protected VerifyResult VerifyFilePath(string[] Args)
		{
			if (Args.Length == 1) return VerifyResult.NotEnoughArguments;
			else return File.Exists(Args.Last()) ? VerifyResult.Success : VerifyResult.InvalidFilePath;
		}

		/// <summary>
		/// Varifies passed flags (first <c>string</c> in <c>Args</c>)
		/// </summary>
		/// <param name="Args"></param>
		/// <param name="Flags"></param>
		/// <returns></returns>
		protected VerifyResult VerifyFlags(string[] Args, out ActionFlags Flags)
		{
			return this.VerifyFlags(Args, out Flags, this.State.Options);
		}
		protected VerifyResult VerifyFlags(string[] Args, out ActionFlags Flags, VerifyOptions Options)
		{	
			//Command syntex ensured, because method is called after VerifyFilePath Method 
			if (Args.Length == 2 || Args[0][0] != '-')
			{
				Flags = ActionFlags.Names | ActionFlags.Count | ActionFlags.Sheets;
				return VerifyResult.Success;
			}

			Flags = ActionFlags.None;			

			if ((Options & VerifyOptions.ForbidRepeatingArgs) > 0 && Args[0].Length > 6) return VerifyResult.InvalidArguments;

			//Flag collection depending on VerifyOptions arg
			for (int i = 1; i < Args[0].Length; i++)
			{
				switch (Args[0][i])
				{
					case '-': return VerifyResult.InvalidArguments;
					case 'c':
						if (!ContainsFlag(Flags, ActionFlags.Count))
						{
							Flags = Flags | ActionFlags.Count;
							break;
						}
						else
							if (ContainsFlag(Options, VerifyOptions.ForbidRepeatingArgs)) return VerifyResult.InvalidArguments;
						break;
					case 'n':
						if (!ContainsFlag(Flags, ActionFlags.Names))
						{
							Flags = Flags | ActionFlags.Names;
							break;
						}
						else
							if (ContainsFlag(Options, VerifyOptions.ForbidRepeatingArgs)) return VerifyResult.InvalidArguments;
						break;
					case 's':
						if (!ContainsFlag(Flags, ActionFlags.Sheets))
						{
							Flags = Flags | ActionFlags.Sheets;
							break;
						}
						else
							if (ContainsFlag(Options, VerifyOptions.ForbidRepeatingArgs)) return VerifyResult.InvalidArguments;
						break;
					case 'k':
						if (!ContainsFlag(Flags, ActionFlags.Keys))
						{
							Flags = Flags | ActionFlags.Keys;
							break;
						}
						else
							if (ContainsFlag(Options, VerifyOptions.ForbidRepeatingArgs)) return VerifyResult.InvalidArguments;
						break;
					case 'u':
						if (!ContainsFlag(Flags, ActionFlags.Unrestrict))
						{
							Flags = Flags | ActionFlags.Unrestrict;
							break;
						}
						else
							if (ContainsFlag(Options, VerifyOptions.ForbidRepeatingArgs)) return VerifyResult.InvalidArguments;
						break;
					default:
						if (ContainsFlag(Options, VerifyOptions.ForbidExtraChars)) return VerifyResult.InvalidArguments;
						break;
				}
			}

			if (Flags == ActionFlags.Keys ||
				Flags == ActionFlags.Unrestrict ||
				Flags == (ActionFlags.Unrestrict | ActionFlags.Keys))
				AddDefaultFlags(ref Flags);

			return VerifyResult.Success;
		}

		/// <summary>
		/// Verifies passed arguments
		/// </summary>
		/// <param name="Args">sArguments passed to program</param>
		/// <param name="Flags"><c>ActionFlags</c> used for factoring <c>Searcher</c> object</param>
		/// <returns><c>VerifyResult.Success</c> if passed arguments are valid and <c>VerifyResult.Fail</c> otherwise</returns>
		public virtual VerifyResult Verify(string[] Args, out ActionFlags Flags)
		{
			VerifyResult a = VerifyFilePath(Args);
			VerifyResult b = VerifyFlags(Args, out Flags);

			return a == VerifyResult.Success ? b : a;
		}

		static bool ContainsFlag(ActionFlags obj, ActionFlags prototype)
		{
			return ((obj & prototype) > 0);
		}
		static bool ContainsFlag(VerifyOptions obj, VerifyOptions prototype)
		{
			return ((obj & prototype) > 0);
		}

		/// <summary>
		/// Adds Count, Names and Sheets values to <paramref name="flags"/> 
		/// </summary>
		/// <param name="flags"></param>
		static void AddDefaultFlags(ref ActionFlags flags)
		{
			flags = flags | ActionFlags.Count | ActionFlags.Names | ActionFlags.Sheets;
		}

		/// <summary>
		///Static <c>ArgumentVerifier</c> Factory class containing factory methods
		/// </summary>
		public static class Factory
		{
			/// <summary>
			/// Creates custom instance of <c>ArgumentVerifier</c> coresponding to passed <c>ArgumentVerifierState</c> structure
			/// </summary>
			/// <param name="State"><c>ArgumentVerifierState</c> struct containing needed state</param>
			/// <returns>New instance of an <c>ArgumentVerifier</c></returns>
			public static ArgumentVerifier GetVerifier(ArgumentVerifierState State)
			{
				ArgumentVerifier result = new ArgumentVerifier();
				result.State = State;
				return result;
			}

			/// <summary>
			/// Creates default instance of <c>ArgumentVerifier</c> coresponding to default <c>ArgumentVerifierState</c>
			/// </summary>
			/// <returns>New instance of an <c>ArgumentVerifier</c></returns>
			public static ArgumentVerifier GetVerifier()
			{
				return GetVerifier(ArgumentVerifierState.Default);
			}
		}
	}
}
