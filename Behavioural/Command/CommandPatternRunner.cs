using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Behavioural.Command
{
	internal static class CommandPatternRunner
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

		internal class Calculator
		{
			public double CurrentValue {get; private set; }
			private Stack<ICommand> stack = new Stack<ICommand>();
			public Calculator() 
			{
				CurrentValue = 0;
			}

			public void Do(ICommand command)
			{
				CurrentValue = command.Do(CurrentValue);
				stack.Push(command);
			}

			public void Undo()
			{
				var lastCommand = stack.Pop();
				CurrentValue = lastCommand.Undo(CurrentValue);
			}

		}

		internal interface ICommand
		{
			double Do(double currentValue);
			double Undo(double currentValue);
		}
        internal class AddCommand : ICommand
        {
			private readonly double _commandValue = 0;

			public AddCommand(double commandValue)
			{
				_commandValue = commandValue;
			}

			public double Do(double currentValue) => currentValue += _commandValue;
			public double Undo(double currentValue) => currentValue -= _commandValue;
		}

		internal class SubtractCommand : ICommand
        {
			private readonly double _commandValue = 0;

			public SubtractCommand(double commandValue)
			{
				_commandValue = commandValue;
			}

			public double Do(double currentValue) => currentValue -= _commandValue;
			public double Undo(double currentValue) => currentValue += _commandValue;
		}

		internal class MultiplyCommand : ICommand
        {
			private readonly double _commandValue = 0;

			public MultiplyCommand(double commandValue)
			{
				_commandValue = commandValue;
			}

			public double Do(double currentValue) => currentValue *= _commandValue;
			public double Undo(double currentValue) => currentValue /= _commandValue;
		}
		internal class DivideCommand : ICommand
        {
			private readonly double _commandValue = 0;

			public DivideCommand(double commandValue)
			{
				_commandValue = commandValue;
			}

			public double Do(double currentValue) => currentValue /= _commandValue;
			public double Undo(double currentValue) => currentValue *= _commandValue;
		}

    }
}
