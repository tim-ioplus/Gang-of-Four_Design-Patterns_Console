// See https://aka.ms/new-console-template for more information

// Design Patterns
// 
// 1. Kapselung: zusammengehörende Objekt-Daten/Eigenschafen/Methoden bleiben in einer Klasse
// 2. Abstraktion: versteckt Implementierungsdetails, die aufrufende Logic (client) kann sich auf das wesentliche konzentrieren
// 3. Vererbung: hirarchische bezoehungen zw Objekten um diese zu organisieren, wiederzuverwerten
// 4. Polymorphism: objekte als Interfaces zu verarbeiten ereinfacht es deren Arbeitsweise anzupassen
// 
public class ScienceLandingPageBuilder : ILandingPageBuilder
{
	LandingPage _landingPage = new LandingPage();

	public void BuildHeader()
	{
		_landingPage.Title = "Hey there! its superscience";
		_landingPage.HeroImage = "Venera VI";
		_landingPage.Description = "The unforgetable picture by the forgotten probe.";
	}

	public void BuildLinks()
	{
		_landingPage.Topics.Add("Probes in our solar system");
		_landingPage.Topics.Add("Mars orbiting Satellites ");
	}

	public void BuildFooter()
	{
		_landingPage.Footer = "More Services, Contact, Legal, Imprint";
	}

	public LandingPage GetLandingPage()
	{
		return _landingPage;
	}
}