using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Structural.Adapter
{
	internal class AdapterPatternRunner
	{
		public static void Run()
		{
			Console.WriteLine("Adapter Pattern");

			var transactions = new List<Transaction>();
			var t1 = new Transaction("Alan Turing", "DE331230451265987451", 10000);
			var t2 = new Transaction("Noam Chomsky", "NL451212457897454444", 10000);
			transactions.Add(t1);
			transactions.Add(t2);

			IOldSlowPaymentProcessor myPaymentProcessor;
			myPaymentProcessor = new OldSlowPaymentProcessor();
			transactions.ForEach(t => myPaymentProcessor.ProcessPayment(t));
			Console.WriteLine(transactions.Count * 1500 + "ms processing time.");
			Console.WriteLine("Too slow.. very bad.");

			Console.WriteLine("Process Payments with New Provider via Object Adapter");
			var newFastPaymentProcessor = new NewFastPaymentProcessor();
			myPaymentProcessor = new PaymentProcessorAdapter(newFastPaymentProcessor);
			transactions.ForEach(t => myPaymentProcessor.ProcessPayment(t));
			Console.WriteLine(transactions.Count * 10 + "ms processing time.");
			Console.WriteLine("Much faster.. very good.");

			Console.WriteLine("Process Payments with New Provider via class Adapter");
			myPaymentProcessor = new PaymentProcessorClassAdapter();
			transactions.ForEach(t => myPaymentProcessor.ProcessPayment(t));
		}
	}
}
