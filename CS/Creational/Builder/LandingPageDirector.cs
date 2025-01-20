public class LandingPageDirector
{
	public void Construct(List<ILandingPageBuilder> landingPageBuilders)
	{
		foreach(var landingPageBuilder in landingPageBuilders)
		{
			Construct(landingPageBuilder);
		}
	}
	public void Construct(ILandingPageBuilder landingPageBuilder)
	{
		landingPageBuilder.BuildHeader();
		landingPageBuilder.BuildLinks();
		landingPageBuilder.BuildFooter();
	}

	public void Show(List<ILandingPageBuilder> landingPageBuilder)
	{
		int count = 0;
		foreach(var builder in landingPageBuilder)
		{
			Show(builder, ++count);
		}
	}
	public void Show(ILandingPageBuilder landingPageBuilder, int count)
	{
		var currentPage = landingPageBuilder.GetLandingPage();
		Console.WriteLine("--" + " Show Page: " + count + "---");
		Console.WriteLine(currentPage.ToString());
	}
}
