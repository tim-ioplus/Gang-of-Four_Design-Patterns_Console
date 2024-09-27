using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Structural.Proxy
{
	public static class ProxyPatternRunner
	{
        public static void Run()
		{
			Console.WriteLine("Proxy Pattern Runner..");

			var postProxy = new PostProxy();

			int maxRequests = 1000;
			for (int i = 0; i < maxRequests; i++)
			{
				int postId = Random.Shared.Next(1,99);
				var post = postProxy.Get(postId);
				
				if(i % 10 == 0) Console.WriteLine( i + " / " + maxRequests);
			}

			double hitPercentage = (double) postProxy.CacheHits / maxRequests * 100;
			Console.WriteLine("Von 100 Anfragen " + postProxy.CacheHits + " / " + hitPercentage + "% aus cache geladen");
		}
	}
}
