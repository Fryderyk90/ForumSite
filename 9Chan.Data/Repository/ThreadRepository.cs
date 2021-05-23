using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class ThreadRepository : IThreadRepository
    {
        private readonly ForumSiteContext _context;

        public ThreadRepository(ForumSiteContext context)
        {
            _context = context;
        }

        public Task<Thread> AddThread(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Thread> GetThreadId()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Thread>> GetThreadsInSubCategoryById(int id)
        {
            //Where the magic happens DO NOT TOUCH
            var usersInfo = await _context.RegUsers.ToArrayAsync();
            
            
            return await _context.Threads.Where(t => t.SubCategoryId == id).ToListAsync();
        }

        public async Task<List<Thread>> getThreads()
        {
            var threads = await _context.Threads.ToListAsync();
            
            return threads;
        }
    }
}
