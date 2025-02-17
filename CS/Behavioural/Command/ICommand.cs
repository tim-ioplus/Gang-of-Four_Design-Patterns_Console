namespace Pattern.Behavioural.Command
{
	internal static partial class CommandPatternRunner
	{
		internal interface ICommand
		{
			double Do(double currentValue);
			double Undo(double currentValue);
		}

    }
}
