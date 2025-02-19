Friend Class Factory
	Public Sub New()
	End Sub

	Friend Function CreateProduct(v As String) As IProduct
		If v = "A" Then
			Return New ProductA()
		ElseIf v = "B" Then
			Return New ProductB()
		Else
			Return Nothing
		End If
	End Function
End Class

Friend Class ProductA
	Implements IProduct

	Public Sub New()
	End Sub

	Public Overrides Function ToString() As String
		Return "A"
	End Function
End Class

Friend Class ProductB
	Implements IProduct

	Public Sub New()
	End Sub

	Public Overrides Function ToString() As String
		Return "B"
	End Function
End Class


