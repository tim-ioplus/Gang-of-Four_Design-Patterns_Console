namespace Pattern.Structural.Bridge
{
	public static partial class BridgePatternRunner
	{
		public class HtmlPrinter : IPrinter 
		{
			public void Print(string message) 
			{
				Console.WriteLine($"<p>" + message + "</p>");
			}
		}
	}
}
