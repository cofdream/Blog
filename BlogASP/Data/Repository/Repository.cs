using BlogASP.Models;
using System.Collections;
using System.ComponentModel;

namespace BlogASP.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public Post GetPost(int id)
        {
            foreach (var post in _context.Posts)
            {
                if (post.Id == id)
                    return post;
            }
            return null;
        }

        public List<Post> GetAllPostList()
        {
            return _context.Posts.ToList();
        }

        public void AddPost(Post post)
        {
            if (post == null)
                return;

            _context.Posts.Add(post);
        }

        public void RemovePost(int id)
        {
            var post = GetPost(id);
            if (post == null)
                return;

            _context.Posts.Remove(post);
        }

        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
