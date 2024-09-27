// See https://aka.ms/new-console-template for more information

namespace Pattern.Structural.Adapter
{
	internal interface INewFastPaymentProcessor
	{
		public bool MakePayment(Transaction transaction);
	}
}