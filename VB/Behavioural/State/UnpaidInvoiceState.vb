
Friend Class UnpaidInvoiceState
	Implements IPaymentState

	Sub New()

	End Sub
	Public Function Pay(number As Integer) As Boolean Implements IPaymentState.Pay
		Console.WriteLine("Invoice Num: " + number.ToString() + " - " + "Pay")
		Return True
	End Function

	Public Function Cancel(number As Integer) As Boolean Implements IPaymentState.Cancel
		Console.WriteLine("Invoice Num: " + number.ToString() + " - " + "Cancel")
		Return True
	End Function

	Public Function Refund(number As Integer) As Boolean Implements IPaymentState.Refund
		Console.WriteLine("Invoice Num: " + number.ToString() + " - " + "Cant Refund")
		Return False
	End Function

	Public Overrides Function ToString() As String Implements IPaymentState.ToString
		Return "Unpaid"
	End Function
End Class


