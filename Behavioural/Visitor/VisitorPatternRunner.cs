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

			var jj = new SalesEmployee("Justus Jonas", 100000, 27500);
			var ps = new SalesEmployee("Peter Shaw", 70000, 23250);
			var ba = new BackOfficeEmployee("Bob Andrews", 75000, 21275);
			
			var list = new List<IVisitableElement>(){ jj,ps,ba };
			
			var totalCompensationVisitor = new CompensationVisitor();
			
			foreach (var p in list) 
			{
				p.Accept(totalCompensationVisitor);
				
				var pe = (Employee) p;
				if(pe!= null)
				{
					var peCompensationVisitor = new CompensationVisitor();
					p.Accept(peCompensationVisitor);
					Console.WriteLine("Compensation for " + pe.Name + " is " + peCompensationVisitor.TotalCompensation);
				}
				
			}

			Console.WriteLine("Total Compensation for " + jj.Name + ", " + ps.Name + ", " + ba.Name + " is " + totalCompensationVisitor.TotalCompensation);
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
				TotalCompensation += e.Salary + e.Comission;
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
			public decimal Comission { get; set; }

			public SalesEmployee(string name, decimal salary, decimal comission) : base(name, salary)
			{
				Comission = comission;
			}
			public void Accept(IVisitor visitor)
			{
				visitor.Visit(this);
			}
		}
	}
}
