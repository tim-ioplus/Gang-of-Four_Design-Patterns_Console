

namespace Pattern.Structural.Decorator
{
	internal static class DecoratorPatternRunner
	{
		public static async Task<List<Post?>> Run()
		{
			var posts = await RunDecorators();

			if(posts.Count == 0)
			{
				posts.ForEach(p => Console.WriteLine(value: $"Post {p}"));
			}
			else
			{
				Console.WriteLine("No Post loaded");
			}

			return posts;
		}
		public static async Task<List<Post?>> RunDecorators()
		{
			Console.WriteLine("Decorator pattern");
			var posts = new List<Post>();

			IPostService postService = new PostService();

			try
			{
				var post = await postService.GetPost(7);
				posts.Add(post);
			}
			catch (Exception) 
			{
				throw;
			}

			var postServiceMeasuringDecorator = new PostServiceMeasuringDecorator(postService);
			try
			{
				var post = await postServiceMeasuringDecorator.GetPost(8);
				posts.Add(post);
			}
			catch (Exception) 
			{ 
				throw;
			}

			var postServiceLoggingDecorator = new PostServiceLoggingDecorator(postService);
			try
			{
				var post = await postServiceLoggingDecorator.GetPost(9);
				posts.Add(post);
			}
			catch(Exception ex)
			{
				throw;
			}

			return posts;
		}
	}
}
