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
        private readonly IThreadData _threadData;
        private readonly IPostData _postData;
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

        public ThreadsModel(IThreadData threadData, UserManager<User> userManager, IPostData postData)
        {
            _threadData = threadData;
            _userManager = userManager;
            _postData = postData;
        }

        public async Task<IActionResult> OnGetAsync(int id, string subCategoryTitle)
        {
            SubCategoryTitle = subCategoryTitle;
            Threads = await _threadData.GetThreadsInSubCategoryById(id);

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
                };
                await _threadData.AddThread(newThread);
                var threadId = await _threadData.GetThreadIdByTitle(newThread.Title);
                var firstPostInThread = new Post
                {
                    ThreadId = threadId,
                    PostText = NewThreadInput.Description,
                    DatePosted = DateTime.Now,
                    UserId = user.Id

                };
                await _postData.AddPost(firstPostInThread);
                
                Threads = await _threadData.GetThreadsInSubCategoryById(id);
                return Page();
            }

            return Page();
        }
    }
}