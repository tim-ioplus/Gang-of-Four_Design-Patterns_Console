// See https://aka.ms/new-console-template for more information

// Design Patterns
// 
// 1. Kapselung: zusammengehörende Objekt-Daten/Eigenschafen/Methoden bleiben in einer Klasse
// 2. Abstraktion: versteckt Implementierungsdetails, die aufrufende Logic (client) kann sich auf das wesentliche konzentrieren
// 3. Vererbung: hirarchische bezoehungen zw Objekten um diese zu organisieren, wiederzuverwerten
// 4. Polymorphism: objekte als Interfaces zu verarbeiten ereinfacht es deren Arbeitsweise anzupassen
// 


using Pattern.Behavioural;
using Pattern.Behavioural.ChainOfResponsibility;
using Pattern.Behavioural.Iterator;
using Pattern.Behavioural.Mediator;
using Pattern.Behavioural.Memento;
using Pattern.Behavioural.NewFolder;
using Pattern.Behavioural.State;
using Pattern.Behavioural.Strategy;
using Pattern.Behavioural.Template;
using Pattern.Behavioural.Visitor;
using Pattern.Creational.Builder;
using Pattern.Creational.Factory;
using Pattern.Creational.Prototype;
using Pattern.Creational.Singleton;
using Pattern.Structural.Adapter;
using Pattern.Structural.Bridge;
using Pattern.Structural.Composite;
using Pattern.Structural.Decorator;
using Pattern.Structural.Facade;
using Pattern.Structural.Flyweight;
using Pattern.Structural.Proxy;
using System.Linq.Expressions;
using System.Reflection;

//goto singleton;
//goto factory;
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
//goto strategy;
//goto templatemethod;
//goto visitor;

//
// 1. Creational Design Pattern

// 1.1 Singleton
// Möglichkeit mehrfache Instanzierung einer Klasse zu verhindern um threadweiten, gleichzeitigen Zugriff auf Resourcen zu verhindern. 
// Es wird von einer Klasse nur eine Instanz erlaubt und bei erneutem Aufruf immer Diese zurückgegeben.
// Der eigentliche konstruktor ist privat und ist gekapelt von der Logik die prüft ob bereits instanziert wurde.

singleton:
SingletonPatternRunner.Run();

// 
// 1.2 Factory
// 
// Mechanismus um eine konkrete Instanzierung erst zur Laufzeit entscheiden zu können, um
// 1. unterschiedliche Varianten eines Geschäftsobjekts zu verarbeiten
// 2. zB unterschiedliche Varianten von Oberflächen zu laden 
// <?>3. Frodcntpage onlineshop mit vielen unterschiedlichen Produkten: wählen erstma</?>
// Objekterzeugung wird gekapselt, alle Objekte der Factory leiten sich von einem Interface ab, 
// der aufrufende Code (client) wird auf das Interface 
// 
// productfactory die ProdA, ProB von IProd erzeugt

factory:
FactoryPatternRunner.Run();

//
// 1.3 Builder 
// 
// Struktur um Eigenschaften eins Objekts schrittweise füllen 
// 1. wenn Eigenschaften voneinander abhängig sind zB Haus: Bauplan > Wände > Dach
// 2. ein Workflow wenn Schritt (n) von vorherigen Schritten (n-1) abhängig sind
// 
builder:
BuilderPatternRunner.Run();

//
// 1.4 Prototype
//
// 1) Von einem zu kopierenden Objekt kann nicht immer auf alle
// Eigenschaften zugegriffen werden. Daher Kopiervorgang im Objekt selbst durchführen.
// 2) Neben dem normalen Konstruktur mit Method Overloading einen Konstruktur erstellen
// der das Objekt selbst annimmt und in das neue Objekt die Werte des
// übergebenden Objekts schreibt
// 2b) 
// 3) Für häufig kopierte Objekt kann eine PrototypeRegistry angelegt werden
// die Objekte zweischenspeichert und auf Anfrage einen Klon erstellt und ausgibt
// 
protoype:
PrototypePatternRunner.Run();

//
// 2. Strukturpattern
// 

//
// 2.1 Adapter Pattern
// 2.1.1 Objekt Adapter
// 2.1.2 Klassen adapter
// Adapterklasse leitet sich von Basisklasse *und* neuem interface ab und 
// stellt gleiche Api zur Verfügung wie Objektadapter
adapter:
AdapterPatternRunner.Run();


//
// 2.2 Bridge
// trennt die Abstraktion eines Objekts von seiner Implementierung, so dass beide unabhängig voneinander variieren können.
// Nützlich zb bei Datenexport wo untershcliedliche Zielsysteme ZB. xml-varianten benötigen, mit der Bridge
bridge:
BridgePatternRunner.Run();

