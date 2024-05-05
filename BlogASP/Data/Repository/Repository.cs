using BlogASP.Models;

namespace BlogASP.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public Post GetPost(uint id)
        {
            foreach (var post in _context.Posts)
            {
                if (post.Id == id)
                    return post;
            }
            return new Post()
            {
                Id = id,
            };
        }

        public List<Post> GetAllPostList()
        {
            return [.. _context.Posts];
        }

        public List<Post> GetAllPostList(string category)
        {
            var result = new List<Post>();

            foreach (var post in _context.Posts)
            {
                if (string.Equals(post.Category, category, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(post);
                }
            }
            return result;
        }


        public void AddPost(Post post)
        {
            if (post == null)
                return;

            _context.Posts.Add(post);
        }

        public void RemovePost(uint id)
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
