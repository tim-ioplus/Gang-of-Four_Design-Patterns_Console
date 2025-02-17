Friend Class Invoice
	Implements IInvoice

	Dim Number As Integer
	Dim Amount As Decimal
	Dim State As IPaymentState

	Sub New(number As Integer, amout As Decimal)
		Me.Number = number
		Me.Amount = Amount
		Me.State = New UnpaidInvoiceState()
	End Sub

	Public Sub Pay() Implements IInvoice.Pay
		Dim result As Boolean = State.Pay(Me.Number)
		If result = True Then
			State = New PaidInvoiceState()
			Console.WriteLine("Invoice Num: " + Me.Number.ToString() + " - " + State.ToString())
		End If

	End Sub

	Public Sub Cancel() Implements IInvoice.Cancel
		Dim result As Boolean = State.Cancel(Me.Number)
		If result = True Then
			State = New CancelledInvoiceState()
			Console.WriteLine("Invoice Num:" + Me.Number.ToString() + " - " + State.ToString())
		End If

	End Sub

	Public Sub Refund() Implements IInvoice.Refund
		Dim result As Boolean = State.Refund(Me.Number)
		If result = True Then
			State = New CancelledInvoiceState()
			Console.WriteLine("Invoice Num:" + Me.Number.ToString() + " - " + State.ToString())
		End If

	End Sub
End Class


