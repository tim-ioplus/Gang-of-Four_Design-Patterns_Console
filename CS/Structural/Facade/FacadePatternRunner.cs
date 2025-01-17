using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Structural.Facade
{
	public static partial class FacadePatternRunner
    {
        public static void Run()
        {
            Console.WriteLine("Facade Pattern: Get Temperature for a location name");
            var weatherServiceFacade = new WeatherServiceFacade();

            string city = "cologne";
            var temperature = weatherServiceFacade.GetCurrentTemperatureByCity(city);
            Console.WriteLine("It is " + temperature + " degrees in " + city);

            city = "hamburg";
            temperature = weatherServiceFacade.GetCurrentTemperatureByCity(city);
            Console.WriteLine("It is " + temperature + " degrees in " + city);

            city = "calgary";
            temperature = weatherServiceFacade.GetCurrentTemperatureByCity(city);
            Console.WriteLine("It is " + temperature + " degrees in " + city);
        }
    }
}
