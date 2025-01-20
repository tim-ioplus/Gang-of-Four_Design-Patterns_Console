Class ConsoleLogger
	Implements IMyLogger

	Dim NextLogger As IMyLogger

	Public Sub New()
	End Sub
	Friend Sub Handle(level As MyLogLevel, message As String) Implements IMyLogger.Handle
		If level = MyLogLevel.Info Then
			Console.WriteLine("Console - Info: " + message)
		Else
			If NextLogger Is Nothing Then
				NextLogger = New FileLogger()
			End If

			NextLogger.Handle(level, message)

		End If
	End Sub
End Class