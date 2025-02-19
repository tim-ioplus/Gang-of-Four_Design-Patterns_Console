using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Behavioural.Visitor
{
	internal static class VisitorPatternRunner
	{
		public static void Run()
		{
			Console.WriteLine("Visitor Pattern Runner ..");

			var employeeJJ = new SalesEmployee("Justus Jonas", 100000, 27500);
			var employeePS = new SalesEmployee("Peter Shaw", 70000, 23250);
			var employeeBA = new BackOfficeEmployee("Bob Andrews", 75000, 21275);
			
			var specialEmployeeList = new List<IVisitableElement>(){ employeeJJ, employeePS, employeeBA };
			
			var totalCompensationVisitor = new CompensationVisitor();
			
			foreach (var specialEmployee in specialEmployeeList) 
			{
				specialEmployee.Accept(totalCompensationVisitor);
				
				var baseEmployee = (Employee) specialEmployee;
				if(baseEmployee!= null)
				{
					var specialEmployeeCompensationVisitor = new CompensationVisitor();
					specialEmployee.Accept(specialEmployeeCompensationVisitor);
					Console.WriteLine("Compensation for " + baseEmployee.Name + " is " + specialEmployeeCompensationVisitor.TotalCompensation);
				}				
			}

			Console.WriteLine("Total Compensation for " + employeeJJ.Name + ", " + employeePS.Name + ", " + employeeBA.Name + " is " + totalCompensationVisitor.TotalCompensation);
		}

		public interface IVisitableElement
		{
			void Accept(IVisitor visitor);
		}

		public interface IVisitor 
		{
			void Visit(BackOfficeEmployee e);
			void Visit(SalesEmployee e);
		}

		public class CompensationVisitor : IVisitor
		{
			public decimal TotalCompensation { get; private set; } = 0;
			public void Visit(BackOfficeEmployee e)
			{
				TotalCompensation += e.Salary + e.Bonus;
			}

			public void Visit(SalesEmployee e)
			{
				TotalCompensation += e.Salary + e.Commission;
			}
		}
		public class Employee
		{
			public string Name { get; set; }
			public decimal Salary { get; set; }

			public Employee(string name, decimal salary) 
			{
				Name = name;
				Salary = salary;
			}
		}

		public class BackOfficeEmployee : Employee, IVisitableElement
		{
			public decimal Bonus { get; set; }

			public BackOfficeEmployee(string name, decimal salary, decimal bonus) : base(name, salary)
			{
				Bonus = bonus;
			}

			public void Accept(IVisitor visitor)
			{
				visitor.Visit(this);
			}
		}
		public class SalesEmployee : Employee, IVisitableElement
		{
			public decimal Commission { get; set; }

			public SalesEmployee(string name, decimal salary, decimal comission) : base(name, salary)
			{
				Commission = comission;
			}
			public void Accept(IVisitor visitor)
			{
				visitor.Visit(this);
			}
		}
	}
}
