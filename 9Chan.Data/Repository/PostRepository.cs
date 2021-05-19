using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    class PostRepository : IPostRepository
    {
        public Task<List<Post>> GetPostsInThreadById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPostsByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
