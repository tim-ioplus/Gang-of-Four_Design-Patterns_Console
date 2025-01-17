namespace Pattern.Structural.Composite
{
	public class Composite : IComposite 
	{
		public string Name { get; set; }
		public double Price { get; set; }
		public int Quantity  { get; set; }
		public Composite(string name, double price, int quantity)
		{
			Name = name;
			Price = price;
			Quantity = quantity;
		}

		public double GetCost()
		{
			return Price * Quantity;
		}
	}
}
