using System.IO;
using BlazorApp.Data;
using BlazorApp.Shared;
using System.Linq;
using YamlDotNet.Serialization;

namespace BlazorApp.Service
{
    public class BlogService
    {
        private readonly BlogPost[] _blogPosts = new BlogPost[]
        {
            new BlogPost{ URL="1",Title = "No.1 Post Title" , Description = "one blog", Content = "content *test*"},
            new BlogPost{ URL="2",Title = "No.2 Post Title" , Description = "two blog"},
            new BlogPost{ URL="3",Title = "No.2 Post Title" , Description = "three blog"},
        };

        public BlogService()
        {
            var blogPostsPath = $"{Directory.GetCurrentDirectory()}/wwwroot/BlogPosts";
            var files = Directory.GetFiles(blogPostsPath, "*.md", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                Console.WriteLine(File.ReadAllText(file));
                Console.WriteLine("------------------------------------------------");
            }
        }

        public BlogPost[] GetBlogPosts()
        {
            return _blogPosts;
        }

        public BlogPost GetBlogPost(string url)
        {
            foreach (var blogPost in _blogPosts)
            {
                if (blogPost.URL == url)
                {
                    return blogPost;
                }
            }

            return null;
        }
    }
}