using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Creational.Singleton
{
	internal static class SingletonPatternRunner
	{
		internal static void Run()
		{
			Console.WriteLine("Singleton Pattern ");

			var s1 = IamSingleton.getInstance();
			Console.WriteLine("s1: " + s1.ToString());
			s1.WriteFile("my/path/to/file");

			
			var s2 = IamSingleton.getInstance();
			Console.WriteLine("s2: " + s2.ToString());
			s2.WriteFile("my/path/to/file");
		}
	}
}
