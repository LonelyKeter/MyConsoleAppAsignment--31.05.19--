using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyConsoleAppAsignment
{
	/// <summary>
	///  Primitive wrapper around <c>DataSet</c>. Ensures relative control on input to <c>IReader</c> factory
	/// </summary>
	public class LocalDataSet
	{		
		public DataSet Set { get; set; }

		public static explicit operator LocalDataSet(DataSet set)
		{
			return new LocalDataSet() { Set = set };
		}
		public static explicit operator DataSet(LocalDataSet set)
		{
			return set.Set;
		}		

		public static class Factory
		{
			/// <summary>
			/// Creates new <c>LocalDataSet</c> object
			/// </summary>
			/// <returns>New instance of <c>LocalDataSet</c></returns>
			public static LocalDataSet GetLocalDataSet()
			{
				return new LocalDataSet { Set = new DataSet() };
			}
		}
	}
}
