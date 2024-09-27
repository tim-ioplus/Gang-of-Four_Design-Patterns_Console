// See https://aka.ms/new-console-template for more information

namespace Pattern.Structural.Adapter
{
	internal interface IOldSlowPaymentProcessor
	{
		public bool ProcessPayment(Transaction transaction);
	}
}