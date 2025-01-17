namespace Pattern.Structural.Adapter
{
	internal class NewFastPaymentProcessor : INewFastPaymentProcessor
	{
		public int ProcessingTime = 10;
		public bool MakePayment(Transaction transaction)
		{
			Console.WriteLine("Sending via new Iban..");
			Console.WriteLine("Sending Payment " + transaction.ToString());
			Thread.Sleep(ProcessingTime);
			Console.WriteLine("Payment sended in 10ms");

			return true;
		}
	}
}
