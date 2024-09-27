// See https://aka.ms/new-console-template for more information

// Design Patterns
// 
// 1. Kapselung: zusammengehörende Objekt-Daten/Eigenschafen/Methoden bleiben in einer Klasse
// 2. Abstraktion: versteckt Implementierungsdetails, die aufrufende Logic (client) kann sich auf das wesentliche konzentrieren
// 3. Vererbung: hirarchische bezoehungen zw Objekten um diese zu organisieren, wiederzuverwerten
// 4. Polymorphism: objekte als Interfaces zu verarbeiten ereinfacht es deren Arbeitsweise anzupassen
// 
public interface IPrototype
{	
	public object Clone();
}
