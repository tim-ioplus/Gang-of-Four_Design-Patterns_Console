Public Class PrototypePatternRunner
	Public Sub New()
	End Sub

	Public Function Run()
		Console.WriteLine("Prototype Pattern..")

		Dim original As ConcretePrototype = New ConcretePrototype("Ada Lovelace", 1)
		Console.WriteLine("original:")
		Console.WriteLine(original.ToString())

		Dim clone As ConcretePrototype = original.Clone()
		Console.WriteLine("cloned:")
		Console.WriteLine(clone.ToString())

		clone.Name = "Max Schmeling"
		clone.Number = 2
		Console.WriteLine("cloned modified:")
		Console.WriteLine(clone.ToString())


	End Function
End Class
