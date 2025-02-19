using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Pattern.Behavioural.Template
{
	internal static class TemplateMethodPatternRunner
	{
		public static void Run()
		{
			Console.WriteLine("Template Method Pattern..");
			
			Console.WriteLine("Csv to Sql:");
			var csvToXml = new CsvToSql();
			csvToXml.Import("/one/path/to/csv/file");

			Console.WriteLine("xml to Document:");
			var jsonToDocumentStorage = new XmlToDocumentStorage();
			jsonToDocumentStorage.Import("/two/path/to/json/file");
		}

		public abstract class ETL
		{
			public void Import(string source)
			{
				var extractedData = Extract(source);

				var transformedData = Transform(extractedData);

				Load(transformedData);
			}

			protected abstract string[] Extract(string source);
			protected virtual string[] Transform(string[] extractedData){ return extractedData;}
			protected abstract void Load(string[] extractedData);
		}

		public class CsvToSql : ETL
		{
			protected override string[] Extract(string source)
			{
				return new string[]{ "1,2,3", "4,5,6" };
			}

			protected override void Load(string[] extractedData)
			{
				Console.WriteLine("Load Csv data to Sql Storage:");
                foreach (var data in extractedData)
                {
					Thread.Sleep(Random.Shared.Next(150,500));
					Console.WriteLine("Data loaded: " + data);
                }
            }
		}

		public class XmlToDocumentStorage : ETL
		{
			protected override string[] Extract(string source)
			{
				return new string[]{ "a,x,y", "y,m,n" };
			}

			protected override string[] Transform(string[] data)
			{
				Console.WriteLine("Xml Data transformed to csv");
				return data;
			}

			protected override void Load(string[] extractedData)
			{
				Console.WriteLine("Load Csv data to Document Storage:");
                foreach (var data in extractedData)
                {
					Thread.Sleep(Random.Shared.Next(150,500));
					Console.WriteLine("Data loaded: " + data);
                }
			}
		}
	}
}
