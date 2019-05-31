using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	public interface IReader
	{
		LocalDataSet Set { get; }

		ReaderState State { get; }

		/// <summary>
		/// Reads a file from passed <c>filepath</c> into <c>Set</c> property
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns>True if file was read, otherwise false</returns>
		bool Read(string filepath);		
	}

	///// <summary>
	///// Guarinties that <c>Read</c> method will run properly 
	///// </summary>
	//public interface ISafeReader : IReader { }

	///// <summary>
	///// Does not guaranty that <c>Read</c> method will run properly 
	///// </summary>
	//public interface IUnsafeReader : IReader { }	
}
