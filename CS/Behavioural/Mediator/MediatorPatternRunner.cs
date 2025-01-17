namespace Pattern.Behavioural.Mediator
{
	internal class MediatorPatternRunner
    {
        internal static void Run()
		{

            var mediator = new Mediator();
            var colleague1 = new Colleague("c1", mediator);
            var colleague2 = new Colleague("c2", mediator);
            var historian = new InMemoryHistorian("Historian", mediator);

            mediator.Colleague1 = colleague1;
            mediator.Colleague2 = colleague2;
            mediator.Historian = historian;

            int minPause = 250;
            int maxPause = 2000;
            colleague1.Send("Hallo!");
            Thread.Sleep(Random.Shared.Next(minPause,maxPause));
            colleague2.Send("Moin moin");
            Thread.Sleep(Random.Shared.Next(minPause,maxPause));
            colleague1.Send("Wie geht es?");
            Thread.Sleep(Random.Shared.Next(minPause,maxPause));
            colleague2.Send("sehr stabil, danke.");
            Thread.Sleep(Random.Shared.Next(minPause,maxPause));
            colleague2.Send("Und Selbst?");
            Thread.Sleep(Random.Shared.Next(minPause,maxPause));
            colleague1.Send("ja, gut. danke.");
            Thread.Sleep(Random.Shared.Next(minPause,maxPause));
            colleague1.Send("alsoo..");
            Thread.Sleep(Random.Shared.Next(minPause,maxPause));

            historian.ShowHistory();
        }
		public class Mediator : AbstractMediator
		{
            public AbstractColleague Colleague1;
            public AbstractColleague Colleague2;
			public AbstractHistorian Historian;

			public override void Send(string message, AbstractColleague colleague)
			{
				if(colleague == Colleague1)
                {
                    Colleague2.Receive(message);
                }
                else if(colleague == Colleague2)
                {
                    Colleague1.Receive(message);
                }

                Historian.Receive(colleague.Name, message);
			}
		}

		internal abstract class AbstractMediator
        {
            public abstract void Send(string message, AbstractColleague colleague);
        }

        public abstract class AbstractCommunicator
        {
            internal AbstractMediator _mediator;
            public string Name;

            public AbstractCommunicator(string name, Mediator mediator)
            {
                Name = name;
                _mediator = mediator;
            }
        }

        public abstract class AbstractColleague : AbstractCommunicator
        {
			protected AbstractColleague(string name, Mediator mediator) : base(name, mediator)
			{
			}

			public virtual void Send(string message)
            {
                base._mediator.Send(message, this);
            }

            public abstract void Receive(string message);
        }

		public abstract class AbstractHistorian : AbstractCommunicator
		{
            internal object? _history;
			protected AbstractHistorian(string name, Mediator mediator) : base(name, mediator)
			{
			}

            public abstract void Receive(string sendername, string message);
		}

		public class Colleague : AbstractColleague
		{
			public Colleague(string name, Mediator mediator) : base(name,mediator)
			{
			}

			public override void Receive(string message)
			{
				Console.WriteLine(this.Name + " received: "  +message);
			}
		}

        public class Message
        {
            public DateTime TimeStamp;
            public string Sendername;
            public string Text;
			public Message(DateTime timestamp, string sendername, string text)
			{
                TimeStamp = timestamp;
				Sendername = sendername;
				Text = text;
			}

			public override string ToString()
			{
				return TimeStamp.ToString("dd-MM-yyyy HH:mm:ss.fff") + ",  " + Sendername + ": " + Text;
			}
		}
		public class InMemoryHistorian : AbstractHistorian
		{
			public InMemoryHistorian(string name, Mediator mediator) : base(name, mediator)
			{
                _history = new List<Message>();
			}

			public override void Receive(string sendername, string message)
			{
				if(_history != null)((List<Message>)_history).Add(new Message(DateTime.Now, sendername, message));
			}

			public void ShowHistory()
            {
                if(_history != null) 
                {
                    Console.WriteLine(this.Name + " message history: ");
                    foreach (var message in ((List<Message>)_history))
                    {
                        Console.WriteLine(message.ToString());
                    }
                }
            }
		}
	}
}
