using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pattern.Behavioural.Strategy.StrategyPatternRunner;

namespace Pattern.Behavioural.Strategy
{
    internal static class StrategyPatternRunner
    {
        public static void Run()
        {
            Console.WriteLine("Strategy Pattern Runner");
            var inputText = "DE3327050399";
            var charsToExtract = '3';
            var extractTextPositiveStrategy = new ExtractTextPositiveStrategy(inputText, charsToExtract);
            var extractTextNegativeStrategy = new ExtractTextNegativeStrategy(inputText, charsToExtract);

            var strategies = new List<IStrategy>();
            strategies.Add(extractTextPositiveStrategy);
            strategies.Add(extractTextNegativeStrategy);

            foreach (var strategy in strategies)
			{
				strategy.Execute();
                Console.WriteLine(strategy.Name + " = " + strategy.GetOutput());
			}
            Console.WriteLine();
        }

        public interface IStrategy
        {
            public void Execute();
            public string GetOutput();
            public string Name { get; set;}
            public string Output { get; set;}
        }

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

        public class ExtractTextNegativeStrategy : IStrategy
        {
            private string _input;
            private char _charToExtract;
            public string Unused;

            private string _output;
            public string Output {get => _output; set => _output = value; }

			private string _name;
            public string Name { get => _name; set => _name = value; }

			public ExtractTextNegativeStrategy(string input, char charsToExtract)
            {
                Name = "ExtractTextNegative";
                _input = input;
                _charToExtract = charsToExtract;
                _output = "";
            }
            public void Execute()
            {
                foreach (var splittedChar in _input.ToCharArray())
                {
                    if (!splittedChar.Equals(_charToExtract))
                    {
                        Unused += splittedChar;
                    }
                    else
                    {
                        Output += splittedChar;
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
