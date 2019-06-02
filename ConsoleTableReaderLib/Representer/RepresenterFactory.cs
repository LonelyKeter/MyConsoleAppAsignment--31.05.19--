using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// An <see cref="IRepresenter"/> decorator, that wraps a <see cref="Representer"/> into needed <see cref="IWrapper{IRepresenter}"/>
	/// </summary>
	public static class RepresenterFactory
	{
		/// <summary>
		/// Wraps a <see cref="Representer"/> in the correct order into needed <see cref="IWrapper{IRepresenter}"/>, depending on passed <paramref name="Flags"/>
		/// </summary>
		/// <param name="Flags"><see cref="ActionFlags"/> value, that defines wrapping process</param>
		/// <returns>Custom <see cref="IRepresenter"/>, that was created corresponding to passed <paramref name="Flags"/> value</returns>
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
