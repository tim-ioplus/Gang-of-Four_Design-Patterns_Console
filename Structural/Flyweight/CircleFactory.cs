namespace Pattern.Structural.Flyweight
{
	public class CircleFactory
	{
		private Dictionary<string, Circle> circles;

		public CircleFactory() 
		{
			circles = new Dictionary<string, Circle>();
		}

		public Circle CreateCircle(string color)
		{
			if(!circles.ContainsKey(color))
			{
				circles[color] = new Circle(color);
			}

			return circles[color];
		}
	}
}
