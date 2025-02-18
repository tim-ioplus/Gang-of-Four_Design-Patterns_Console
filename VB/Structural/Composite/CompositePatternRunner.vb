Public Class CompositePatternRunner
	Public Sub Run()
		Console.WriteLine("Composite Pattern..")

		Dim tireParts = New List(Of Composite)
		Dim tireVL = New Composite("Tire VL", 1, 250)
		tireParts.Add(tireVL)
		Dim tireVR = New Composite("Tire VR", 1, 250)
		tireParts.Add(tireVR)
		Dim tireHR = New Composite("Tire HR", 1, 250)
		tireParts.Add(tireHR)
		Dim tireHL = New Composite("Tire HL", 1, 250)
		tireParts.Add(tireHL)
		Dim tireScrews = New Composite("Tire Screws", 20, 4.99)
		tireParts.Add(tireScrews)

		Dim tires = New Assembly("Tires", tireParts)


		Dim frontSeats = New List(Of Composite)
		Dim seatVL = New Composite("Seat VL - Driver", 1, 629.99)
		frontSeats.Add(seatVL)
		Dim seatVR = New Composite("Seat VR - Shotgun", 1, 549.99)
		frontSeats.Add(seatVR)
		Dim heatingUnits = New Composite("Heating Units", 2, 299.79)
		frontSeats.Add(heatingUnits)
		Dim screws = New Composite("Screws", 120, 0.59)
		frontSeats.Add(screws)

		Dim seats = New Assembly("Front Seats", frontSeats)

		Dim allParts = New List(Of Assembly)
		allParts.Add(tires)
		allParts.Add(seats)

		Dim totalCost As Decimal = 0
		For Each partAssembly In allParts
			totalCost += partAssembly.GetCost
		Next

		Console.WriteLine("Auto kostet {0} EUR", totalCost)

	End Sub


	Private Interface IComposite
		Function GetCost() As Decimal
	End Interface

	Private Class Composite
		Implements IComposite

		Public Name As String
		Private _amount As Integer
		Private _cost As Decimal

		Public Sub New(name As String, amount As Integer, cost As Decimal)
			Me.Name = name
			_amount = amount
			_cost = cost
		End Sub
		Public Function GetCost() As Decimal Implements IComposite.GetCost
			Return _amount * _cost
		End Function
	End Class

	Private Class Assembly
		Implements IComposite

		Public Name As String
		Private _components As List(Of Composite)

		Public Sub New(name As String, components As List(Of Composite))
			Me.Name = name
			_components = components
		End Sub
		Public Function GetCost() As Decimal Implements IComposite.GetCost
			Dim sum As Decimal = 0

			For Each comp In _components
				sum += comp.GetCost
			Next

			Return sum
		End Function
	End Class

End Class