using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Structural.Bridge
{
	public static partial class BridgePatternRunner
	{
		// Create a Printing System which supports
		// - at least 2 types of Printers
		// - different output Format: Text, Html
		// 
		public static void Run()
		{
			var textPrinter = new PlainTextPrinter();
			var htmlPrinter = new HtmlPrinter();
			var jsonPrinter = new JsonPrinter();

			// Printer Data "A"
			var aprinter = new APrinter(textPrinter);
			Console.WriteLine("text 'A' printed as plain text");
			aprinter.Print();

			aprinter = new APrinter(htmlPrinter);
			Console.WriteLine("text 'A' printed in html format");
			aprinter.Print();

			aprinter = new APrinter(jsonPrinter);
			Console.WriteLine("text 'A' printed in json format");
			aprinter.Print();
			
			// Printer Data "B"
			var bprinter = new BPrinter(textPrinter);
			Console.WriteLine("text 'B' printed as plain text");
			bprinter.Print();

			bprinter = new BPrinter(htmlPrinter);
			Console.WriteLine("text 'B' printed in html format");
			bprinter.Print();

			bprinter = new BPrinter(jsonPrinter);
			Console.WriteLine("text 'B' printed in json format");
			bprinter.Print();
		}
	}
}
