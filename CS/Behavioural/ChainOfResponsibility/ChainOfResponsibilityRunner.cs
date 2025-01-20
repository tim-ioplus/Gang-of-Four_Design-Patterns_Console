using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Behavioural.ChainOfResponsibility
{
	internal static class ChainOfResponsibilityRunner
	{
		internal static void Run()
		{
			Console.WriteLine("Chain of Repsonsibility");
			var myLogger = new MyLogger();

			myLogger.Handle(LogLevel.Info, "Objekt 4711 wurde geladen.");
			myLogger.Handle(LogLevel.Warn, "Objekt 4711 wurde verändert.");
			myLogger.Handle(LogLevel.Error, "Objekt 4711 konnte nicht gespeichert werden.");
		}
	}

	internal enum LogLevel { Info, Warn, Error }

	internal interface ILogger
	{
		void Handle(LogLevel loglevel, string message);
		ILogger? Next { get; set; }
	}

	class MyLogger : ILogger
	{
		public ILogger? Next { get; set; }
		public MyLogger()
		{
		}

		public void Handle(LogLevel loglevel, string message)
		{
			if (Next == null)
			{
				Next = new ConsoleLogger();
			}

			Next?.Handle(loglevel, message);
		}
	}

	class ConsoleLogger : ILogger
	{
		public ILogger? Next { get; set; }
		public ConsoleLogger() { }

		public void Handle(LogLevel loglevel, string message)
		{
			if (Next == null)
			{
				Next = new FileLogger();
			}

			if (loglevel == LogLevel.Info)
			{
				Console.WriteLine("Console Log:" + loglevel + " : " + message);
			}
			else
			{
				Next?.Handle(loglevel, message);
			}
		}
	}

	class FileLogger : ILogger
	{
		public ILogger? Next { get; set; }
		public FileLogger() { }

		public void Handle(LogLevel loglevel, string message)
		{
			if (Next == null)
			{
				Next = new EmailLogger();
			}

			if (loglevel == LogLevel.Warn)
			{
				Console.WriteLine("File Log:" + loglevel + " : " + message);
			}
			else
			{
				Next?.Handle(loglevel, message);
			}
		}
	}

	class EmailLogger : ILogger
	{
		public ILogger? Next { get; set; }
		public EmailLogger() { }

		public void Handle(LogLevel loglevel, string message)
		{
			if (loglevel == LogLevel.Error)
			{
				Console.WriteLine("Email Log:" + loglevel + " : " + message);
			}
			else
			{
				Console.WriteLine("Log: " + loglevel + " : " + message);
			}
		}
	}
}