//
// 2.3 Composite
// Ermöglicht eine Menge von Enzeilobjekten und Untermenge gleich zu behandeln um so gemeinsame Eigenschaften leichter und
// übersichtlicher zu verarbeiten
// 
composite:
CompositePatternRunner.Run();

//
// 2.4 Decorator
// Ermöglicht das Verhalten eines Objekts zu verändern ohne die ursprüunglich Implementieurng zu ändern
// Ermöglicht weiteres Verhalten um die Kernfunktion "herum-zu-wrappen", zB:
// 1. [Api aufrufen] => 2. [[Api aufrufen], [Ergebnis Loggen]] => 3. [[Api Aufrufen], [Laufzeit loggen]]
decorator:
await DecoratorPatternRunner.Run();

//
// 2.5 Facade
// ermöglicht ein Subsystem zu definieren mit klar abgegrenzten Verantwortlichkeiten und Schnittstellen.
// Abhängigkeiten können dann innerhalb des Subsystems weggekapselt werden ohne
// das der aufrufende Code (Client) darauf achten müsste.
// zB. um redundante oder mehrfach Datenhaltung abzukapseln
facade:
FacadePatternRunner.Run();

//
// 2.7 Flyweight
// Wenn eine Menge ähnlicher oder gleicher Objekte die gleichen Eigenschaften hat können sie sich mit dem Flyweight Pattern
// Daten teilen um den gesamten Speicherverbrauch zu reduzieren
// 
// ZB einzelzeichen in einem Texteditor: jedes Zeichen hat eine Schriftart, Farbe, Stil, Größe

flyweight:
FlyweightPatternRunner.Run();

//
// 2.6 Proxy
// das Proxy Pattern ermöglicht es mit einem Objekt eine steuerung eines dahinter liegendes Objekts (oder mehrerer Objekte) zu ermöglichen
// und zu ergänzen ohne das zu steuerende Objekt oder freizugeben oder zu verändern.
// 
// zb. Proxy Server: anfragen an einen server werden mit eingeschränkten rechten, funktionen , vershcleierten IPs etc an den eigentlichen Srv weitergegeben
// zb. Proxy/cache klasse: daten aus Anfrageergebnissen werden zwischengespeichert und bei erneuter Anfrage direkt aus dem Caxhce geladen
proxy:
ProxyPatternRunner.Run();

//
// 3. Verhaltensmuster
// 

// 3.1 Chain of Responsibility
//
// Struktur um sequentielle Abläufe von Logiken zu steuern und komponieren
//  
//
chainofresponsibility:
ChainOfResponsibilityRunner.Run();

// 3.2 Command 
command:
CommandPatternRunner.Run();

// 3.3 Iterator
// Struktur um eine Menge von Daten durchzulaufen ohne
// - das zugrunde liegende containerobjekt zu verwenden oder zu kennen
// - die Menge der daten zu kennen
//
iterator:
IteratorPatternRunner.Run();

// 3.4 Mediator 
// 
// Struktur um Objekte miteinander interagieren, kommunizieren zu lassen ohne sie direkt aufzurufen
// - Kommunikation zwischen GUI Elemnten um Eingaben und Änderungen der Zustände zu kommunizieren
// - Chatsysteme
// 
mediator:
MediatorPatternRunner.Run();

// 3.5 Memento
//
// Zwischenspeichern eines Objektzustands um darauf folgende Änderungen wieder rückgängig machen zu können.
// - Texteditor > Text, Formatierungen
// - Grafikbearbeitung > Objekte, Pixel, Farbe
//
memento:
MementoPatternRunner.Run();

// 3.6 Observer
// 
// 
//
observer:
ObserverPatternRunner.Run();

//
// 3.7 State
// Unterschiedliche Zustände eines Objekte erlauben oder verbieten unterschiedliches Verhalten
// 
state:
StatePatternRunner.Run();


//
// 3.8 strategy
// unterschiedliche Algorithmen können konfiguriert werden um ein Ziel zu erreichen
// - ZB. Normalisierungen von Texten (Zeichen löschen, ersetzen
// 
strategy:
StrategyPatternRunner.Run();

//
// 3.9 Template Method
// verwendet eine basisklasse um eine grundlegenden Ablauf festzulegen 
// um in Subklassen die genaue Implementierung der einzelnen Schritte festzulegen
// 
templatemethod:
TemplateMethodPatternRunner.Run();

//
// 3.10 Visitor
visitor:
VisitorPatternRunner.Run();

//
//
endof:
Console.WriteLine("endof");