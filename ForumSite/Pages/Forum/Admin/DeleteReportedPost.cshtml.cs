using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum.Admin
{
    public class DeleteReportedPostModel : PageModel
    {
        private readonly IPostData _postRepository;
        public Post Post { get; set; }

        public DeleteReportedPostModel(IPostData postRepository)
        {
            _postRepository = postRepository;
        }

        public string ReportedPost { get; set; }

        public async Task OnGet(string title, int id)
        {
            Post = await _postRepository.GetPostById(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var postToDelete = await _postRepository.GetPostById(id);
            if (postToDelete == null)
            {
                return RedirectToPage("Pages/NotFound");
            }
            var deletedPost = await _postRepository.DeletePostById(id);

            return RedirectToPage("./index");
        }
    }
}