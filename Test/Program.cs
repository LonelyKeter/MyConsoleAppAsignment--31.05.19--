﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = args.Last();

			if (!File.Exists(path)) { Console.WriteLine()}
		}
	}
}