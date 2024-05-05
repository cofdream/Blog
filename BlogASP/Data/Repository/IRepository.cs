using BlogASP.Models;

namespace BlogASP.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(uint id);
        List<Post> GetAllPostList();
        List<Post> GetAllPostList(string category);
        void AddPost(Post post);
        void RemovePost(uint id);
        void UpdatePost(Post post);

        Task<bool> SaveChangesAsync();
    }
}
