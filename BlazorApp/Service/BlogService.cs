using BlazorApp.Data;
using BlazorApp.Shared;
using System.Linq;

namespace BlazorApp.Service
{
    public class BlogService
    {
        private readonly BlogPost[] _blogPosts = new BlogPost[]
        {
            new BlogPost{ URL="1",Title = "No.1 Post" , Description = "one blog"},
            new BlogPost{ URL="2",Title = "No.2 Post" , Description = "two blog"},
            new BlogPost{ URL="3",Title = "No.2 Post" , Description = "three blog"},
        };

        public BlogPost[] GetBlogPosts()
        {
            return _blogPosts;
        }

        public BlogPost GetBlogPost(string url)
        {
            return _blogPosts.First((blogPost) => { return blogPost.URL == url; });
        }
    }
}