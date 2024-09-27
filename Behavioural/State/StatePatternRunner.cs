using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Behavioural.State
{
	internal static class StatePatternRunner
	{
		internal static void Run()
		{
			Console.WriteLine("StatePatternRunner");

			var invoice1 = new Invoice(241,(decimal)59.99);
			invoice1.Pay();
			invoice1.Cancel();
			invoice1.Refund();

			var invoice2 = new Invoice(242,(decimal)12457.54);
			invoice2.Pay();
			invoice2.Refund();
			invoice2.Cancel();

			var invoice3 = new Invoice(243,(decimal)390.90);
			invoice3.Refund();
			invoice3.Cancel();
			invoice3.Pay();

			var invoice4 = new Invoice(244,(decimal)1999.99);
			invoice4.Refund();
			invoice4.Cancel();
			invoice4.Pay();
		}

		internal interface IInvoiceState
		{
			public bool Pay(Invoice invoice);
			public bool Cancel(Invoice invoice);
			public bool Refund(Invoice invoice);
		}
		internal class UnPaidInvoiceState : IInvoiceState
		{
			public bool Cancel(Invoice invoice)
			{
				Console.WriteLine("Invoice cancelled.");
				return true;
			}

			public bool Pay(Invoice invoice)
			{
				Console.WriteLine("Invoice paid.");
				return true;
			}

			public bool Refund(Invoice invoice)
			{
				Console.WriteLine("Cannot refund Invoice: Its unpaid.");
				return false;
			}
		}

		internal class PaidInvoiceState : IInvoiceState
		{
			public bool Cancel(Invoice invoice)
			{
				Console.WriteLine("Cannot cancel Invoice: Its payed.");
				return false;
			}

			public bool Pay(Invoice invoice)
			{
				Console.WriteLine("Cannot pay Invoice: Its already payed.");
				return false;
			}

			public bool Refund(Invoice invoice)
			{
				Console.WriteLine("Refund Invoice.");
				return true;
			}
		}

		internal class CancelledInvoiceState : IInvoiceState
		{
			public bool Cancel(Invoice invoice)
			{
				Console.WriteLine("Cannot cancel Invoice: Its already cancelled.");
				return false;
			}

			public bool Pay(Invoice invoice)
			{
				Console.WriteLine("Cannot pay Invoice: Its cancelled.");
				return false;
			}

			public bool Refund(Invoice invoice)
			{
				Console.WriteLine("Cannot refund Invoice: Its cancelled.");
				return false;
			}
		}

		internal class RefundedInvoiceState : IInvoiceState
		{
			public bool Cancel(Invoice invoice)
			{
				Console.WriteLine("Cannot cancel Invoice: Its refunded.");
				return false;
			}

			public bool Pay(Invoice invoice)
			{
				Console.WriteLine("Cannot pay Invoice: Its refunded.");
				return false;
			}

			public bool Refund(Invoice invoice)
			{
				Console.WriteLine("Cannot refund Invoice: Its already refunded.");
				return false;
			}
		}

		internal class Invoice
		{
			public int Number { get; }
			public decimal Amount {get; }

			public IInvoiceState State { get; set; }

			public Invoice(int number, decimal amount) 
			{
				Number = number;
				Amount = amount;
				State = new UnPaidInvoiceState();
			}

			public void Pay()
			{
				var result = State.Pay(this);
				if(result) State = new PaidInvoiceState();
			}
			public void Cancel()
			{
				var result = State.Cancel(this);
				if(result) State = new CancelledInvoiceState();
			}
			public void Refund()
			{
				var result = State.Refund(this);
				if(result) State = new RefundedInvoiceState();
			}

		}
	}
}
