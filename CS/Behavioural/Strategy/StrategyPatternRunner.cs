using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pattern.Behavioural.Strategy.StrategyPatternRunner;

namespace Pattern.Behavioural.Strategy
{
	internal static partial class StrategyPatternRunner
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
    }
}