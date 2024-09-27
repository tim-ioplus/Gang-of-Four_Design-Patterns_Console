namespace Pattern.Structural.Bridge
{
	public static partial class BridgePatternRunner
	{
		public class BPrinter : AbstractPrinter
		{
			public BPrinter(IPrinter impl) : base(impl){ }

			public void Print()
			{
				_impl.Print("B");
			}
		}
	}
}
