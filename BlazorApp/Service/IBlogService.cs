using BlazorApp.Data;

namespace BlazorApp.Service
{
    public interface IBlogService
    {
        BlogPost[] GetBlogPosts();
	}
}
