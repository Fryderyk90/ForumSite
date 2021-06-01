using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum.Admin
{
    public class Index1Model : PageModel
    {
        private readonly IPostData _postRepository;

        public Index1Model(IPostData postRepository)
        {
            _postRepository = postRepository;
        }

        public string Text { get; set; }
        public string Username { get; set; }
        public Post ReportedPost { get; set; }

        public async Task<IActionResult> OnGet(int id, string text,string userName)
        {
            Text = text;
            Username = userName;
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