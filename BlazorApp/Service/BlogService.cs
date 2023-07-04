using BlazorApp.Data;
using BlazorApp.Shared;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Converters;

namespace BlazorApp.Service
{
    public class BlogService
    {
        private List<BlogPost> blogPosts = null;

        private static string blogPostsPath = $"{Directory.GetCurrentDirectory()}/wwwroot/BlogPosts/";


        public BlogService()
        {
           
        }

        public BlogPost GetBlogPost(string url)
        {
            foreach (var blogPost in blogPosts)
            {
                if (blogPost.Url == url)
                {
                    return blogPost;
                }
            }

            return null;
        }


        public async Task<List<BlogPost>> GetBlogPosts2()
        {
            if (blogPosts == null)
            {
                var files = Directory.GetFiles(blogPostsPath, "*.meta", SearchOption.AllDirectories);
                blogPosts = new List<BlogPost>();
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
                            blogPosts.Add(blogPost);
                        }
                    }
                    catch (Exception ex)
                    {
                        await Console.Out.WriteLineAsync(ex.ToString());
                    }
                }

            }

            return blogPosts;
        }
    }
}