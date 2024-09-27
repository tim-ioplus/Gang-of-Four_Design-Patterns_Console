using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Structural.Composite
{
	public static class CompositePatternRunner
	{
		public static void Run()
		{
			Console.WriteLine("Composite Pattern");

			var engine = new Composite("Engine", 10000, 1);
			var tires = new Composite("Tires", 500, 4);
			var body = new Assembly("Body", 1, new List<IComposite>()
			{
				new Composite("Frame", 1, 7500),
				new Composite("Doors", 6, 750),
				new Composite("Windows", 6, 325)
			});

			Console.WriteLine($"Engine costs: { engine.GetCost() } ");
			Console.WriteLine($"Tires costs: { tires.GetCost() } ");
			Console.WriteLine($"Body costs: { body.GetCost() } ");
			
			var car = new Assembly("Car", 1, new List<IComposite>(){engine, tires, body});

			Console.WriteLine($"Car costs: { car.GetCost() } ");
		}
	}
}
