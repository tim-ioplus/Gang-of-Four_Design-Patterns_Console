Friend Class EMailLogger
	Implements IMyLogger

	Dim NextLogger As IMyLogger

	Public Sub New()
	End Sub
	Friend Sub Handle(level As MyLogLevel, message As String) Implements IMyLogger.Handle
		If level = MyLogLevel.Critical Then
			Console.WriteLine("Email - Critical: " + message)
		Else
			If NextLogger Is Nothing Then
				NextLogger = New EMailLogger()
			End If

			NextLogger.Handle(level, message)
		End If
	End Sub

End Class
