Friend Class SubtractCommand
	Implements ICommand

	Private _commandValue As Double
	Sub New(commandValue As Double)
		_commandValue = commandValue
	End Sub
	Public Function DoCommand(currentValue As Double) As Double Implements ICommand.DoCommand
		Return currentValue - _commandValue
	End Function

	Public Function UndoCommand(currentValue As Double) As Double Implements ICommand.UndoCommand
		Return currentValue + _commandValue
	End Function
End Class
