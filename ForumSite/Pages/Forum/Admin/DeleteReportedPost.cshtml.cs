using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum.Admin
{
    public class DeleteReportedPostModel : PageModel
    {
        private readonly IPostRepository postRepository;

        public DeleteReportedPostModel(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public string ReportedPost { get; set; }
        public async Task OnGet(string title,int id)
        {
            ReportedPost = title;
            await postRepository.GetPostById(id);
        }

        public async Task OnPost(int id)
        {
           var postToDelete = await postRepository.GetPostById(id);
           
        }
    }
}
