using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Creational.Prototype
{
	internal static class PrototypePatternRunner
	{
		internal static void Run()
		{
			Console.WriteLine("Prototype Pattern");
			var original = new ConcretePrototype("Augusta Ada Lovelace", 1);
			Console.WriteLine("Original Prototype:");
			Console.WriteLine(original.ToString());
			
			var clone = (ConcretePrototype) original.Clone();
			Console.WriteLine("Cloned Prototype:");
			Console.WriteLine(clone.ToString());
			
			clone.Name = "Max Schmeling";
			clone.Number = 2;
			Console.WriteLine("Cloned Modified Prototype:");
			Console.WriteLine(clone.ToString());
		}
	}
}
