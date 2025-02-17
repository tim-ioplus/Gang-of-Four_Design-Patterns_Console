Friend Class Calculator

	Public Value As Double
	Private _commands As Stack(Of ICommand)

	Sub New()
		Value = 0
		_commands = New Stack(Of ICommand)
	End Sub

	Public Sub DoCommand(command As ICommand)
		Value = command.DoCommand(Value)
		_commands.Push(command)
	End Sub

	Public Sub UndoCommand()
		Dim command = _commands.Pop
		Value = command.UndoCommand(Value)
	End Sub

	Public Sub Reset()
		Value = 0
		_commands.Clear()
	End Sub

End Class
