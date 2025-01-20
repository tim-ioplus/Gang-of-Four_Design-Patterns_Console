Class MyLogger
	Implements IMyLogger

	Dim NextLogger As IMyLogger

	Public Sub New()
	End Sub

	Public Function Handle(level As MyLogLevel, message As String) Implements IMyLogger.Handle
		If NextLogger Is Nothing Then
			NextLogger = New ConsoleLogger()
		End If

		Return NextLogger.Handle(level, message)

	End Function

End Class