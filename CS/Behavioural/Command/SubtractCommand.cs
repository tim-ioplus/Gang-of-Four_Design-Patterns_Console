namespace Pattern.Behavioural.Command
{
	internal static partial class CommandPatternRunner
	{
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

    }
}
