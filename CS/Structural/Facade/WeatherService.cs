namespace Pattern.Structural.Facade
{
	public static partial class FacadePatternRunner
    {
		public class WeatherService()
        {
            public double GetCurrentTemperatureInCelsius(Location location) => new Random().Next(-20,40);
        }
    }
}
