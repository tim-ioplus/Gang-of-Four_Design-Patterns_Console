namespace Pattern.Behavioural.Strategy
{
	internal static partial class StrategyPatternRunner
    {
		public class ExtractTextPositiveStrategy : IStrategy
        {
            private string _input;
            private char _charToExtract;
            public string Unused;

            private string _output;
            public string Output {get => _output; set => _output = value; }

			private string _name;
            public string Name { get => _name; set => _name = value; }

			public ExtractTextPositiveStrategy(string input, char charsToExtract)
            {
                Name = "ExtractTextPositive";
                _input = input;
                _charToExtract = charsToExtract;
                _output = "";
            }
            public void Execute()
            {
                foreach (var splittedChar in _input.ToCharArray())
                {
                    if (splittedChar.Equals(_charToExtract))
                    {
                        Output += splittedChar;
                    }
                    else
                    {
                        Unused += splittedChar;
                    }
                }
            }

			public string GetOutput()
			{
				return Output;
			}
		}
    }
}