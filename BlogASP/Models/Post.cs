using System;

namespace BlogASP.Models
{
    public class Post
    {
        public uint Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
