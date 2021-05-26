using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum.Admin
{
    public class Index1Model : PageModel
    {
        private readonly IPostRepository _postRepository;
        
        public Index1Model(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post ReportedPost { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            ReportedPost = await _postRepository.GetPostById(id);

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            await _postRepository.UnReportPost(id);
            ReportedPost = await _postRepository.GetPostById(id);


            return Page();
        }
    }
}
