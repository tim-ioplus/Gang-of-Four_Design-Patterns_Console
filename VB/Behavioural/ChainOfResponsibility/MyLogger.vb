Class MyLogger
	Implements IMyLogger

	Dim NextLogger As IMyLogger

	Public Sub New()
	End Sub

	Friend Sub Handle(level As MyLogLevel, message As String) Implements IMyLogger.Handle
		If NextLogger Is Nothing Then
			NextLogger = New ConsoleLogger()
		End If

		NextLogger.Handle(level, message)

	End Sub

End Class