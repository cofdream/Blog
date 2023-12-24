using BlazorApp.Data;
using BlazorApp.Shared;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Converters;

namespace BlazorApp.Service
{
    public class BlogService
    {
        private List<BlogPost> _blogPosts = new List<BlogPost>();

        //private static readonly string blogPostsPath = $"{Directory.GetCurrentDirectory()}/wwwroot/BlogPosts/";

        private static readonly string blogPostsPath = "E:\\Projects\\CSharpProject\\Blog\\BlogPosts";


        public BlogService()
        {

        }

        public BlogPost GetBlogPost(string url)
        {
            foreach (var blogPost in _blogPosts)
            {
                if (blogPost.Url == url)
                {
                    return blogPost;
                }
            }

            return new BlogPost() { Content = "404" };
        }


        public async Task<List<BlogPost>> GetBlogPosts()
        {
            if (_blogPosts != null && _blogPosts.Count > 0)
            {
                return _blogPosts;
            }
            var files = Directory.GetFiles(blogPostsPath, "*.meta", SearchOption.AllDirectories);
            _blogPosts = new List<BlogPost>();
            foreach (var file in files)
            {
                var text = await File.ReadAllTextAsync(file);
                try
                {
                    var blogPost = new DeserializerBuilder()
                    .WithTypeConverter(new DateTimeConverter())
                    .Build()
                    .Deserialize<BlogPost>(text);
                    if (blogPost != null)
                    {
                        _blogPosts.Add(blogPost);
                    }
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.ToString());
                }
            }

            return _blogPosts;
        }
    }
}