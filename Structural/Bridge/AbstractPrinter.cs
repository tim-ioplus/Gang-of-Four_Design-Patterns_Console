namespace Pattern.Structural.Bridge
{
	public static partial class BridgePatternRunner
	{
		public abstract class AbstractPrinter 
		{
			protected IPrinter _impl { get;set;}

			public AbstractPrinter(IPrinter impl)
			{
				_impl = impl;
			}
		}
	}
}
