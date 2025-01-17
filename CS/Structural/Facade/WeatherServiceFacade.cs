namespace Pattern.Structural.Facade
{
	public static partial class FacadePatternRunner
    {
		public class WeatherServiceFacade : IWeatherServiceFacade
		{
            private readonly GeoLookupService _geoLookupService;
            private readonly WeatherService _wheatherService;
            private readonly ConverterService _converterService;

            public WeatherServiceFacade()
            {
                _geoLookupService = new GeoLookupService();
                _wheatherService = new WeatherService();
                _converterService = new ConverterService();                
            }

			public double GetCurrentTemperatureByCity(string city)
			{
                double temperature = 0.0;
                var cityLocation = _geoLookupService.GetLocation(city);
                var temperatureInCelsius = _wheatherService.GetCurrentTemperatureInCelsius(cityLocation);
                temperature = _converterService.CelsiusToFahrenheit(temperatureInCelsius);

                return temperature;
			}
		}
    }
}
