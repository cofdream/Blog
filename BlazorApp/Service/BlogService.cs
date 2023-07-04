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
            //RebuildMeta();

            //var deserializer = new DeserializerBuilder()
            //    .WithTypeConverter(new DateTimeConverter())
            //    .Build();

            //var blogPosts = new List<BlogPost>();
            //var files = Directory.GetFiles(blogPostsPath, "*.md.meta", SearchOption.AllDirectories);
            //foreach (var file in files)
            //{
            //    var yaml = File.ReadAllText(file);

            //    var blogPost = deserializer.Deserialize<BlogPost>(yaml);
            //    blogPost.Content = File.ReadAllText(file.Replace(".meta", string.Empty));
            //    blogPosts.Add(blogPost);
            //}

            //_blogPosts = blogPosts.ToArray();
        }

        private void RebuildMeta()
        {
            var serializer = new SerializerBuilder()
                .WithTypeConverter(new DateTimeConverter())
                .Build();

            var files = Directory.GetFiles(blogPostsPath, "*.md", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.EndsWith("*.meta")) continue;

                var fileMeta = file + ".meta";
                if (File.Exists(fileMeta)) continue;

                var blogPost = new BlogPost()
                {
                    Url = file.Replace(blogPostsPath, string.Empty).Replace("\\", "/").Replace(".md", string.Empty),
                    Title = Path.GetFileNameWithoutExtension(file),
                    Description = File.ReadAllText(file)[0..Math.Clamp(100, 0, fileMeta.Length)],
                };

                var yaml = serializer.Serialize(blogPost);
                File.WriteAllText($"{blogPostsPath}{blogPost.Url}.md.meta", yaml);
            }
        }

        //public BlogPost[] GetBlogPosts()
        //{
        //    return _blogPosts;
        //}

        public BlogPost GetBlogPost(string url)
        {
            //foreach (var blogPost in _blogPosts)
            //{
            //    if (blogPost.Url == url)
            //    {
            //        return blogPost;
            //    }
            //}

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