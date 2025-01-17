namespace Pattern.Structural.Facade
{
	public static partial class FacadePatternRunner
    {
		public interface IWeatherServiceFacade
        {
            double GetCurrentTemperatureByCity(string city);
        }
    }
}
