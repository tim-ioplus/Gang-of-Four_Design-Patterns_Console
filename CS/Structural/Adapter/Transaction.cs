namespace Pattern.Structural.Adapter
{
	public class Transaction
	{
		string Receiver = "";
		string Number = "";
		decimal Amount = new decimal(0);

		public Transaction(string receiver, string number, decimal amount)
		{
			Receiver = receiver;
			Number = number;
			Amount = amount;
		}

		public override string ToString()
		{
			return Receiver + " " + Number + " " + Amount;
		}
	}
}
