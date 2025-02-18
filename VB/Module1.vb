Imports System.Threading

Module Module1

	Sub Main()

		'
		'1. Erzeugungsmuster

		'Dim singletonPatternRunner As New SingletonPatternRunner()
		'singletonPatternRunner.Run()

		'Dim factoryPatternRunner As New FactoryPatternRunner()
		'factoryPatternRunner.Run()

		'Dim prototypePatternRunner As New PrototypePatternRunner()
		'prototypePatternRunner.Run()

		'Dim builderPatternRunner As New BuilderPatternRunner()
		'builderPatternRunner.Run()

		'
		'2. Strukturmuster

		'//
		'// 2.1 Adapter Pattern
		'//
		'// Möglichkeit um neue Funktionen an bestehende Abhängigkeiten zu implementieren und im client code weiterhin
		'// die alte Klasse zu verwenden.
		'// Die Adapterklasse leitet sich von Basisklasse *und* einem neuem Interface ab und stellt gleiche Api zur Verfügung
		'// wie die Basisklasse.
		'// 
		'
		'Dim adapterPatternRunner = New AdapterPatternRunner
		'adapterPatternRunner.Run()

		'2.2 Bridge
		'//
		'// 2.2 Bridge
		'//
		'// Ein Objekt stellt Funktionen zur Verfügung indem es unterschiedliche Varianten eines anderen Objekts 
		'// aufnehmen kann auf das es angewiesen ist.
		'// zb beim Export oder Konvertieren unterschiedlicher Geschäftsobjekte in unterschiedliche Formate.
		'//
		'
		'Dim bridgePatternRunner = New BridgePatternRunner
		'bridgePatternRunner.Run()

		'2.3 Composite
		'//
		'// 2.3 Composite
		'// 
		'// Ermöglicht eine Menge von Einzelobjekten und deren Untermenge gleich zu behandeln um so gemeinsame Eigenschaften
		'// leichter und übersichtlicher zu verarbeiten
		'// zb. unterschiedliche einzelne Bauteile eines Produktes
		'
		'Dim compositePatternRunner = New CompositePatternRunner
		'compositePatternRunner.Run()


		'2.4 Decorator		
		'//
		'// 2.4 Decorator
		'// Ermöglicht das Verhalten eines Objekts zu verändern ohne die ursprüngliche Implementieurng zu ändern
		'// Ermöglicht weiteres Verhalten um die Kernfunktion "herum-zu-wrappen", zB:
		'// 1. [Api aufrufen] => 2. [[Api aufrufen], [Ergebnis Loggen]] => 3. [[Api Aufrufen], [Laufzeit loggen]]
		'//
		'Dim decoratorpatternRunner = New DecoratorPatternRunner
		'decoratorpatternRunner.Run()

		'2.5 Facade
		'//
		'// 2.5 Facade
		'// ermöglicht ein Subsystem zu definieren mit klar abgegrenzten Verantwortlichkeiten und Schnittstellen.
		'// Abhängigkeiten können dann innerhalb des Subsystems weggekapselt werden ohne
		'// das der aufrufende Code (Client) darauf achten müsste.
		'// zB. um redundante oder mehrfach Datenhaltung abzukapseln
		'//
		Dim facadePatternRunner = New FacadePatternRunner
		facadePatternRunner.Run()


		'Flyweight
		'Proxy


		'
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

		'Dim mementoPatternRunner = New MementoPatternRunner
		'mementoPatternRunner.Run()

		'3.6 Observer
		' 
		' ein objekt kann anderen Objekten seine Veränderungen mitteilen diese können darauf reagieren.
		' - Ereignisse in gui Elementen
		' -- Workflow schritte wenn zb. die Oberflächen des nächsten (n+1)-ten Schritts von der Auswahl im aktuellen n-ten Schritt abhängen 
		' - Publish und Subscribe Dienste 
		' -- Handelsplatformen die auf ereignisse zb preisänderungen reagieren
		' - Dienst um Fehlermeldungen einzusammeln und And die richtigen empfänger zu verteilen
		'
		'Dim observerPatternRunner = New ObserverPatternRunner
		'observerPatternRunner.Run()

		'3.7 State 
		'Dim statePatternRunner As New StatePatternRunner()
		'StatePatternRunner.Run()

		' 3.8 Strategy
		'Dim strategyPatternRunner As New StrategyPatternRunner()
		'strategyPatternRunner.Run()

		' 3.9 Template


		' 3.10 Visitor


		'
		'
		'
		Dim secs As Integer = 15000
		Console.WriteLine($"exit in {secs / 1000} secs")
		Thread.Sleep(secs)

	End Sub

End Module
