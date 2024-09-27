namespace Pattern.Structural.Adapter
{
	internal class PaymentProcessorClassAdapter : NewFastPaymentProcessor, IOldSlowPaymentProcessor
	{
		public bool ProcessPayment(Transaction transaction)
		{
			return this.MakePayment(transaction);
		}
	}
}
