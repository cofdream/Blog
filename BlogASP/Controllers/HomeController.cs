using BlogASP.Data.FileManager;
using BlogASP.Data.Repository;
using BlogASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogASP.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly IRepository repository;
        private readonly IFileManager fileManager;

        public HomeController(IRepository repository, IFileManager fileManager)
        {
            this.repository = repository;
            this.fileManager = fileManager;
        }

        public IActionResult Index(string category)
        {
            var posts = string.IsNullOrEmpty(category) ? repository.GetAllPostList() : repository.GetAllPostList(category);
            return View(posts);
        }

        public IActionResult Post(uint id)
        {
            var post = repository.GetPost(id);
            if (post == null)
                return Error();

            return View(post);
        }


        [HttpGet("/Image/{folder}/{image}")]
        public IActionResult PostImage(string folder, string image)
        {
            var path = $"{folder}/{image}";
            var mime = image.Substring(image.LastIndexOf(".") + 1);
            return new FileStreamResult(fileManager.ImageStream(path), $"image/{mime}");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
