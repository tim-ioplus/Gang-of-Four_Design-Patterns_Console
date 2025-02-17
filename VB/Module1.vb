﻿Imports System.Threading

Module Module1

	Sub Main()

		'1. Strukturmuster

		'Dim singletonPatternRunner As New SingletonPatternRunner()
		'singletonPatternRunner.Run()

		'Dim factoryPatternRunner As New FactoryPatternRunner()
		'factoryPatternRunner.Run()

		'Dim prototypePatternRunner As New PrototypePatternRunner()
		'prototypePatternRunner.Run()

		'Dim builderPatternRunner As New BuilderPatternRunner()
		'builderPatternRunner.Run()

		' 3. Verhaltensmuster 

		'Dim chainOfResponsibilityPatternRunner As New ChainOfResponsibilityPatternRunner()
		'chainOfResponsibilityPatternRunner.Run()

		' 3.2 Command
		' Einzelne atomare operationen aus den zustand eines objektes ausführen und bei Bedarf
		' wieder rückggängig machen zu können, transaktionsartig
		'Dim commandPatternRunner As New CommandPatternRunner
		'CommandPatternRunner.Run()

		'3.3 Iterator
		'
		'Dim iteratorPatternRunner As New IteratorPatternRunner()
		'IteratorPatternRunner.Run()


		' 3.4 Mediator 
		' 
		' Struktur um Objekte miteinander interagieren, kommunizieren zu lassen ohne sie direkt aufzurufen
		' - Kommunikation zwischen GUI Elemnten um Eingaben und Änderungen der Zustände zu kommunizieren
		' - Chatsysteme
		'
		'Dim mediatorPatternRunner = New MediatorPatternRunner
		'mediatorPatternRunner.Run()


		'// 3.5 Memento
		'//
		'// Zwischenspeichern eines Objektzustands um darauf folgende Änderungen wieder rückgängig machen zu können.
		'// - Texteditor > Text, Formatierungen
		'// - Grafikbearbeitung > Objekte, Pixel, Farbe
		'//

		Dim mementoPatternRunner = New MementoPatternRunner
		mementoPatternRunner.Run()

		'3. Observer


		'3.x State 
		'Dim statePatternRunner As New StatePatternRunner()
		'StatePatternRunner.Run()

		' 3.x Strategy
		'Dim strategyPatternRunner As New StrategyPatternRunner()
		'strategyPatternRunner.Run()


		Dim secs As Integer = 5000
		Console.WriteLine($"exit in {secs / 1000} secs")
		Thread.Sleep(secs)

	End Sub

End Module
