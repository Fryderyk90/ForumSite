using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ForumSiteContext _context;

        public PostRepository(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetPostsInThreadById(int id)
        {

            var posts = await _context.Posts.Where(s => s.ThreadId == id).ToListAsync();
            
            //Where the magic happens DO NOT TOUCH
            var users = await _context.RegUsers.ToArrayAsync();

            return posts;
        }

        public Task<List<Post>> GetPostsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        //public Task<Post> AddPostToThreadById(int id)
        //{

        //    _context.Posts.AddAsync();
        //}
    }
}
