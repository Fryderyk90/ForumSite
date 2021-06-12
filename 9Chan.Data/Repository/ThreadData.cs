using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public class ThreadData : IThreadData
    {
        private readonly ForumSiteContext _context;
        private readonly IPostData _postData;

        public ThreadData(ForumSiteContext context, IPostData postData)
        {
            _context = context;
            _postData = postData;
        }

        public async Task<Thread> AddThread(Thread newThread)
        {
            var subcategories = await _context.SubCategories.ToArrayAsync();
            newThread.Title = await _postData.ProfanityFilter(newThread.Title);

            await _context.Threads.AddAsync(newThread);
            await _context.SaveChangesAsync();
            return newThread;
        }

        public Task<Thread> GetThreadId()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetThreadIdByTitle(string threadTitle)
        {
            var thread = await _context.Threads.FirstOrDefaultAsync(t => t.Title == threadTitle);

            var threadId = thread.Id;
            return threadId;
        }

        public async Task<List<Thread>> GetThreadsInSubCategoryById(int id)
        {
            //Where the magic happens DO NOT TOUCH
            
   
            var threads = await _context.Threads.Where(t => t.SubCategoryId == id).ToListAsync();
            var usersInfo = await _context.RegUsers.ToArrayAsync();
            var threadInfo = await _context.Threads.ToArrayAsync();
            var postInfo = await _context.Posts.ToArrayAsync();
            return threads;
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

        public async Task<Thread> FindLatestThreadBySubCategoryId(int subcategoryId)
        {
            var threadsInSubCategory = await GetThreadsInSubCategoryById(subcategoryId);

            var latestThread = threadsInSubCategory.OrderBy(t => t.DateCreated).Take(1);

            return (Thread)latestThread;

        }
    }
}