using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum
{
    public class ThreadsModel : PageModel
    {
        private readonly IThreadRepository _threadRepository;
        public List<Thread> Threads { get; set; }
        public ThreadsModel(IThreadRepository threadRepository)
        {
            _threadRepository = threadRepository;
        }

        public async Task OnGetAsync(int id)
        {
            Threads = await _threadRepository.GetThreadsInSubCategoryById(id);
        }
    }
}
