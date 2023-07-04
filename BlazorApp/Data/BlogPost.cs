using YamlDotNet.Serialization;

namespace BlazorApp.Data
{
	public class BlogPost
	{
		public string Url = string.Empty;
		public string[] Tags = Array.Empty<string>();
		public string Title = string.Empty;
		public string Description = string.Empty;
		public DateTime DateTime = DateTime.Now;
	}
}
