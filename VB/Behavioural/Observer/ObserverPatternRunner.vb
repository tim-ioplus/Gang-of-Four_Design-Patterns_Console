Imports System.Net.Http
Imports System.Threading

Public Class ObserverPatternRunner
	Public Sub Run()

		Dim observer = New Observer
		Dim rs = New ReasonSubscriber(observer)
		observer.Subscribe(rs)
		Dim ms = New MagicSubscriber(observer)
		observer.Subscribe(ms)

		rs.Send("Its raining.. clouds are full of water")
		ms.Send("Its raining.. the gods are sad with our ways")

	End Sub
End Class

Public Class Observer

	Private _subscribers As List(Of ISubscriber)
	Public Sub New()
		_subscribers = New List(Of ISubscriber)
	End Sub

	Public Sub Subscribe(subscriber As ISubscriber)
		If Not _subscribers.Contains(subscriber) Then
			_subscribers.Add(subscriber)
		End If
	End Sub

	Public Sub Unscubscribe(subscriber As ISubscriber)
		If _subscribers.Contains(subscriber) Then
			_subscribers.Remove(subscriber)
		End If
	End Sub

	Public Sub Publish(sender As ISubscriber, message As String)
		Dim receivers = New List(Of ISubscriber)

		For Each subscriber In _subscribers
			If Not subscriber.Equals(sender) Then
				receivers.Add(subscriber)
			End If
		Next

		For Each receiver In receivers
			receiver.Receive(message)
		Next
	End Sub

End Class

Public Interface ISubscriber
	Sub Send(message As String)
	Sub Receive(message As String)
End Interface

Public Class Subscriber
	Implements ISubscriber

	Private _name As String
	Private _observer As Observer

	Public Sub New(name As String, observer As Observer)
		_name = name
		_observer = observer
	End Sub
	Public Sub Send(message As String) Implements ISubscriber.Send
		Console.WriteLine(_name + " sends: " + message)
		_observer.Publish(Me, message)
	End Sub

	Public Sub Receive(message As String) Implements ISubscriber.Receive
		Console.WriteLine(_name + " received: " + message)
	End Sub
End Class


Public Class ReasonSubscriber : Inherits Subscriber

	Public Sub New(observer As Observer)
		MyBase.New("Reason", observer)
	End Sub

End Class

Public Class MagicSubscriber : Inherits Subscriber

	Public Sub New(observer As Observer)
		MyBase.New("Magic", observer)
	End Sub

End Class