namespace Pattern.Structural.Adapter
{
	internal class PaymentProcessorAdapter : IOldSlowPaymentProcessor
	{
		private readonly INewFastPaymentProcessor _newFastPaymentProcessor;

		public PaymentProcessorAdapter(INewFastPaymentProcessor newFastPaymentProcessor)
		{
			_newFastPaymentProcessor = newFastPaymentProcessor;
		}

		public bool ProcessPayment(Transaction transaction)
		{
			var processed = _newFastPaymentProcessor.MakePayment(transaction);
			return processed;
		}
	}
}
