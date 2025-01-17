using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Creational.Factory
{
	internal static class FactoryPatternRunner
	{
		public static void Run()
		{
			Console.WriteLine("Factory Pattern Runner");

			var products = new List<IProduct>();

			for(int i = 0;i<10; i++)
			{
				var productType = (new Random().Next(0,2) < 1) ? "A" : "B";
				var product = new ProductFactory().Create(productType);
				products.Add(product);
			}

			foreach(var product in products)
			{
				Console.WriteLine(product.ToString());
			}
		}
	}
}
