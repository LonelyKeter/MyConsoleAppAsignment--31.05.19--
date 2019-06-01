using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using ExcelDataReader;
using MyConsoleAppAsignment;

namespace Test
{
	class Test
	{
		static void Main()
		{
			string[] args = { "-sun", "Male", @"C:\Users\LonelyKeter\source\repos\MyConsoleAppAsignment\Test\bin\Debug\file_example_XLS_10.xsx" };
			ArgumentVerifier verifier = ArgumentVerifier.Factory.GetVerifier();

			VerifyResult vresult = verifier.Verify(args, out ActionFlags Flags);

			switch (vresult)
			{
				case VerifyResult.Fail :
					Console.WriteLine(ErrorMessages.WrongParametersPassed);
					return;
				case VerifyResult.InvalidArguments:
					Console.WriteLine(ErrorMessages.WrongParametersPassed);
					return;
				case VerifyResult.InvalidFilePath:
					Console.WriteLine(ErrorMessages.FileDoesNotExist);
					return;
				case VerifyResult.NotEnoughArguments:
					Console.WriteLine(ErrorMessages.NotEnoughArguments);
					return;
			}

			LocalDataSet set = LocalDataSet.Factory.GetLocalDataSet();

			ReaderState readerState = new ReaderState { Options = (Flags & ActionFlags.Unrestrict) == 0 ? ReadOptions.RestrictFileType : ReadOptions.None };

			IReader reader = EDRReader.Factory.GetEDRReader(readerState,set);

			reader.Read(args.Last());			

			SearchResult result = Searcher.Search(Searcher.GetKeys(args), set);

			IRepresenter representer = RepresenterFactory.GetRepresenter(Flags);

			Console.WriteLine(representer.Represent(result));
		}
	}
}
