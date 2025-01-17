using Pattern.Structural.Decorator;

namespace Pattern.Structural.Proxy
{
	public class PostProxy
		{
			private Dictionary<int, Post> _cache;
			public int CacheHits;

			public PostProxy()
			{
				_cache = new Dictionary<int, Post>();
				CacheHits = 0;
			}

			public Post? Get(int id)
			{
				if(_cache.ContainsKey(id))
				{
					CacheHits++;
					return _cache[id];
				}
				else
				{
					var service = new PostService();
					var result = service.GetPost(id);
					Post post = (result.Result != null) ? result.Result : null;
					if(post != null) 
					{
						_cache.Add(id, post);
						return post;
					}
					else
					{
						return null;
					}
				}
			}
		}
}
