using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            [Required(ErrorMessage = "Field Is Required")]
            [Display(Name = "Title")]
            public string ThreadTitle { get; set; }
            [Required(ErrorMessage = "Field Is Required")]
            [Display(Name = "First Post")]
            public string Description { get; set; }
            [Display(Name = "Picture Url")]
            public string PictureUrl { get; set; }
            [Display(Name = "Make Thread Sticky")]
            public bool IsSticky { get; set; }
            public bool IsReported { get; set; }
        }
        public List<ThreadsTable> Table { get; set; }
        public string ReturnUrl { get; set; }
        public class ThreadsTable
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public bool IsSticky { get; set; }
            public string UserName { get; set; }
            public DateTime DateCreated { get; set; }
            public int PostCount { get; set; }
            public string LatestPostUserName { get; set; }
            public DateTime LatestPostDate { get; set; }
        }

        public ThreadsModel(IThreadData threadData, UserManager<User> userManager, IPostData postData)
        {
            _threadData = threadData;
            _userManager = userManager;
            _postData = postData;
        }

        public async Task<IActionResult> OnGetAsync(int id, string subCategoryTitle, string categoryTitle)
        {
            SubCategoryTitle = subCategoryTitle;
            ReturnUrl = $"/Forum/Threads/SubCategories?id={id}&categoryTitle={categoryTitle}";
            var threads = await _threadData.GetThreadsInSubCategoryById(id);
            var table = CreateThreadsTable(threads);
            
            
            var sortTable = table
                .OrderByDescending(t => t.IsSticky == true).
                ThenByDescending(t => t.DateCreated)
                .ToList();
            Table = sortTable;
            return Page();
        }

        private List<ThreadsTable> CreateThreadsTable(List<Thread> threads)
        {

            var threadTable = new List<ThreadsTable>();
            foreach (var thread in threads)
            {
                foreach (var post in thread.Posts.OrderByDescending(p => p.DatePosted).Take(1))
                {
                    var item = new ThreadsTable
                    {
                        Id = thread.Id,
                        Title = thread.Title,
                        IsSticky = thread.IsSticky,
                        UserName = thread.User.UserName,
                        DateCreated = thread.DateCreated,
                        PostCount = thread.Posts.Count(),
                        LatestPostUserName = post.User.UserName,
                        LatestPostDate = post.DatePosted
                    };
                    threadTable.Add(item);
                }
            }
            return threadTable;
        }
        public async Task<IActionResult> OnPost(int id, string subCategoryTitle)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var newThread = new Thread()
                {
                    SubCategoryId = id,
                    UserId = user.Id,
                    DateCreated = DateTime.Now,
                    IsSticky = NewThreadInput.IsSticky,
                    Title = NewThreadInput.ThreadTitle,
                };
                await _threadData.AddThread(newThread);
                var threadId = await _threadData.GetThreadIdByTitle(newThread.Title);
                var firstPostInThread = new Post
                {
                    ThreadId = threadId,
                    PostText = NewThreadInput.Description,
                    DatePosted = DateTime.Now,
                    UserId = user.Id,
                    Picture = NewThreadInput.PictureUrl


                };
                await _postData.AddPost(firstPostInThread);

                SubCategoryTitle = subCategoryTitle;
                var threads = await _threadData.GetThreadsInSubCategoryById(id);
                var table = CreateThreadsTable(threads);


                var sortTable = table
                    .OrderByDescending(t => t.IsSticky == true).
                    ThenByDescending(t => t.DateCreated)
                    .ToList();
                Table = sortTable;
                return Page();
            }

            return Page();
        }

    }
}