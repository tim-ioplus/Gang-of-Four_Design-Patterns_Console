using System.Diagnostics;

namespace Pattern.Structural.Decorator
{
	internal class PostServiceMeasuringDecorator : PostServiceDecorator
	{
		public PostServiceMeasuringDecorator(IPostService postService) : base(postService) { }

		public async override Task<Post?> GetPost(int id)
		{
			try
			{
				var stopwatch = Stopwatch.StartNew();

				var post = await _postService.GetPost(id);

				stopwatch.Stop();
				Console.WriteLine($"Loading Post { id } took { stopwatch.ElapsedMilliseconds / 1000 } seconds");

				return post;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"{ex.Message}");
				throw ex;
			}
		}
	}
}
