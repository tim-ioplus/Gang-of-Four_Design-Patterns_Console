namespace Pattern.Structural.Decorator
{
	internal class PostServiceLoggingDecorator : PostServiceDecorator
	{
		public PostServiceLoggingDecorator(IPostService iPostService):base(iPostService) { }
			
		public override async Task<Post?> GetPost(int id)
		{
			try
			{
				Console.WriteLine($"Loading Post: {id}");
				var post = await _postService.GetPost(id);
					
				if(post!=null)
				{
					Console.WriteLine("Post Loaded");
					Console.WriteLine($"Post # {post.Id} by {post.UserId} {Environment.NewLine} {post.Title} {Environment.NewLine} {post.Body}");
				}
				else
				{
					Console.WriteLine($"Post {id} not loaded.");
				}

				return post;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
