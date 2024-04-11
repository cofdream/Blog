using BlogASP.Data.FileManager;
using BlogASP.Data.Repository;
using BlogASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace BlogASP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private readonly IRepository repository;
        private readonly IFileManager fileManager;

        public PanelController(IRepository repository, IFileManager fileManager)
        {
            this.repository = repository;
            this.fileManager = fileManager;
        }


        public IActionResult Index()
        {
            var posts = repository.GetAllPostList();
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = repository.GetPost(id);
            if (post == null)
                return Error();

            return View(post);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var post = repository.GetPost(id.Value);
                if (post != null)
                {
                    return View(new PostViewModel()
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Body = post.Body,
                        //Image = fileManager.ImageStream(post.Image),
                    });
                }
            }
            return View(new PostViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel postViewModel)
        {
            var post = new Post
            {
                Id = postViewModel.Id,
                Title = postViewModel.Title,
                Body = postViewModel.Body,
                Image = await fileManager.SaveImage(postViewModel.Image),
            };

            if (post.Id > 0)
            {
                repository.UpdatePost(post);
            }
            else
            {
                repository.AddPost(post);
            }

            if (await repository.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            repository.RemovePost(id);
            await repository.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
