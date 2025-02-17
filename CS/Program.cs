// See https://aka.ms/new-console-template for more information

// Design Patterns
// 
// 1. Kapselung: zusammengehörende Objekt-Daten/Eigenschafen/Methoden bleiben in einer Klasse
// 2. Abstraktion: versteckt Implementierungsdetails, die aufrufende Logic (client) kann sich auf das wesentliche konzentrieren
// 3. Vererbung: hirarchische bezoehungen zw Objekten um diese zu organisieren, wiederzuverwerten
// 4. Polymorphism: objekte als Interfaces zu verarbeiten ereinfacht es deren Arbeitsweise anzupassen
// 

using Pattern.Creational.Builder;
using Pattern.Creational.Factory;
using Pattern.Creational.Prototype;
using Pattern.Creational.Singleton;


using Pattern.Behavioural.ChainOfResponsibility;
using Pattern.Behavioural.Iterator;
using Pattern.Behavioural.Mediator;
using Pattern.Behavioural.Memento;
using Pattern.Behavioural.Observer;
using Pattern.Behavioural.State;
using Pattern.Behavioural.Strategy;
using Pattern.Behavioural.Template;
using Pattern.Behavioural.Visitor;

using Pattern.Structural.Adapter;
using Pattern.Structural.Bridge;
using Pattern.Structural.Composite;
using Pattern.Structural.Decorator;
using Pattern.Structural.Facade;
using Pattern.Structural.Flyweight;
using Pattern.Structural.Proxy;
using Pattern.Behavioural.Command;


//goto builder;
//goto factory;
//goto singleton;

//goto proxy;
//goto flyweight;
//goto facade;
//goto decorator;
//goto composite;
//goto bridge;
//goto adapter;
//goto chainofresponsibility;
//goto command;
//goto iterator;
//goto mediator;
//goto memento;
//goto observer;
//goto state;
goto strategy;
//goto templatemethod;
//goto visitor;


//
// 1. Creational Design Pattern
//

//
// 1.1 Builder 
// 
// Struktur um Eigenschaften eines Objekts schrittweise füllen 
// 1. wenn Eigenschaften voneinander abhängig sind zB Haus: Bauplan > Wände > Dach
// 2. ein Workflow wenn Schritt (n) von vorherigen Schritten (n-1) abhängig sind
// 

builder:
BuilderPatternRunner.Run();
//goto endof;

// 
// 1.2 Factory
// 
// Mechanismus um das Schreiben von allgemeinerem Verhalten zu ermöglichen. Eine konkrete Instanzierung und damit das
// spezielleres Verhalten wird erst zur Laufzeit entschieden.
// Objekterzeugung wird gekapselt, alle Objekte der Factory leiten sich von einem Interface ab, 
// der aufrufende Code (client) wird gg das Interface programmiert
// 

factory:
FactoryPatternRunner.Run();


//
// 1.3 Prototype
//
// Von einem zu kopierenden Objekt kann nicht immer auf alle
// Eigenschaften zugegriffen werden, zb weil sie private sind. Daher Kopiervorgang im Objekt selbst durchführen.
// Neben dem normalen Konstruktur mit Method Overloading einen weiteren Konstruktur erstellen
// der das Objekt selbst annimmt und in das neue Objekt die Werte des übergebenden Objekts schreibt
// Für häufig kopierte Objekt kann eine PrototypeRegistry angelegt werden, die Objekte zwischenspeichert und
// auf Anfrage einen Klon erstellt und ausgibt.
// 

protoype:
PrototypePatternRunner.Run();

// 
// 1.4 Singleton
//
// Möglichkeit mehrfache Instanzierung einer Klasse zu verhindern um threadweiten, gleichzeitigen Zugriff auf Resourcen
// zu verhindern. 
// Es wird von einer Klasse nur eine Instanz erlaubt und bei erneutem Aufruf immer Diese zurückgegeben.
// Der eigentliche konstruktor ist privat und gekapelt von der Logik die prüft ob bereits instanziert wurde.
//

singleton:
SingletonPatternRunner.Run();

//
// 2. Strukturpattern
// 

//
// 2.1 Adapter Pattern
//
// Möglichkeit um neue Funktionen an bestehende Abhängigkeiten zu implementieren und im client code weiterhin
// die alte Klasse zu verwenden.
// Die Adapterklasse leitet sich von Basisklasse *und* einem neuem Interface ab und stellt gleiche Api zur Verfügung
// wie die Basisklasse.
// 

adapter:
AdapterPatternRunner.Run();


//
// 2.2 Bridge
//
// Die Objekt stellt Funktionen zur Verfügung indem es unterschiedliche Varianten eines anderen Objekts 
// aufnehmen kann auf das es angewiesen ist.
// zb  beim Export oder Konvertieren unterschiedlicher Geschäftsobjekte in unterschiedliche Formate.
//

bridge:
BridgePatternRunner.Run();


//
// 2.3 Composite
// 
// Ermöglicht eine Menge von Einzelobjekten und deren Untermenge gleich zu behandeln um so gemeinsame Eigenschaften
// leichter und übersichtlicher zu verarbeiten
// 

composite:
CompositePatternRunner.Run();


