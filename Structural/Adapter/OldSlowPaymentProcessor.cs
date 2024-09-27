namespace Pattern.Structural.Adapter
{
	internal class OldSlowPaymentProcessor : IOldSlowPaymentProcessor
	{
		public int ProcessingTime = 1500;
		public bool ProcessPayment(Transaction transaction)
		{
			Console.WriteLine("Sending via Banknumber..");
			Console.WriteLine("Sending Payment " + transaction.ToString());
			Thread.Sleep(ProcessingTime);
			Console.WriteLine("Payment sended in 1500ms");

			return true;
		}
	}
}
