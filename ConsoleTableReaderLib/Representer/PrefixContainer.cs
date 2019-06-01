using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	public class PrefixContainer
	{
		public string Prefix { get; set; }

		public override string ToString()
		{
			return Prefix.ToString();
		}
	}
}
