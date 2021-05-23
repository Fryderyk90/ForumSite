using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public interface IPostRepository
    {
        Task<List<Post>> GetPostsInThreadById(int id);
        Task<List<Post>> GetPostsByUserId(string userId);
        //Task<Post> AddPostToThreadById(int id);
    }
}
