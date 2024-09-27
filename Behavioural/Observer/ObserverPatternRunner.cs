using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Behavioural.NewFolder
{
	internal static class ObserverPatternRunner
	{
		internal static void Run()
		{
			var userObserver = new UserObserver();
			var displayObserver = new DisplayObserver();

			var iopxSubject = new Subject("Symbol IOPX", "1");
			var rsfnSubject = new Subject("Symbol RSFN", "10");
			iopxSubject.Subscribe(userObserver);
			iopxSubject.Subscribe(displayObserver);
			rsfnSubject.Subscribe(displayObserver);

			iopxSubject.Update("5");
			rsfnSubject.Update("17");
			iopxSubject.Update("2");
			rsfnSubject.Update("19");
			iopxSubject.Unsubscribe(userObserver);

			rsfnSubject.Update("18");
			iopxSubject.Update("10");
			rsfnSubject.Update("16");
			iopxSubject.Subscribe(userObserver);

			iopxSubject.Update("12");
			rsfnSubject.Update("20");
		}

		internal interface IObserver
		{
			public void Notify(string state);
		}

		public abstract class AbstractObserver : IObserver
		{
			public string Name = "";
			public abstract void Notify(string state);
		}
		public class DisplayObserver : AbstractObserver
		{
			public DisplayObserver()
			{
				Name = "Display";
			}
			public override void Notify(string state)
			{
				Console.WriteLine(Name + " shows: " + state);
			}

		}
		public class UserObserver : AbstractObserver
		{			
			public UserObserver()
			{
				Name = "User";
			}
			public override void Notify(string state) 
			{
				Console.WriteLine(Name + " consumes: " + state);
			}
		}
		internal interface ISubject
		{
			void Subscribe(AbstractObserver observer);
			void Unsubscribe(AbstractObserver observer);
			void Update(string state);

			void NotifyObservers();
		}

		internal class Subject : ISubject
		{
			string Name = "";
			string State;
			List<IObserver> Observers = new List<IObserver>();

			public Subject(string name, string state)
			{
				Name = name;
				State = state;
			}

			public void Update(string newState)
			{
				State = newState;
				NotifyObservers();
			}
			public void NotifyObservers()
			{
				Console.WriteLine(Name + " notifies");
				Observers.ForEach(o => o.Notify(State));
			}

			public void Subscribe(AbstractObserver observer)
			{
				Observers.Add(observer);
				Console.WriteLine(observer.Name + " subscribes to: " + Name);
			}

			public void Unsubscribe(AbstractObserver observer)
			{
				Observers.Remove(observer);
				Console.WriteLine(observer.Name + " unsubscribes from: " + Name);
			}
		}
	}
}
