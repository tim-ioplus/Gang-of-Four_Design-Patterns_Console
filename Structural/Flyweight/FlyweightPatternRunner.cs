using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Structural.Flyweight
{
	public static class FlyweightPatternRunner
	{
        public static void Run()
		{
			Console.WriteLine("Flyweight Pattern Runner..");
			var circleFactory = new CircleFactory();

			string[] colors = { "cyan", "magenta", "yellow", "black"};

			int maxCircles = 100;
			for (int i = 0; i < maxCircles; i++)
			{
				int colorIndex = Random.Shared.Next(colors.Length);
				var circle = circleFactory.CreateCircle(colors[colorIndex]);

				var point = new Point(){ X = Random.Shared.Next(1000), Y = Random.Shared.Next(1000) };
				circle.Draw(point);
			}

			Console.WriteLine();
			int bitsPerShape = 8, bitsPerColor = 8, bitsPerPositionX = 8, bitsPerPositionY = 8;

			int bitsPerCircle = bitsPerShape + bitsPerColor + bitsPerPositionX + bitsPerPositionY;
			int bitsTotal = bitsPerCircle * maxCircles;

			int intrinsicSharedBits = (bitsPerShape + bitsPerColor) * colors.Length;
			int extransicSharedBits = (bitsPerPositionX + bitsPerPositionY) * maxCircles;
			int flyweightBits = intrinsicSharedBits + extransicSharedBits;

			int savedBits = bitsTotal - flyweightBits;
			double usedPercentage = (double) flyweightBits / bitsTotal * 100;
			double savedPercentage = 100 - usedPercentage;

			Console.WriteLine("Flyweight Pattern used " + flyweightBits + " bits / " + usedPercentage + " % of memory.");
			Console.WriteLine("Flyweight Pattern saved " + savedBits + " bits / " + savedPercentage +  " % of memory.");
		}
	}
}
