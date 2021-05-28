using _9Chan.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public interface IThreadData
    {
        Task<Thread> AddThread(Thread newThread);

        Task<Thread> GetThreadId();

        Task<List<Thread>> GetThreadsInSubCategoryById(int id);

        Task DeleteThreadsById(List<Thread> threadsToDelete);

        Task<List<Thread>> getThreads();
    }
}