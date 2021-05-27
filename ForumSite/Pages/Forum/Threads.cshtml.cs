using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [BindProperty]
        public NewThread NewThreadInput { get; set; }

        public class NewThread
        {
            public int SubCategoryId { get; set; }
            public string UserId { get; set; }
            public string ThreadTitle { get; set; }
            public string Description { get; set; }
            public bool IsReported { get; set; }
        }

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
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var newThread = new Thread()
                {
                    SubCategoryId = id,
                    UserId = user.Id,
                    DateCreated = DateTime.Now,
                    IsSticky = false,
                    Title = NewThreadInput.ThreadTitle,
                    Description = NewThreadInput.Description
                };
                await _threadRepository.AddThread(newThread);
                Threads = await _threadRepository.GetThreadsInSubCategoryById(id);
                return Page();
            }

            return Page();
        }
    }
}