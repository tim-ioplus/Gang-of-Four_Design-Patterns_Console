Namespace Pattern.Creational.Singleton
End Namespace

Public Class SingletonPatternRunner
	Public Sub New()
	End Sub

	Public Sub Run()

		Console.WriteLine("Singleton Pattern..")

		Dim s1 As Singleton = Singleton.GetInstance()
		Console.WriteLine(s1.ToString())
		Dim s1Written As Boolean = s1.WriteFile("/my/path/to/some/where")

		Dim s2 As Singleton = Singleton.GetInstance()
		Console.WriteLine(s2.ToString())
		Dim s2Written As Boolean = s2.WriteFile("my/path/to/some/where/else")

		If Not s2Written Then
			s2.Destroy()
		End If

		s2 = Singleton.GetInstance()
		If Not s2 Is Nothing Then
			Console.WriteLine(s2.ToString())
			s2Written = s2.WriteFile("my/path/to/some/where/else")
		End If

	End Sub

End Class
