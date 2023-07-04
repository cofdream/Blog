using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Converters;

namespace BlogTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //args = new string[1];
            //args[0] = "F:\\Self\\Blog\\BlogPosts\\Unity编辑器自定义资源导入.html";

            try
            {
                if (args != null && args.Length > 0)
                {
                    ExportHtml2(args[0]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        private static void ExportHtml(string filePath)
        {
            if (File.Exists(filePath) == false) return;

            var html = string.Empty;
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (line.StartsWith("<div "))
                {
                    html = line;
                    break;
                }
            }

            if (string.IsNullOrEmpty(html) == false)
            {
                File.WriteAllText(filePath, html);
                Console.WriteLine($"{nameof(ExportHtml)} success done.");
            }
            else
            {
                Console.WriteLine($"{nameof(ExportHtml)} success done.");
            }
        }

        private static void ExportHtml2(string filePath)
        {
            Console.WriteLine($"filePath:{filePath}");

            if (File.Exists(filePath) == false) return;

            var htmlContent = File.ReadAllText(filePath);

            var content = GetHtmlCotent(htmlContent, "<body>", "</body>");


            BlogPost blogPost = null;
            var metaPath = filePath.Replace(".html", ".meta");
            if (File.Exists(metaPath))
            {
                blogPost = new DeserializerBuilder()
                .WithTypeConverter(new DateTimeConverter())
                .Build()
                .Deserialize<BlogPost>(File.ReadAllText(metaPath));
            }

            if (blogPost == null)
            {
                blogPost = new BlogPost();
                blogPost.Url = Path.GetFileName(filePath);
            }

            blogPost.Title = GetHtmlCotent(htmlContent, "<title>", "</title>");
            blogPost.Content = content;


            if (string.IsNullOrEmpty(content) == false)
            {
                var metaStr = new SerializerBuilder()
                .WithTypeConverter(new DateTimeConverter())
                .Build()
                .Serialize(blogPost);

                File.WriteAllText(metaPath, metaStr);
                Console.WriteLine($"{nameof(ExportHtml2)} success done.");
            }
            else
            {
                Console.WriteLine($"{nameof(ExportHtml2)} success done.");
            }
        }

        private static string GetHtmlCotent(string content, string star, string end)
        {
            var startIndex = content.IndexOf(star, StringComparison.OrdinalIgnoreCase);
            if (startIndex < 0)
            {
                Console.WriteLine($"get star:{star} error.");
                return content;
            }
            startIndex += star.Length;
            var endIndex = content.LastIndexOf(end, StringComparison.OrdinalIgnoreCase);
            if (endIndex < 0)
            {
                Console.WriteLine($"get end:{end} error.");
                return content;
            }


            var countLength = content.Length - startIndex - (content.Length - endIndex);
            Console.WriteLine($"count:{countLength} length:{content.Length}");

            return content.Substring(startIndex, countLength);
        }
    }

    public class BlogPost
    {
        public string Url = string.Empty;
        public string[] Tags = Array.Empty<string>();
        public string Title = string.Empty;
        public string Description = string.Empty;
        public string Content = string.Empty;
        public DateTime DateTime = DateTime.Now;
    }
}
