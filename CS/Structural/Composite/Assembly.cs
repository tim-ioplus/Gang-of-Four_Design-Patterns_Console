namespace Pattern.Structural.Composite
{
	public class Assembly : IComposite
	{
		public readonly List<IComposite> _components = new();
		public string Name { get; set; }
		public int Quantity { get; set; }

		public Assembly(string name, int quantity, List<IComposite> components)
		{
			Name = name;
			Quantity = quantity;
			_components.AddRange(components);
		}

		public double GetCost()
		{
			return _components.Sum(c => c.GetCost());
		}
	}
}
