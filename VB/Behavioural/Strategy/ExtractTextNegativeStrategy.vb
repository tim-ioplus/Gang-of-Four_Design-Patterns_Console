Imports System.Text

Friend Class ExtractTextNegativeStrategy
	Inherits StrategyBase

	Public Sub New(input As String, charToExtract As Char)
		MyBase.New(input, charToExtract)

		Name = "ExtractTextNegativeStrategy"
	End Sub

	Friend Overrides Sub Execute()
		Dim sb As New StringBuilder()
		For Each c As Char In _input
			If c <> _charToExtract Then

			Else
				sb.Append(c)
			End If
		Next

		_output = sb.ToString()
	End Sub

End Class