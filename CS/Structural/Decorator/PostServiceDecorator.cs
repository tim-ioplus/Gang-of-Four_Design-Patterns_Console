namespace Pattern.Structural.Decorator
{
	internal abstract class PostServiceDecorator : IPostService
	{
		public readonly IPostService _postService;

		public PostServiceDecorator(IPostService iPostService)
		{
			_postService = iPostService;
		}

		public abstract Task<Post?> GetPost(int postId);
	}
}
