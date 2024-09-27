// See https://aka.ms/new-console-template for more information

// Design Patterns
// 
// 1. Kapselung: zusammengehörende Objekt-Daten/Eigenschafen/Methoden bleiben in einer Klasse
// 2. Abstraktion: versteckt Implementierungsdetails, die aufrufende Logic (client) kann sich auf das wesentliche konzentrieren
// 3. Vererbung: hirarchische bezoehungen zw Objekten um diese zu organisieren, wiederzuverwerten
// 4. Polymorphism: objekte als Interfaces zu verarbeiten ereinfacht es deren Arbeitsweise anzupassen
// 
public class SportsLandingPageBuilder : ILandingPageBuilder
{
	private LandingPage _landingPage = new LandingPage();
	
	public void BuildHeader()
	{
		_landingPage.Title = "Hey there its Supersports!";
		_landingPage.HeroImage = "Usain Bolt";
		_landingPage.Description = "Having a walk with the worlds fastest man.";
	}

	public void BuildLinks()
	{
		_landingPage.Topics.Add("Running faster");
		_landingPage.Topics.Add("Running longer");
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
