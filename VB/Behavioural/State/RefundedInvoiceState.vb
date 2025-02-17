



Friend Class RefundedInvoiceState
	Implements IPaymentState

	Sub New()

	End Sub
	Public Function Pay(number As Integer) As Boolean Implements IPaymentState.Pay
		Console.WriteLine("Invoice Num: " + number.ToString() + " - " + "Cant Pay")
		Return False
	End Function

	Public Function Cancel(number As Integer) As Boolean Implements IPaymentState.Cancel
		Console.WriteLine("Invoice Num: " + number.ToString() + " - " + "Cant Cancel")
		Return False
	End Function

	Public Function Refund(number As Integer) As Boolean Implements IPaymentState.Refund
		Console.WriteLine("Invoice Num: " + number.ToString() + " - " + "Cant Refund")
		Return False
	End Function

	Public Overrides Function ToString() As String Implements IPaymentState.ToString
		Return "Refunded"
	End Function

End Class


