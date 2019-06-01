using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	public struct RepresenterState 
	{
		public ActionFlags Flags;

		public static RepresenterState Default = new RepresenterState
		{
			Flags = ActionFlags.Count | ActionFlags.Names | ActionFlags.Sheets
		};
	}
}
