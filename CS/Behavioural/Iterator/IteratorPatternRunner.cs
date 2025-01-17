using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Behavioural.Iterator
{
	internal static class IteratorPatternRunner
	{
		public static void Run()
		{
			Console.WriteLine("Iterator");

			Console.WriteLine("Fibunacci Iterator");
			var iterator = new FibunacciIterator();

			int fib = 0;
			int max = 2048;
			while(true)
			{
				int f = iterator.Next();
				if(f > max) break;

				fib = f;
				Console.WriteLine(fib);
				Thread.Sleep(100);
			}

			Console.WriteLine("Collection iterator");
			var monthiterator = new MonthIterator();
			while(monthiterator.HasNext())
			{
				Console.WriteLine(monthiterator.Next());
			}


		}

		public interface INumberIterator
		{
			int Next();
		}

		public interface ICollectionIterator
		{
			bool HasNext();
			string Next();
		}

		public class MonthIterator : ICollectionIterator
		{
			public int Index = 0;
			public List<string> Values = new List<string>()
			{ "Januar", "Februar", "März", "April", "Mai", "Juni", 
				"Juli", "August", "September", "Oktober", "November", "Dezember"};
			public bool HasNext()
			{
				return Values.Count > Index;
			}

			public string Next()
			{
				var x = Values[Index];
				Index++;

				return x;
			}
		}
		public class FibunacciIterator : INumberIterator
		{
			public int a = 0;
			public int b = 1;

			public int Next()
			{
				int temp = a;
				a = b;
				b = temp + b;

				return a;
			}

		}
	}
}
