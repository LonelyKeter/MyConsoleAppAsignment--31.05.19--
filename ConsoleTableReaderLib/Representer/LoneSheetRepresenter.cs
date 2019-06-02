using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleAppAsignment
{
	/// <summary>
	/// <para>A special wrapper, that adds a sheet representation to <see cref="Base"/> <see cref="IRepresenter"/> representation, that is when {s} flag was passed without {n} flag</para>
	/// <para>Doesn't support <see cref="IRepresenter.Represent(SearchResult, int)"/> and <see cref="IRepresenter.Represent(SearchResult.Result, int)"/></para>
	/// </summary>
	internal class LoneSheetRepresenter : Representer, IWrapper<IRepresenter>
	{
		public IRepresenter Base { get; set; }		

		public LoneSheetRepresenter(IRepresenter Base)
		{
			this.Base = Base;
		}

		public override StringBuilder Represent(SearchResult searchResult)
		{
			StringBuilder builder = new StringBuilder();

			for (int t = 0; t < searchResult.TableCount; t++)
			{
				int k = 0;

				for (; k < searchResult.Count; k++) if (searchResult[k].SheetNames[t] != null) break;

				if (k >= searchResult.Count) continue;

				builder.Append(searchResult[k].SheetNames[t] + " ");
				builder.Append(Base.Represent(searchResult));
				builder.AppendLine();
			}

			return builder;
		}

		public override StringBuilder Represent(SearchResult.Result result)
		{
			StringBuilder builder = new StringBuilder();

			for (int t = 0; t < result.Count; t++)
			{
				if (result.SheetNames[t] == null) continue;
				builder.Append(result.SheetNames[t] + " ");
				builder.Append(Base.Represent(result));
				builder.AppendLine();
			}

			return builder;
		}

		public override StringBuilder Represent(SearchResult searchResult, int t)
		{
			throw new NotSupportedException();
		}
		public override StringBuilder Represent(SearchResult.Result result, int t)
		{
			throw new NotSupportedException();
		}
	}
}
