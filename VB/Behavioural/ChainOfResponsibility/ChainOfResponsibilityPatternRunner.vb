Friend Class ChainOfResponsibilityPatternRunner
	' Logger mit 3 absteigenedem Levekls: INfo, Warn, Error
	' Jedes Level hat eine eigene Klasse, die von der abstrakten Klasse Logger erbt
	' Die Klasse Logger hat eine Methode logMessage, die von den Unterklassen überschrieben wird
	' Die Klasse Logger hat eine Methode setNextLogger, die die nächste Logger-Klasse setzt
	' Die Klasse Logger hat eine Methode logMessage, die die Nachricht an die nächste Logger-Klasse weiterleitet

	Friend Sub Run()
		Dim logger As IMyLogger = New MyLogger()

		logger.Handle(MyLogLevel.Info, "Info message")
		logger.Handle(MyLogLevel.Warn, "Warn message")
		logger.Handle(MyLogLevel.Critical, "Critical message")

	End Sub

End Class