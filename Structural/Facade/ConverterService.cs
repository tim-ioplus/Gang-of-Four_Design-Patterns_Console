namespace Pattern.Structural.Facade
{
	public static partial class FacadePatternRunner
    {
		public class ConverterService
        {
            public double CelsiusToFahrenheit(double celsius) => (9/5 * celsius) + 32;
            public double FahrenheitToCelsius(double fahrenheit) => (fahrenheit-32) * 5/9; 
        }
    }
}
