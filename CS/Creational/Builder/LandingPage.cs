public class LandingPage
{
	public string Title { get; set; }
	public string HeroImage { get; set; }
	public string Description { get; set; }
	public List<string> Topics = new List<string>();
	public string Footer { get; set; }

	public string ToString()
	{
		return Title + " - " + HeroImage + " - " + Description + " - " + string.Concat(Topics) + " - " + Footer;
	}
}
