namespace Pattern.Structural.Bridge
{
	public static partial class BridgePatternRunner
	{
		public class JsonPrinter : IPrinter 
		{
			public void Print(string message) 
			{
				Console.WriteLine($"{{ \"message\": \" { message } \" }}");
			}
		}
	}
}
