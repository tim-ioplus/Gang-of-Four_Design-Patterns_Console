using System.Drawing;

namespace Pattern.Structural.Flyweight
{
	public class Circle : ICircle 
	{
		public string Color = "";

		public Circle(string color)
		{
			Color = color;
		}

		public void Draw(Point point) 
		{
			Console.WriteLine($"{Color} circle drawn at {point.X} {point.Y}");
		}
	}
}
