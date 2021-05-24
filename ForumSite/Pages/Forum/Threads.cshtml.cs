using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum
{
    public class ThreadsModel : PageModel
    {
        private readonly IThreadRepository _threadRepository;
        public UserManager<User> _userManager { get; }
        public string SubCategoryTitle { get; set; }
        public List<Thread> Threads { get; set; }
        [BindProperty]
        public Thread InputThread { get; set; }
        public ThreadsModel(IThreadRepository threadRepository, UserManager<User> userManager)
        {
            _threadRepository = threadRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int id, string subCategoryTitle)
        {
            SubCategoryTitle = subCategoryTitle;
            Threads = await _threadRepository.GetThreadsInSubCategoryById(id);

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            InputThread.SubCategoryId = id;

            var user = await _userManager.GetUserAsync(User);
            InputThread.UserId = user.Id;
            InputThread.DateCreated = DateTime.Now;
            await _threadRepository.AddThread(InputThread);
            return Page();
        }
    }
}
