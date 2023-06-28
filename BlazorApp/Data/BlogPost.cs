using YamlDotNet.Serialization;

namespace BlazorApp.Data
{
	public class BlogPost
	{
		//[YamlMember(Alias = "Id")] 
		//public int Id;
		public string Url = string.Empty;
		public string[] Tags = Array.Empty<string>();
		public string Title = string.Empty;
		public string Description = string.Empty;
		[YamlIgnore()]
		public string Content = string.Empty;
		public DateTime DateTime = DateTime.Now;
	}
}
