Public Class MementoPatternRunner

	Public Sub Run()
		Console.WriteLine("Memento Pattern...")

		Dim currentPixelValue As Integer = 0
		Dim expectedValue As Integer = 0
		' neues Bitmap: 2d arr decimal
		Dim editor = New BitmapEditor(5, 5)
		' init mit mit Helligkeitswerten 0-255
		editor.InitGradient()
		currentPixelValue = editor.GetValue(0, 0)
		expectedValue = 128
		CheckValues(currentPixelValue, expectedValue)
		' 10pkt heller machen
		editor.Brighter(10)
		currentPixelValue = editor.GetValue(0, 0)
		expectedValue = 138
		CheckValues(currentPixelValue, expectedValue)
		' 10pkt heller machen 
		editor.Brighter(10)
		currentPixelValue = editor.GetValue(0, 0)
		expectedValue = 148
		CheckValues(currentPixelValue, expectedValue)
		' 5pkt dunkler machen
		editor.Darker(5)
		currentPixelValue = editor.GetValue(0, 0)
		expectedValue = 143
		CheckValues(currentPixelValue, expectedValue)
		' zurücksetzen
		editor.Undo()
		currentPixelValue = editor.GetValue(0, 0)
		expectedValue = 148
		CheckValues(currentPixelValue, expectedValue)
		'
		editor.Undo()
		currentPixelValue = editor.GetValue(0, 0)
		expectedValue = 138
		CheckValues(currentPixelValue, expectedValue)
		'
		editor.Undo()
		currentPixelValue = editor.GetValue(0, 0)
		expectedValue = 128
		CheckValues(currentPixelValue, expectedValue)

	End Sub

	Private Sub CheckValues(current As Integer, expected As Integer)
		Dim areEqual As Boolean = current.Equals(expected)

		Dim areEqualText = String.Format("{0} And {1} Are ", current, expected)
		If areEqual Then
			areEqualText += " Equal "
		Else
			areEqualText += " Not Equal "
		End If

		Console.WriteLine(areEqualText)
	End Sub
End Class

Public Class Bitmap
	Dim _pixels(,) As Integer
	Dim _width As Integer = 0
	Dim _height As Integer = 0
	Public Sub New(ByVal width As Integer, ByVal height As Integer)
		_width = width
		_height = height
		ReDim _pixels(width - 1, height - 1)
	End Sub

	Public Function GetValue(x As Integer, y As Integer) As Integer
		If x <= _width And y <= _height Then
			Return _pixels(x, y)
		End If

		Return Nothing
	End Function

	Public Sub SetValue(x As Integer, y As Integer, value As Integer)
		_pixels(x, y) = value
	End Sub

	Public Sub SetValues(ByVal newValues As Integer(,))
		Array.Copy(newValues, Me._pixels, Me._pixels.Length)
	End Sub

	Public Function Clone() As Bitmap
		Dim copy As New Bitmap(Me._width, Me._height)
		copy.SetValues(Me._pixels)

		Return copy
	End Function


End Class
Public Class BitmapEditor

	Dim _bitmap As Bitmap
	Dim _history As History

	Public Sub New(width As Integer, height As Integer)
		_bitmap = New Bitmap(width, height)
		_history = New History
	End Sub

	Public Sub Restore(newBitmap As Bitmap)
		_bitmap = newBitmap
	End Sub

	Public Function GetValue(i As Integer, j As Integer) As Integer
		Return _bitmap.GetValue(i, j)
	End Function

	Public Sub InitGradient()
		Save()

		For i As Integer = 0 To 4
			For j As Integer = 0 To 4
				Dim count = (i + j)
				Dim brightness = 128 + count

				_bitmap.SetValue(i, j, brightness)
			Next
		Next

	End Sub

	Public Sub Brighter(increaseValue As Integer)
		Save()

		For i As Integer = 0 To 4
			For j As Integer = 0 To 4
				Dim value = _bitmap.GetValue(i, j)
				value += increaseValue
				_bitmap.SetValue(i, j, value)
			Next
		Next

	End Sub

	Public Sub Darker(decreaseValue As Integer)
		Save()

		For i As Integer = 0 To 4
			For j As Integer = 0 To 4
				Dim value = _bitmap.GetValue(i, j)
				value -= decreaseValue
				_bitmap.SetValue(i, j, value)
			Next
		Next

	End Sub

	Public Sub Save()
		Dim cloneToSave = _bitmap.Clone
		_history.Save(cloneToSave)
	End Sub

	Public Sub Undo()
		Dim lastMemento As Memento = _history.Undo

		If lastMemento IsNot Nothing Then
			Dim lastState = TryCast(lastMemento.State, Bitmap)
			If lastState IsNot Nothing Then
				Restore(lastState)
			End If
		End If

	End Sub

End Class

Public Class History
	Dim _history As Stack(Of Memento)

	Public Sub New()
		_history = New Stack(Of Memento)
	End Sub

	Public Sub Save(ByVal state As Object)
		_history.Push(New Memento(state))
	End Sub

	Public Function Undo() As Memento
		If _history.Count > 0 Then
			Return _history.Pop
		End If

		Return Nothing
	End Function

End Class

Public Class Memento
	Public State As Object

	Public Sub New(ByVal state As Object)
		Me.State = state
	End Sub
End Class
