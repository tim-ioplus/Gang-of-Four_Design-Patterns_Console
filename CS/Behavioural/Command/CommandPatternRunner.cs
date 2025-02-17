using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Behavioural.Command
{
	internal static partial class CommandPatternRunner
	{
		internal static void Run()
		{
			Console.WriteLine("Command Pattern");

			var calculator = new Calculator();
			var addTen = new AddCommand(10);
			calculator.Do(addTen);
			double expected = 10;
			Console.WriteLine("Value is " + calculator.CurrentValue + " - Command correct: " + (calculator.CurrentValue == expected));

			var subtractFive = new SubtractCommand(5);
			calculator.Do(subtractFive);
			expected-=5; 
			Console.WriteLine("Value is " + calculator.CurrentValue + " - Command correct: " + (calculator.CurrentValue == expected));

			var multiplyByFive = new MultiplyCommand(5);
			calculator.Do(multiplyByFive);
			expected *=5;
			Console.WriteLine("Value is " + calculator.CurrentValue + " - Command correct: " + (calculator.CurrentValue == expected));

			var divideByTen = new DivideCommand(10);
			calculator.Do(divideByTen);
			expected /= 10;
			Console.WriteLine("Value is " + calculator.CurrentValue + " - Command correct: " + (calculator.CurrentValue == expected));

			calculator.Undo();
			expected *= 10;
			Console.WriteLine("Value is " + calculator.CurrentValue + " - Command correct: " + (calculator.CurrentValue == expected));
			
			calculator.Undo();
			expected /= 5;
			Console.WriteLine("Value is " + calculator.CurrentValue + " - Command correct: " + (calculator.CurrentValue == expected));

			calculator.Undo();
			expected += 5;
			Console.WriteLine("Value is " + calculator.CurrentValue + " - Command correct: " + (calculator.CurrentValue == expected));
						
			calculator.Undo();
			expected -= 10;
			Console.WriteLine("Value is " + calculator.CurrentValue + " - Command correct: " + (calculator.CurrentValue == expected));
		}

    }
}
