Imports System.Security.Cryptography

Public Class FacadePatternRunner
	Public Sub Run()
		Console.WriteLine("Facade Pattern:")

		Dim weatherServiceFacade = New WeatherServiceFacade()

		Dim city = "cologne"
		Dim weatherK = weatherServiceFacade.GetWeatherByCity(city)
		Console.WriteLine(weatherK.ToString)

		city = "hamburg"
		Dim weatherHH = weatherServiceFacade.GetWeatherByCity(city)
		Console.WriteLine(weatherHH.ToString)

		city = "calgary"
		Dim weatherC = weatherServiceFacade.GetWeatherByCity(city)
		Console.WriteLine(weatherC.ToString)

	End Sub


	Friend Class Weather
		Friend Location As Location
		Friend Temperature As Temperature
		Friend Clouds As String
		Friend Wind As String

		Public Overrides Function ToString() As String
			Return String.Format("{0} {1} {2} {3} ",
								 Me.Location.ToString, Me.Temperature.ToString, Me.Clouds, Me.Wind)
		End Function
	End Class

	Friend Class Location
		Friend Name As String
		Friend Longitude As Double
		Friend Latitude As Double

		Friend Sub New(name As String, longitude As Double, latitude As Double)
			Me.Name = name
			Me.Longitude = longitude
			Me.Latitude = latitude
		End Sub

		Public Overrides Function ToString() As String
			Return String.Format("{0} {1} {2}", Me.Name, Me.Latitude, Me.Longitude)
		End Function
	End Class
	Friend Class Temperature
		Friend Value As Double
		Friend Unit As TemperatureUnit
		Friend ReadOnly Property UnitAsString As String
			Get
				If (Me.Unit.Equals(TemperatureUnit.Celsius)) Then
					Return "Celsius"
				ElseIf (Me.Unit.Equals(TemperatureUnit.Fahrenheit)) Then
					Return "Fahrenheit"
				ElseIf (Me.Unit.Equals(TemperatureUnit.Kelvin)) Then
					Return "Kelvin"
				Else
					Return "None"
				End If
			End Get
		End Property

		Public Overrides Function ToString() As String
			Return String.Format("{0} {1} ", Me.Value, Me.UnitAsString)
		End Function

	End Class

	Friend Enum TemperatureUnit
		None = 0
		Celsius = 1
		Fahrenheit = 2
		Kelvin = 3
	End Enum

	Friend Class WeatherServiceFacade

		Private _locationService As LocationService
		Private _temperatureService As TemperatureService
		Private _cloudService As CloudService
		Private _windService As WindService

		Public Sub New()
			_locationService = New LocationService
			_temperatureService = New TemperatureService
			_cloudService = New CloudService
			_windService = New WindService
		End Sub

		Friend Function GetWeatherByCity(cityName As String) As Weather
			Dim weather = New Weather

			weather.Location = _locationService.Get(cityName)
			weather.Temperature = _temperatureService.Get(weather.Location)
			weather.Clouds = _cloudService.Get(weather.Location)
			weather.Wind = _windService.Get(weather.Location)

			Return weather
		End Function
	End Class
	Friend Interface IWindService
		Function [Get](location As Location) As String
	End Interface
	Friend Class WindService
		Implements IWindService

		Public Function [Get](location As Location) As String Implements IWindService.Get
			If location.Name = "cologne" Then
				Return "Windstill"
			ElseIf location.Name = "hamburg" Then
				Return "Steife Brise"
			ElseIf location.Name = "calgary" Then
				Return "Leichte Brise"
			Else
				Return "Sturm"
			End If
		End Function
	End Class

	Friend Interface ICloudService
		Function [Get](location As Location) As String
	End Interface
	Friend Class CloudService
		Implements ICloudService

		Public Function [Get](location As Location) As String Implements ICloudService.Get
			If location.Name = "cologne" Then
				Return "Wolkenfrei"
			ElseIf location.Name = "hamburg" Then
				Return "Diesig"
			ElseIf location.Name = "calgary" Then
				Return "Leicht bewölkt"
			Else
				Return "Stark bewölkt"
			End If
		End Function
	End Class

	Friend Interface ITemperatureService
		Function [Get](location As Location) As Temperature
	End Interface
	Friend Class TemperatureService
		Implements ITemperatureService

		Private _unitConversionService As UnitConversionService
		Private _temperaturesByLatitude As Dictionary(Of Integer, Decimal)
		Private _temperaturesByLongitude As Dictionary(Of Integer, Decimal)

		Friend Sub New()
			_unitConversionService = New UnitConversionService
			_temperaturesByLatitude = FillTemperature()
			_temperaturesByLongitude = FillTemperature()
		End Sub

		Private Function FillTemperature() As Dictionary(Of Integer, Decimal)
			Dim dict = New Dictionary(Of Integer, Decimal)

			Dim randomiser = New Random()
			For i As Integer = 1 To 180
				Dim firstPart As Double = randomiser.Next(-50, 50)
				Dim secondPart As Double = randomiser.NextDouble()
				Dim temperatureAsDouble = firstPart + secondPart
				Dim temperature = New Decimal(temperatureAsDouble)
				dict.Add(i, temperature)
			Next

			Return dict
		End Function

		Public Function [Get](location As Location) As Temperature Implements ITemperatureService.Get
			Dim temperature = New Temperature

			Dim simpleLatitude As Integer = Integer.Parse(Math.Floor(location.Latitude).ToString)
			Dim simpleLongitude As Integer = Integer.Parse(Math.Floor(location.Longitude).ToString)

			Dim temperatureByLatitude = (From tl In _temperaturesByLatitude Where tl.Key = simpleLatitude Take 1).FirstOrDefault().Value
			Dim temperatureByLongitude = (From tl In _temperaturesByLongitude Where tl.Key = simpleLongitude Take 1).FirstOrDefault().Value

			temperature.Value = (temperatureByLatitude + temperatureByLongitude) / 2
			temperature.Unit = _unitConversionService.GetTemperatureUnitByLocation(location)

			Return temperature
		End Function
	End Class

	Friend Interface IUnitConversionService
		Function GetTemperatureUnitByLocation(location As Location) As TemperatureUnit
		Function GetTemperatureUnitByLocationName(locationName As String) As TemperatureUnit
	End Interface

	Friend Class UnitConversionService
		Implements IUnitConversionService

		Public Function GetTemperatureUnitByLocation(location As Location) As TemperatureUnit Implements IUnitConversionService.GetTemperatureUnitByLocation
			Return GetTemperatureUnitByLocationName(location.Name)
		End Function

		Public Function GetTemperatureUnitByLocationName(locationName As String) As TemperatureUnit Implements IUnitConversionService.GetTemperatureUnitByLocationName
			If locationName = "cologne" Or
			   locationName = "hamburg" Then
				Return TemperatureUnit.Celsius
			ElseIf locationName = "calgary" Then
				Return TemperatureUnit.Fahrenheit
			ElseIf locationName = "sun" Then
				Return TemperatureUnit.Kelvin
			Else
				Return TemperatureUnit.None
			End If
		End Function
	End Class

	Friend Interface ILocationService
		Function [Get](locationName As String) As Location
	End Interface
	Friend Class LocationService
		Implements ILocationService

		Private _locations As Dictionary(Of String, Location)

		Public Sub New()
			_locations = New Dictionary(Of String, Location)
			_locations.Add("cologne", New Location("cologne", 11.11, 11.11))
			_locations.Add("hamburg", New Location("hamburg", 12.2, 8.07))
			_locations.Add("calgary", New Location("calgary", 177.45, 6.31))
		End Sub

		Public Function [Get](locationName As String) As Location Implements ILocationService.Get
			Dim location As Location = Nothing

			If _locations.TryGetValue(locationName, location) Then
				Return location
			End If

			Return Nothing

		End Function
	End Class
End Class