//
// 2.4 Decorator
// Ermöglicht das Verhalten eines Objekts zu verändern ohne die ursprüngliche Implementieurng zu ändern
// Ermöglicht weiteres Verhalten um die Kernfunktion "herum-zu-wrappen", zB:
// 1. [Api aufrufen] => 2. [[Api aufrufen], [Ergebnis Loggen]] => 3. [[Api Aufrufen], [Laufzeit loggen]]
//

decorator:
await DecoratorPatternRunner.Run();
goto endof;

//
// 2.5 Facade
// ermöglicht ein Subsystem zu definieren mit klar abgegrenzten Verantwortlichkeiten und Schnittstellen.
// Abhängigkeiten können dann innerhalb des Subsystems weggekapselt werden ohne
// das der aufrufende Code (Client) darauf achten müsste.
// zB. um redundante oder mehrfach Datenhaltung abzukapseln
//

facade:
FacadePatternRunner.Run();

//
// 2.7 Flyweight
// Wenn eine Menge ähnlicher oder gleicher Objekte die gleichen Eigenschaften hat können sie sich mit dem Flyweight Pattern
// Daten teilen um den gesamten Speicherverbrauch zu reduzieren
// 
// ZB einzelzeichen in einem Texteditor: jedes Zeichen hat eine Schriftart, Farbe, Stil, Größe
//

flyweight:
FlyweightPatternRunner.Run();
goto endof;


//
// 2.6 Proxy
//
// das Proxy Pattern ermöglicht es mit einem Objekt eine Steuerung eines dahinter liegendes Objekts (oder mehrerer Objekte) zu ermöglichen
// und zu ergänzen ohne das zu steuerende Objekt freizugeben oder zu verändern.
// 
// zb. Proxy Server: anfragen an einen server werden mit eingeschränkten rechten, funktionen , vershcleierten IPs etc an den eigentlichen Srv weitergegeben
// zb. Proxy/cache klasse: daten aus Anfrageergebnissen werden zwischengespeichert und bei erneuter Anfrage direkt aus dem Caxhce geladen
//

proxy:
ProxyPatternRunner.Run();
goto endof;


//
// 3. Verhaltensmuster
// 

// 
// 3.1 Chain of Responsibility
//
// Struktur um sequentielle Abläufe von Logiken zu steuern und komponieren 
//

chainofresponsibility:
ChainOfResponsibilityRunner.Run();
goto endof;

// 
// 3.2 Command 
//
// Schnittstelle bei der ein Objekt seinen Zustand einem extern definierten Kommando mitgeben kann
// und das Ergebnis des Kommandos wieder in seinem Zustand aufnimmt.
// Kommandos können mit einer Inversen Operation versehen werden und so rückgängig gemacht werden
// Mit einem Kommando-Stack können die zustandversänderungen komplett nachvollzogen werden
//

command:
CommandPatternRunner.Run();
goto endof;


//
// 3.3 Iterator
// Struktur um eine Menge von Daten durchzulaufen ohne
// - das zugrunde liegende containerobjekt zu verwenden oder zu kennen
// - die Menge der daten zu kennen
//
iterator:
IteratorPatternRunner.Run();
goto endof;

// 3.4 Mediator 
// 
// Struktur um Objekte miteinander interagieren, kommunizieren zu lassen ohne sie direkt aufzurufen
// - Kommunikation zwischen GUI Elementen um Eingaben und Änderungen der Zustände zu kommunizieren
// - Chatsysteme
// 

mediator:
MediatorPatternRunner.Run();
goto endof;


// 3.5 Memento
//
// Zwischenspeichern eines Objektzustands um darauf folgende Änderungen wieder rückgängig machen zu können.
// - Texteditor > Text, Formatierungen
// - Grafikbearbeitung > Objekte, Pixel, Farbe
//

memento:
MementoPatternRunner.Run();
goto endof;


// 3.6 Observer
// 
// ein objekt kann anderen Objekten seine Veränderungen mitteilen diese können darauf reagieren.
// - Ereignisse in gui Elementen
// -- Workflow schritte wenn zb. die Oberflächen des nächsten (n+1)-ten Schritts von der Auswahl im aktuellen n-ten Schritt abhängen 
// - Publish und Subscribe Dienste 
// -- Handelsplatformen die auf ereignisse zb preisänderungen reagieren
// - Dienst um Fehlermeldungen einzusammeln und and die richtigen empfänger zu verteilen
// 

observer:
ObserverPatternRunner.Run();
// goto endof;


//
// 3.7 State
// Definiert die unterschiedlichen Zustände eines Objekts und welches Verhalten in diesen Zuständen
// möglich oder nicht möglich ist.
// 

state:
StatePatternRunner.Run();


//
// 3.8 Strategy
// unterschiedliche Algorithmen können konfiguriert werden um ein Ziel zu erreichen
// - text Mining unterschiedliche Arten der Textverabreitung können zum Ziel führen
// - Normalisierungen von Texten (Zeichen löschen, ersetzen)
// 

strategy:
StrategyPatternRunner.Run();

goto endof;

//
// 3.9 Template Method
// verwendet eine basisklasse um eine grundlegenden Ablauf festzulegen 
// und ermöglicht in Subklassen die genaue Implementierung der einzelnen Schritte festzulegen
// 
templatemethod:
TemplateMethodPatternRunner.Run();

//
// 3.10 Visitor
// 
// 

visitor:
VisitorPatternRunner.Run();

//
//
endof:
Console.WriteLine("endof");