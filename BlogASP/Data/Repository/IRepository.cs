using BlogASP.Models;

namespace BlogASP.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPostList();
        void AddPost(Post post);
        void RemovePost(int id);
        void UpdatePost(Post post);

        Task<bool> SaveChangesAsync();
    }
}
