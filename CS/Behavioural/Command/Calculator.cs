namespace Pattern.Behavioural.Command
{
	internal static partial class CommandPatternRunner
	{
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

    }
}
