namespace Pattern.Behavioural.Strategy
{
	internal static partial class StrategyPatternRunner
    {
		public interface IStrategy
        {
            public void Execute();
            public string GetOutput();
            public string Name { get; set;}
            public string Output { get; set;}
        }
    }
}