namespace Pattern.Structural.Facade
{
	public static partial class FacadePatternRunner
    {
		public class GeoLookupService
        {
            public Location GetLocation(string city)
            {
                return new Location(15.12345, 23.8745);
            }
        }
    }
}
