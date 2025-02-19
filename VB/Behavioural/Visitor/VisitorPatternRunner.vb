Public Class VisitorPatternRunner
	Public Sub Run()
		Dim employeeJJ = New SalesEmployee("Justus Jonas", 75000, 25000)
		Dim employeePS = New SalesEmployee("Peter Shaw", 60199, 12500)
		Dim employeeBA = New BackOfficeEmployee("Bob Andrews", 57600, 10750)

		Dim specialEmployees As New List(Of IVisitable) From {
			employeeJJ,
			employeePS,
			employeeBA
		}

		For Each specialEmployee In specialEmployees
			Dim compensationCalculator = New CalculateTotalCompensationVisitor
			specialEmployee.Accept(compensationCalculator)
			Dim baseEmployee = TryCast(specialEmployee, Employee)

			If baseEmployee IsNot Nothing Then
				Console.WriteLine($"Total Compensation For {baseEmployee.Name} : {compensationCalculator.TotalCompensation} EUR")
			End If
		Next

	End Sub

	Friend Interface IVisitor
		Sub Visit(employee As BackOfficeEmployee)
		Sub Visit(employee As SalesEmployee)
	End Interface
	Friend Interface IVisitable
		Sub Accept(visitor As IVisitor)
	End Interface
	Friend Class Employee
		Public Name As String
		Public Salary As Decimal

		Public Sub New(name As String, salary As Decimal)
			Me.Name = name
			Me.Salary = salary
		End Sub
	End Class


	Friend Class BackOfficeEmployee : Inherits Employee
		Implements IVisitable

		Friend Bonus As Decimal = 12500
		Public Sub New(name As String, salary As Decimal, bonus As Decimal)
			MyBase.New(name, salary)
			Me.Bonus = bonus
		End Sub

		Public Sub Accept(visitor As IVisitor) Implements IVisitable.Accept
			visitor.Visit(Me)
		End Sub
	End Class
	Friend Class SalesEmployee : Inherits Employee
		Implements IVisitable

		Friend Commissions As Decimal = 12500
		Public Sub New(name As String, salary As Decimal, commissions As Decimal)
			MyBase.New(name, salary)
			Me.Commissions = commissions
		End Sub

		Public Sub Accept(visitor As IVisitor) Implements IVisitable.Accept
			visitor.Visit(Me)
		End Sub
	End Class

	Friend Class CalculateTotalCompensationVisitor
		Implements IVisitor

		Private _totalCompensation As Decimal
		Friend ReadOnly Property TotalCompensation() As Decimal
			Get
				Return _totalCompensation
			End Get
		End Property

		Public Sub Visit(employee As BackOfficeEmployee) Implements IVisitor.Visit
			_totalCompensation = employee.Salary + employee.Bonus
		End Sub

		Public Sub Visit(employee As SalesEmployee) Implements IVisitor.Visit
			_totalCompensation = employee.Salary + employee.Commissions
		End Sub
	End Class

End Class