Public Class StrategyPatternRunner
	Friend Sub Run()
		Dim input As String
		Dim charToExtract As Char

		input = "DE3327050399"
		charToExtract = "3"c

		Dim extractPositiveStrategy As IStrategy = New ExtractTextPositiveStrategy(input, charToExtract)
		Dim extractNegativeStrategy As IStrategy = New ExtractTextNegativeStrategy(input, charToExtract)

		Dim strategies As List(Of IStrategy) = New List(Of IStrategy)()

		strategies.Add(extractPositiveStrategy)
		strategies.Add(extractNegativeStrategy)

		For Each strategy As IStrategy In strategies
			strategy.Execute()
			Console.WriteLine(strategy.Name + ": " + strategy.GetOutout())
		Next

	End Sub

End Class