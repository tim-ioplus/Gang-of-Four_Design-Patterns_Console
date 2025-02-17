Public Class CommandPatternRunner
	Public Sub Run()
		Console.WriteLine("Command Pattern..")
		Dim calculator = New Calculator()

		Dim addFive = New AddCommand(5)
		Dim addOne = New AddCommand(1)
		Dim subtractFour = New SubtractCommand(4)
		Dim multipleByTen = New MultiplyCommand(10)
		Dim divideByThree = New DivideCommand(3)
		Dim expected As Double = 0

		calculator.DoCommand(addFive)
		CheckExpected(5, calculator.Value)

		calculator.DoCommand(addOne)
		CheckExpected(6, calculator.Value)

		calculator.UndoCommand()
		CheckExpected(5, calculator.Value)

		calculator.DoCommand(subtractFour)
		CheckExpected(1, calculator.Value)

		calculator.UndoCommand()
		CheckExpected(5, calculator.Value)

		calculator.DoCommand(addFive)
		CheckExpected(10, calculator.Value)

		calculator.DoCommand(multipleByTen)
		CheckExpected(100, calculator.Value)

		calculator.DoCommand(multipleByTen)
		CheckExpected(1000, calculator.Value)

		calculator.UndoCommand()
		CheckExpected(100, calculator.Value)

		calculator.DoCommand(addFive)
		CheckExpected(105, calculator.Value)

		calculator.DoCommand(divideByThree)
		CheckExpected(35, calculator.Value)

		calculator.UndoCommand()
		CheckExpected(105, calculator.Value)

		calculator.Reset()
		CheckExpected(0, calculator.Value)
	End Sub

	Private Sub CheckExpected(expected As Double, value As Double)
		Dim assertEquals As Boolean = expected.Equals(value)
		Console.WriteLine("Value " + value.ToString + " - correct: " + assertEquals.ToString)
	End Sub

End Class
