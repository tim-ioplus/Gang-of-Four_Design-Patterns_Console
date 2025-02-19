Imports System.Text

Public Class FactoryPatternRunner

	Public Sub Run()

		Console.WriteLine("Factory Pattern..")

		Dim products = New List(Of IProduct)
		Dim factory As New Factory()
		Dim random As New Random()


		For i As Integer = 0 To 10
			Dim type As String = ""
			If random.NextDouble() < 0.5 Then
				type = "A"
			Else
				type = "B"
			End If

			Dim product As IProduct = factory.CreateProduct(type)
			If product IsNot Nothing Then
				products.Add(product)
			End If
		Next

		Dim sbProductTypes As New StringBuilder
		For Each product In products
			sbProductTypes.Append(product.ToString)
		Next

		Console.WriteLine("Products factoried: {0}", sbProductTypes.ToString)

	End Sub

End Class
