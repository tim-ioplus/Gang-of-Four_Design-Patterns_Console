Friend MustInherit Class StrategyBase
	Implements IStrategy

	Private _name As String
	Public Output As String

	Friend _input As String
	Friend _output As String
	Friend _charToExtract As Char

	Friend Sub New(ByVal input As String, ByVal charToExtract As Char)
		_input = input
		_charToExtract = charToExtract
	End Sub

	Friend Property Name As String Implements IStrategy.Name
		Get
			Return _name
		End Get
		Set(value As String)
			_name = value
		End Set
	End Property

	Friend MustOverride Sub Execute() Implements IStrategy.Execute

	Friend Function GetOutput() As String Implements IStrategy.GetOutput
		Return _output
	End Function
End Class
