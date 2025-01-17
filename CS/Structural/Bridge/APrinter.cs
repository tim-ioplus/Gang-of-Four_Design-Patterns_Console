namespace Pattern.Structural.Bridge
{
	public static partial class BridgePatternRunner
	{
		public class APrinter : AbstractPrinter
		{
			public APrinter(IPrinter impl) : base(impl) {}

			public void Print()
			{
				_impl.Print("A");
			}
		}
	}
}
