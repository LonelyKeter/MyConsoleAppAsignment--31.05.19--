using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	public struct SearcherState 
	{
		public ActionFlags Flags;

		public static SearcherState Default = new SearcherState
		{
			Flags = ActionFlags.Count | ActionFlags.Names | ActionFlags.Sheets
		};
	}
}
