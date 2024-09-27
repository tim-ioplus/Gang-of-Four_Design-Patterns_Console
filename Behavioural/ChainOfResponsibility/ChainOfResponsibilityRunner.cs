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
			var consoleLogger = new ConsoleLogger();
			var fileLogger = new FileLogger();
			var emailLogger = new EmailLogger();

			fileLogger.Next = emailLogger;
			consoleLogger.Next = fileLogger;
			
			consoleLogger.Handle(LogLevel.Info, "Objekt 4711 wurde geladen.");
			consoleLogger.Handle(LogLevel.Warn, "Objekt 4711 wurde verändert.");
			consoleLogger.Handle(LogLevel.Error, "Objekt 4711 konnte nicht gespeichert werden.");
		}

		internal enum LogLevel { Info, Warn, Error }

		internal interface ILogger
		{
			void Handle(LogLevel loglevel, string message);
			ILogger? Next{get; set; }
		}

		class ConsoleLogger : ILogger
		{
			public ILogger? Next { get; set; }
			public ConsoleLogger(){}
			
			public void Handle(LogLevel loglevel, string message)
			{
				if(loglevel == LogLevel.Info)
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
			public FileLogger(){}

			public void Handle(LogLevel loglevel, string message)
			{
				if(loglevel == LogLevel.Warn)
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
			public EmailLogger(){}

			public void Handle(LogLevel loglevel, string message)
			{
				if(loglevel == LogLevel.Error)
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
}
