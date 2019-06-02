using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// An interface, implemented by any <see cref="IRepresenter"/> wrapper 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	internal interface IWrapper<T>
	{
		/// <summary>
		/// An object, wrapped by this <see cref="IWrapper{T}"/>
		/// </summary>
		T Base { get; }
	}
}
