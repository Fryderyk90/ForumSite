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
    public class ConfirmReportModel : PageModel
    {
        private readonly IPostRepository _postRepository;

        public ConfirmReportModel(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post Post { get; set; }
        public ReportedPost Reported { get; set; }

        public class ReportedPost
        {
            public bool IsReported { get; set; }
        }
        public async Task OnGet(int id)
        {
           Post = await _postRepository.GetPostById(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var postToUpDate = await _postRepository.GetPostById(id);
            postToUpDate.IsReported = true;

            
            await _postRepository.UpdatePost(postToUpDate);

            Post = await _postRepository.GetPostById(id);
            return Page();
        }
    }
}
