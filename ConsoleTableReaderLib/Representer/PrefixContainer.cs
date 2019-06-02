using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// A container for common <see cref="IRepresenter.Prefix"/> string value, which is used by all <see cref="IRepresenter"/> objects in representation process
	/// </summary>
	public class PrefixContainer
	{
		public string Prefix { get; set; }

		public override string ToString()
		{
			return Prefix.ToString();
		}
	}
}
