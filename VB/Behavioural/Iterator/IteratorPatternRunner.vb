Imports System.Threading

Public Class IteratorPatternRunner

	Friend Sub Run()

		Console.WriteLine("Iterator Pattern")

		Console.WriteLine("Number Iterator - Fibunacci:")
		Dim fibunacciIterator As FibunacciIterator = New FibunacciIterator(1000)
		While fibunacciIterator.HasNext()
			Dim f As UInteger = fibunacciIterator.GetNext()
			Console.WriteLine(f)

			Thread.Sleep(250)
		End While

		Console.WriteLine("Collection Iterator - Months:")
		Dim monthIterator As MonthIterator = New MonthIterator()
		While monthIterator.HasNext()
			Dim m = monthIterator.GetNext()
			Console.WriteLine(m)

			Thread.Sleep(100)
		End While

	End Sub
End Class

Interface INumberIterator
	Function HasNext() As Boolean
	Function GetNext() As Integer
End Interface

Interface ICollectionIterator
	Function HasNext() As Boolean
	Function GetNext() As String
End Interface


Friend Class FibunacciIterator
	Implements INumberIterator

	Private _a As Integer
	Private _b As Integer
	Private _max As Integer

	Sub New(ByVal max As Integer)
		_a = 0
		_b = 1
		_max = max
	End Sub

	Public Function HasNext() As Boolean Implements INumberIterator.HasNext
		If _a + _b < _max Then
			Return True
		Else
			Return False
		End If
	End Function

	Public Function GetNext() As Integer Implements INumberIterator.GetNext
		Dim c = _a + _b
		_a = _b
		_b = c

		Return c
	End Function

End Class

Friend Class MonthIterator
	Implements ICollectionIterator

	Private _index As Integer
	Private _months As List(Of String)

	Public Sub New()
		_index = 0
		_months = New List(Of String)
		_months.AddRange({"Januar", "Februar", "März", "April", "Mai", "Juni",
						 "Juli", "August", "September", "Oktober", "November", "Dezember"})

	End Sub

	Public Function HasNext() As Boolean Implements ICollectionIterator.HasNext
		Return _months.Count > _index
	End Function

	Public Function GetNext() As String Implements ICollectionIterator.GetNext
		Dim x As String = _months.ElementAt(_index)
		_index += 1

		Return x
	End Function
End Class
