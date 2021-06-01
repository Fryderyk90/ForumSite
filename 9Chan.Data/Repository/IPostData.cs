using _9Chan.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public interface IPostData
    {
        Task<List<Post>> GetPostsInThreadById(int id);

        Task<List<Post>> GetPostsByUserId(string userId);
        Task<string> ProfanityFilter(string input);

        Task<Post> GetPostById(int postId);

        Task<Post> UpdatePost(Post post);

        Task<Post> AddPost(Post newPost);

        Task<Post> DeletePostById(int id);

        Task DeletePostsInThread(List<Post> postsToDelete);

        Task<List<Post>> ReportedPosts();

        Task<Post> UnReportPost(int id);
    }
}