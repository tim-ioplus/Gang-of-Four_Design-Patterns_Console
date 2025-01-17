using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Creational.Builder
{
	internal static class BuilderPatternRunner
	{
		public static void Run()
		{
			Console.WriteLine("Builder Pattern Runner");

			int maxBuilders = 10;
			var builders = new List<ILandingPageBuilder>();
			for(int i = 0; i<maxBuilders; i++)
			{
				var pagetypeToCreate = (new Random().Next(0,2) < 1) ? "Sports" : "Science";
				ILandingPageBuilder builder = 
					(pagetypeToCreate=="Sports") ? new SportsLandingPageBuilder() : 
					(pagetypeToCreate=="Science") ? new ScienceLandingPageBuilder() : throw new Exception();

				builders.Add(builder);
			}

			var landingPageDirector = new LandingPageDirector();
			landingPageDirector.Construct(builders);
			landingPageDirector.Show(builders);

			int idx = (int)Math.Floor(new Decimal(maxBuilders / 2));
			var idxLandingPage = builders.ElementAtOrDefault(idx)?.GetLandingPage();
			Console.WriteLine("--" + Environment.NewLine + "Page at idx " + idx);
			Console.WriteLine(idxLandingPage?.ToString());
		}
	}
}
