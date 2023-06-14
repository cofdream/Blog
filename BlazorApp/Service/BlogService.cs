using BlazorApp.Data;

namespace BlazorApp.Service
{
	public class BlogService : IBlogService
	{
		private readonly BlogPost[] _blogPosts = new BlogPost[]
		{
			new BlogPost{ Title = "No.1 Post" , Description = "这是我的第一篇博客"},
			new BlogPost{ Title = "No.2 Post" , Description = "这是我的第二篇博客"},
			new BlogPost{ Title = "No.2 Post" , Description = "这是我的第三篇博客"},
		};

		public BlogPost[] GetBlogPosts()
		{
			return _blogPosts;
		}
	}
}
