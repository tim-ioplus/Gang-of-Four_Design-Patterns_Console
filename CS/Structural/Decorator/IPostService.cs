namespace Pattern.Structural.Decorator
{
	internal interface IPostService
	{
		Task<Post?> GetPost(int id);
	}
}
