using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// An interface, implemented by any <see cref="IReader"/> object
	/// </summary>
	public interface IReader
	{
		/// <summary>
		/// A <see cref="LocalDataSet"/>, where this instance of <see cref="IReader"/> reads a file to
		/// </summary>
		LocalDataSet Set { get; }

		/// <summary>
		/// This <see cref="IReader"/> object's state
		/// </summary>
		ReaderState State { get; }

		/// <summary>
		/// Reads a file from passed <paramref name="filepath"/> into <c>Set</c> property
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
