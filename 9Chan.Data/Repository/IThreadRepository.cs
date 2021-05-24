using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public interface IThreadRepository
    {
        Task<Thread> AddThread(Thread newThread);
        Task<Thread> GetThreadId();
        Task<List<Thread>> GetThreadsInSubCategoryById(int id);
        Task<List<Thread>> getThreads();
    }
}
