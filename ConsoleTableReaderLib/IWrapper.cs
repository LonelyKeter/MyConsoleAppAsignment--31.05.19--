using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	internal interface IWrapper<T>
	{
		T Base { get; }
	}
}
