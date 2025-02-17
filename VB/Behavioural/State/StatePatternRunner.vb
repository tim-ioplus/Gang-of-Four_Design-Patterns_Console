Public Class StatePatternRunner

	Public Sub Run()

		Dim invoice1 = New Invoice(241, 59.99)
		invoice1.Pay()
		invoice1.Cancel()
		invoice1.Refund()

		Dim invoice2 = New Invoice(242, 12457.54)
		invoice2.Pay()
		invoice2.Refund()
		invoice2.Cancel()

		Dim invoice3 = New Invoice(243, 390.9)
		invoice3.Refund()
		invoice3.Cancel()
		invoice3.Pay()

		Dim invoice4 = New Invoice(244, 1999.99)
		invoice4.Refund()
		invoice4.Cancel()
		invoice4.Pay()

	End Sub

End Class