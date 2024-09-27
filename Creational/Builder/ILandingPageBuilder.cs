// See https://aka.ms/new-console-template for more information

public interface ILandingPageBuilder
{
	public void BuildHeader();
	public void BuildLinks();
	public void BuildFooter();
	LandingPage GetLandingPage();
}
