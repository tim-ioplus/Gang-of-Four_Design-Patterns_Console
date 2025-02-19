Public Class FlyweightPatternRunner
	Public Function Run()
		Console.WriteLine("Flyweight Pattern..")

		Dim maxWidth As Integer = 1280
		Dim maxHeight As Integer = 720
		Dim shapeCount As Integer = 1000

		Dim shapeFactory = New ShapeFactory
		Dim _shapesToCreate As New List(Of String)({"Square", "Circle"})
		Dim _colorsToUse As New List(Of String)({"Red", "Green", "Blue", "Cyan", "Magenta", "Yellow", "Black"})
		' parameter in clientcode festgelegt

		Dim randomiser = New Random
		For i As Integer = 0 To shapeCount

			Dim shapeIndex = 0
			If randomiser.NextDouble > 0.5 Then
				shapeIndex = 1
			End If

			Dim shapeToCreate = _shapesToCreate.ElementAtOrDefault(shapeIndex)
			Dim colorToUse = _colorsToUse.ElementAtOrDefault(randomiser.Next(0, _colorsToUse.Count - 1))
			' Formen werden in Factory generiert
			' nach Typ (Kreis, Qudrat) und Farben (r,g,b,c,m,y,k) gecacht
			' erst form aus cache suchen
			' ansonsten Form neu erzeugen und cachen
			Dim shapeToDraw = shapeFactory.CreateShape(shapeToCreate, colorToUse)
			' position  x/y ausserhalb factory festlegen 
			Dim shapeSize = shapeToDraw.GetSize()
			Dim xPosition = randomiser.Next(Math.Floor(shapeSize.Item1 / 2), Math.Floor(maxWidth - (shapeSize.Item1 * 2)))
			Dim yPosition = randomiser.Next(Math.Floor(shapeSize.Item2 / 2), Math.Floor(maxHeight - (shapeSize.Item2 * 2)))
			' Form 'zeichnen' form.Zeichnen(position)
			shapeToDraw.Draw(xPosition, yPosition)
		Next

		' gebrauchte Bits für alle shapes ermitteln
		Dim bitsForShapeType = 8
		Dim bitsForColor = 8
		Dim bitsByWidthRadius = 8
		Dim bitsForSingleShape = bitsForShapeType + bitsForColor + bitsByWidthRadius
		Dim bitsWithoutCache = bitsForSingleShape * shapeCount
		'
		Dim bitsForKeys = 2 * 8
		Dim cachedShapesCount = shapeFactory.GetCacheCount
		Dim bitsInCache = (cachedShapesCount * bitsForSingleShape) + bitsForKeys
		' gerauchte bits für gecachte Shapes ausrechnen
		' alle - gecachte = gesparte
		Dim bitsSaved = bitsWithoutCache - bitsInCache
		Console.WriteLine("{0} Formen mit {1} statt {2} bits gecacht: {3} bits gespart", cachedShapesCount, bitsInCache, bitsWithoutCache, bitsSaved)

	End Function

	Interface IShape
		Sub Draw(x As Integer, y As Integer)
		Function GetSize() As (Integer, Integer)

		Function Copy() As IShape
	End Interface
	Friend Class Square
		Implements IShape

		Friend width As Integer
		Friend color As String

		Public Sub New(width As Integer, color As String)
			Me.width = width
			Me.color = color
		End Sub

		Public Sub Draw(x As Integer, y As Integer) Implements IShape.Draw
			Console.WriteLine("Draw {0} Square with {1} size at {2} {3}", Me.color, Me.width, x, y)
		End Sub

		Public Function GetSize() As (Integer, Integer) Implements IShape.GetSize
			Return (Me.width, Me.width)
		End Function

		Public Function Copy() As IShape Implements IShape.Copy
			Return New Square(Me.width, Me.color)
		End Function
	End Class

	Protected Friend Class Circle
		Implements IShape

		Friend radius As Integer
		Friend color As String

		Public Sub New(radius As Integer, color As String)
			Me.radius = radius
			Me.color = color
		End Sub

		Public Sub Draw(x As Integer, y As Integer) Implements IShape.Draw
			Console.WriteLine("Draw {0} Circle with {1} size at {2} {3}", Me.color, Me.radius, x, y)
		End Sub

		Public Function GetSize() As (Integer, Integer) Implements IShape.GetSize
			Return (Me.radius * 2, Me.radius * 2)
		End Function

		Public Function Copy() As IShape Implements IShape.Copy
			Return New Circle(Me.radius, Me.color)
		End Function
	End Class

	Friend Class ShapeFactory

		Dim shapesByTypeCache As Dictionary(Of String, Dictionary(Of String, IShape))

		Public Sub New()
			shapesByTypeCache = New Dictionary(Of String, Dictionary(Of String, IShape))
		End Sub

		Friend Function CreateShape(shapeType As String, colorName As String) As IShape
			Dim cachedShape As IShape
			Dim shapetypeByColors As New Dictionary(Of String, IShape)

			If shapesByTypeCache.TryGetValue(shapeType, shapetypeByColors) AndAlso
				shapetypeByColors.TryGetValue(colorName, cachedShape) Then
				Return cachedShape.Copy
			End If

			Dim newShape As IShape

			If shapeType.Equals("Circle") Then
				newShape = New Circle(1, colorName)
			ElseIf shapeType.Equals("Square") Then
				newShape = New Square(1, colorName)
			Else
				Return Nothing
			End If

			If Not shapesByTypeCache.ContainsKey(shapeType) Then
				' Form existiert noch nicht
				Dim colorsForShapeType = New Dictionary(Of String, IShape)
				colorsForShapeType.Add(colorName, newShape)
				shapesByTypeCache.Add(shapeType, colorsForShapeType)
			Else
				' Form existiert
				shapetypeByColors = shapesByTypeCache(shapeType)
				If Not shapetypeByColors.ContainsKey(colorName) Then
					' Farbe für Form exisitert noch nicht
					shapetypeByColors.Add(colorName, newShape)
				Else
					' Farbe für Form existiert
				End If
			End If

			Return newShape

		End Function

		Public Function GetCacheCount() As Integer
			Dim count As Integer = 0

			For Each shapeCache In shapesByTypeCache
				For Each colorCache In shapeCache.Value
					count += 1
				Next
			Next

			Return count
		End Function
	End Class

End Class


