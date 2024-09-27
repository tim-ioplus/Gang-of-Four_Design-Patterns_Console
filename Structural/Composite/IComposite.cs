namespace Pattern.Structural.Composite
{
	public interface IComposite
	{
		public string Name {get;set; }
		public int Quantity {get;set;}
		public double GetCost();
	}
}
