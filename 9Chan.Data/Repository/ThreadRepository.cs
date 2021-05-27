using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public class ThreadRepository : IThreadRepository
    {
        private readonly ForumSiteContext _context;

        public ThreadRepository(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<Thread> AddThread(Thread newThread)
        {
            var subcategories = await _context.SubCategories.ToArrayAsync();
            var inputThread = newThread;
            await _context.Threads.AddAsync(newThread);
            await _context.SaveChangesAsync();
            return newThread;
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

        public async Task DeleteThreadsById(List<Thread> threadsToDelete)
        {
            foreach (var thread in threadsToDelete)
            {
                _context.Remove(thread);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Thread>> getThreads()
        {
            var threads = await _context.Threads.ToListAsync();

            return threads;
        }
    }
}