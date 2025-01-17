// See https://aka.ms/new-console-template for more information
public class ConcretePrototype : IPrototype
{
	public string Name { get; set; }
	public int Number	{ get; set; }
	private Guid guid { get; set; }

	public ConcretePrototype(string name, int number)
	{
		Name = name;
		Number = number;
		guid = Guid.NewGuid();
	}
	public ConcretePrototype(ConcretePrototype firstPrototype)
	{
		this.Name = firstPrototype.Name;
		this.Number = firstPrototype.Number;
		this.guid = firstPrototype.guid;
	}

	public string ToString()
	{
		return "public Name: " + Name + " - public Number: " + Number + " - private guid: " + guid;
	}

	public Object Clone()
	{
		return (IPrototype)this.MemberwiseClone();
	}
}
