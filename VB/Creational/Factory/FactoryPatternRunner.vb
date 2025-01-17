Public Class FactoryPatternRunner

	Public Sub Run()

		Console.WriteLine("Factory Pattern..")

		Dim factory As New Factory()
		Dim random As New Random()

		For i As Integer = 0 To 10
			Dim type As String = ""
			If random.Next(0, 2) < 1 Then
				type = "A"
			Else
				type = "B"
			End If

			Dim product As IProduct = factory.CreateProduct(type)

			If Not product Is Nothing Then
				Console.WriteLine(product.ToString())
			End If

		Next

	End Sub

End Class
