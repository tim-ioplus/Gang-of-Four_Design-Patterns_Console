Imports System.ComponentModel.Design
Imports System.Globalization
Imports System.Threading

Public Class MediatorPatternRunner
	Public Sub Run()
		Dim mediator = New Mediator
		Dim komOne = New Communicator("Kom One", mediator)
		mediator.RegisterCommunicator(komOne)
		Dim komTwo = New Communicator("Kom Two", mediator)
		mediator.RegisterCommunicator(komTwo)

		komOne.Send("Hallo.. jemand Data?")
		komTwo.Send("Ja hier komTwo.. wer dort?")
		komOne.Send("Hier komOne. Over.")

	End Sub
End Class
Public Class Mediator

	Private _communicators As List(Of Communicator)

	Public Sub New()
		_communicators = New List(Of Communicator)
	End Sub

	Public Sub RegisterCommunicator(newCommunicator As Communicator)
		_communicators.Add(newCommunicator)
	End Sub

	Public Sub UnRegisterCommunicator(oldCommunicator As Communicator)
		_communicators.Remove(oldCommunicator)
	End Sub

	Public Sub Mediate(communicator As Communicator, message As String)

		Dim receivers As List(Of Communicator)
		receivers = _communicators.FindAll(Function(c As Communicator)
											   Return c.Name IsNot communicator.Name
										   End Function)

		If receivers IsNot Nothing And receivers.Count > 0 Then
			For Each receiver In receivers
				receiver.Receive(message)
			Next
		Else
			Console.WriteLine("receivers unidentified. Message lost: " + message)
		End If
	End Sub

End Class

Public Class Communicator

	Public Name As String
	Private _mediator As Mediator
	Private _messagesSend As List(Of String)
	Private _messagesReceived As List(Of String)

	Public Sub New(name As String, mediator As Mediator)
		Me.Name = name
		_mediator = mediator

		_messagesSend = New List(Of String)
		_messagesReceived = New List(Of String)
	End Sub

	Public Sub Send(message As String)
		Console.WriteLine(Me.Name + " sends: " + message)
		_mediator.Mediate(Me, message)
		_messagesSend.Add(message)
	End Sub

	Public Sub Receive(message As String)
		Console.WriteLine(Me.Name + " received: " + message)
		_messagesReceived.Add(message)
	End Sub

	Public Overrides Function ToString() As String
		Return Me.Name
	End Function

End Class
