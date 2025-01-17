Imports System.Net.Mime

Class ConcretePrototype
	Implements IPrototype

	Public Name As String
	Public Number As Integer
	Private Guid As String

	Public Sub New(name As String, number As Integer)
		Me.Name = name
		Me.Number = number
		Me.Guid = System.Guid.NewGuid().ToString()
	End Sub

	Public Overrides Function ToString() As String
		Return ("I am Prototype " + Guid + " - " + Name + " - # " + Number.ToString())
	End Function

	Public Function Clone() As IPrototype Implements IPrototype.Clone
		Return Me.MemberwiseClone()
	End Function
End Class
