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

Interface IInvoice
	Sub Pay()
	Sub Cancel()
	Sub Refund()

End Interface
Interface IPaymentState
	Function Pay() As Boolean
	Function Cancel() As Boolean
	Function Refund() As Boolean
	Function ToString() As String
End Interface

Friend Class UnpaidInvoiceState
	Implements IPaymentState

	Sub New()

	End Sub
	Public Function Pay() As Boolean Implements IPaymentState.Pay
		Return True
	End Function

	Public Function Cancel() As Boolean Implements IPaymentState.Cancel
		Return True
	End Function

	Public Function Refund() As Boolean Implements IPaymentState.Refund
		Return False
	End Function

	Private Function ToString() As String Implements IPaymentState.ToString
		Return "Unpaid"
	End Function
End Class

Friend Class PaidInvoiceState
	Implements IPaymentState

	Sub New()

	End Sub
	Public Function Pay() As Boolean Implements IPaymentState.Pay
		Return False
	End Function

	Public Function Cancel() As Boolean Implements IPaymentState.Cancel
		Return False
	End Function

	Public Function Refund() As Boolean Implements IPaymentState.Refund
		Return True
	End Function

	Private Function ToString() As String Implements IPaymentState.ToString
		Return "Paid"
	End Function

End Class

Friend Class CancelledInvoiceState
	Implements IPaymentState

	Sub New()

	End Sub
	Public Function Pay() As Boolean Implements IPaymentState.Pay
		Return False
	End Function

	Public Function Cancel() As Boolean Implements IPaymentState.Cancel
		Return False
	End Function

	Public Function Refund() As Boolean Implements IPaymentState.Refund
		Return False
	End Function

	Private Function ToString() As String Implements IPaymentState.ToString
		Return "Cancelled"
	End Function
End Class

Friend Class RefundedInvoiceState
	Implements IPaymentState

	Sub New()

	End Sub
	Public Function Pay() As Boolean Implements IPaymentState.Pay
		Return False
	End Function

	Public Function Cancel() As Boolean Implements IPaymentState.Cancel
		Return False
	End Function

	Public Function Refund() As Boolean Implements IPaymentState.Refund
		Return False
	End Function

	Private Function ToString() As String Implements IPaymentState.ToString
		Return "Refunded"
	End Function

End Class

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
		Dim result As Boolean = State.Pay()
		If result = True Then
			State = New PaidInvoiceState()
			Console.WriteLine("Invoice Num:" + Me.Number.ToString() + " : " + State.ToString())
		End If

	End Sub

	Public Sub Cancel() Implements IInvoice.Cancel
		Dim result As Boolean = State.Cancel()
		If result = True Then
			State = New CancelledInvoiceState()
			Console.WriteLine("Invoice Num:" + Me.Number.ToString() + " : " + State.ToString())
		End If

	End Sub

	Public Sub Refund() Implements IInvoice.Refund
		Dim result As Boolean = State.Refund()
		If result = True Then
			State = New CancelledInvoiceState()
			Console.WriteLine("Invoice Num" + Me.Number.ToString() + " : " + State.ToString())
		End If

	End Sub
End Class


