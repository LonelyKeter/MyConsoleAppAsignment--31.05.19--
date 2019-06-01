using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	public static class RepresenterFactory
	{
		public static IRepresenter GetRepresenter(ActionFlags Flags)
		{
			Flags = Flags & ~ActionFlags.Unrestrict;
			IRepresenter result = new Representer();

			if (Flags == (ActionFlags.Sheets | ActionFlags.Keys)) return new KeyRepresenter(new LoneSheetRepresenter(new Representer()));
			if (Flags == (ActionFlags.Sheets | ActionFlags.Count)) return new LoneSheetRepresenter(new CountRepresenter(new Representer()));
			if (Flags == (ActionFlags.Sheets | ActionFlags.Keys | ActionFlags.Count)) return new KeyRepresenter(new LoneSheetRepresenter(new CountRepresenter(new Representer())));

			if ((Flags & ActionFlags.Names) > 0) result = new CellNameRepresenter(result);

			if ((Flags & ActionFlags.Count) > 0) result = new CountRepresenter(result);

			if ((Flags & ActionFlags.Sheets) > 0) result = new SheetRepresenter(result);

			if ((Flags & ActionFlags.Keys) > 0)	result = new KeyRepresenter(result);			

			return result;
		}
	}
}
