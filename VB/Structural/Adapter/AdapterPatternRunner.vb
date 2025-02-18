Imports System.Threading

Public Class AdapterPatternRunner
	Public Sub Run()
		Console.WriteLine("Adapter Pattern:")

		Dim transactionOne = New Transaction("Alan Turing", "DE331230451265987451", 9000)
		Dim transactionTwo = New Transaction("Noam Chomsky", "NL451212457897454444", 12000)

		Console.WriteLine("Old & Slow ")
		Dim processed = New PaymentProcessor().Process(transactionOne)
		Console.WriteLine("New & Fast - aber mit Client Änderung")
		processed = New LightningPaymentProcessor().MakePayment(transactionOne)

		Console.WriteLine("")
		Console.WriteLine("New & fast & ohne Client Änderung via Adapter")
		Dim adapter = New PaymentProcessingAdapter()
		adapter.Process(transactionOne)
		adapter.Process(transactionTwo)

	End Sub
End Class

Public Interface IPaymentProcessor
	Function Process(transaction As Transaction) As Boolean
End Interface

Public Interface ILightningPaymentProcessor
	Function MakePayment(transaction As Transaction) As Boolean
End Interface


Public Class PaymentProcessor
	Implements IPaymentProcessor

	Private processingTimeInMs As Integer = 3500

	Public Function Process(transaction As Transaction) As Boolean Implements IPaymentProcessor.Process
		Console.WriteLine("Transaction Processing : " + transaction.ToString)
		Thread.Sleep(processingTimeInMs)
		Console.WriteLine(String.Format("Transaction Processed  : {0} - in {1} ms", transaction.ToString, Me.processingTimeInMs))

		Return True
	End Function
End Class

Public Class LightningPaymentProcessor
	Implements ILightningPaymentProcessor

	Private processingTimeInMs As Integer = 1050
	Public Function MakePayment(transaction As Transaction) As Boolean Implements ILightningPaymentProcessor.MakePayment
		Console.WriteLine("Transaction Processing : " + transaction.ToString)
		Thread.Sleep(processingTimeInMs)
		Console.WriteLine(String.Format("Transaction Processed  : {0} - in {1} ms", transaction.ToString, Me.processingTimeInMs))

		Return True
	End Function
End Class

Public Class PaymentProcessingAdapter : Inherits LightningPaymentProcessor
	Implements IPaymentProcessor

	Public Function Process(transaction As Transaction) As Boolean Implements IPaymentProcessor.Process
		Return Me.MakePayment(transaction)
	End Function
End Class

Public Class Transaction
	Public ReceiverName As String
	Public ReceiverIban As String
	Public Amount As Integer

	Public Sub New(receiverName As String, receiverIban As String, amount As Integer)
		Me.ReceiverName = receiverName
		Me.ReceiverIban = receiverIban
		Me.Amount = amount
	End Sub

	Public Overrides Function ToString() As String
		Return String.Format("{0} - {1} - {2} EUR", Me.ReceiverName, Me.ReceiverIban, Me.Amount)
	End Function

End Class
