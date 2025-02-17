namespace Pattern.Behavioural.Command
{
	internal static partial class CommandPatternRunner
	{
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

    }
}
