Imports System.Threading

Module Module1

	Sub Main()

		Dim singletonPatternRunner As New SingletonPatternRunner()
		singletonPatternRunner.Run()

		Dim factoryPatternRunner As New FactoryPatternRunner()
		factoryPatternRunner.Run()

		Dim prototypePatternRunner As New PrototypePatternRunner()
		prototypePatternRunner.Run()

		Console.WriteLine("exit in 10 secs")
		Thread.Sleep(10000)

	End Sub

End Module
