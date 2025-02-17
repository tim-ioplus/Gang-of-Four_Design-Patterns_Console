Imports System.Threading

Namespace Pattern.Creational.Singleton

End Namespace
Friend Class Singleton

	Private Shared _instance As Singleton

	Private _instanceCount As Integer
	Private _guid As String = ""

	Private Sub New()
		_instanceCount = 0
		_guid = Guid.NewGuid().ToString()
	End Sub

	Public Shared Function GetInstance() As Singleton
		If _instance Is Nothing Then
			_instance = New Singleton()
		End If

		_instance._instanceCount += 1

		Return _instance
	End Function
	Public Shadows Function ToString() As String
		Return ("I am Singleton " + _guid + " - # " + _instanceCount.ToString())
	End Function

	Public Function WriteFile(ByVal path As String) As Boolean
		If _instanceCount = 1 Then
			Console.WriteLine("Writing file to: " + path)
			Thread.Sleep(1250)
			Console.WriteLine("File written to: " + path)

			Return True
		Else
			Console.WriteLine("No 2nd INstance allowed")

			Return False
		End If
	End Function


	Public Function Destroy() As Boolean
		If _instance IsNot Nothing Then
			_instance = Nothing
			_instanceCount = 0
			Return True
		Else
			Return False
		End If
	End Function

End Class
