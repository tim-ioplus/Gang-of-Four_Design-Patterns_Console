Imports System.Threading

Module Module1

	Sub Main()

		'1. Strukturmuster

		'Dim singletonPatternRunner As New SingletonPatternRunner()
		'singletonPatternRunner.Run()

		'Dim factoryPatternRunner As New FactoryPatternRunner()
		'factoryPatternRunner.Run()

		'Dim prototypePatternRunner As New PrototypePatternRunner()
		'prototypePatternRunner.Run()

		'Dim builderPatternRunner As New BuilderPatternRunner()
		'builderPatternRunner.Run()

		' 3. Verhaltensmuster 

		'Dim chainOfResponsibilityPatternRunner As New ChainOfResponsibilityPatternRunner()
		'chainOfResponsibilityPatternRunner.Run()

		' 3.x Strategy
		Dim strategyPatternRunner As New StrategyPatternRunner()
		strategyPatternRunner.Run()

		Console.WriteLine("exit in 10 secs")
		Thread.Sleep(10000)

	End Sub

End Module
