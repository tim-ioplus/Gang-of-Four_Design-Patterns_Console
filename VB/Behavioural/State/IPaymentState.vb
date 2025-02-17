Interface IPaymentState
	Function Pay(number As Integer) As Boolean
	Function Cancel(number As Integer) As Boolean
	Function Refund(number As Integer) As Boolean
	Function ToString() As String
End Interface


