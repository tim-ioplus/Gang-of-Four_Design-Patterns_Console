'
' 1.3 Prototype
'
' Von einem zu kopierenden Objekt kann nicht immer auf alle
' Eigenschaften zugegriffen werden, zb weil sie private sind. Daher Kopiervorgang im Objekt selbst durchführen.
' Neben dem normalen Konstruktur mit Method Overloading einen weiteren Konstruktur erstellen
' der das Objekt selbst annimmt und in das neue Objekt die Werte des übergebenden Objekts schreibt
' Für häufig kopierte Objekt kann eine PrototypeRegistry angelegt werden, die Objekte zwischenspeichert und
' auf Anfrage einen Klon erstellt und ausgibt.
' 
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
