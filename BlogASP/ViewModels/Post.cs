using BlogASP.Data.FileManager;
using Microsoft.Extensions.Hosting;
using System;

namespace BlogASP.Models
{
    public class PostViewModel
    {

        public uint Id { get; set; } = 0;

        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public IFormFile Image { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
