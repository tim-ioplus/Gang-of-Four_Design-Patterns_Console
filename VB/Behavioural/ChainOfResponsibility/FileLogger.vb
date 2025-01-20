Friend Class FileLogger
	Implements IMyLogger

	Dim NextLogger As IMyLogger

	Public Sub New()
	End Sub
	Friend Sub Handle(level As MyLogLevel, message As String) Implements IMyLogger.Handle
		If level = MyLogLevel.Warn Then
			Console.WriteLine("File - Warn: " + message)
		Else
			If NextLogger Is Nothing Then
				NextLogger = New EMailLogger()
			End If

			NextLogger.Handle(level, message)
		End If
	End Sub

End Class
