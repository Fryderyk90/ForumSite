using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum
{
    public class ConfirmReportModel : PageModel
    {
        private readonly IPostData _postRepository;

        public ConfirmReportModel(IPostData postRepository)
        {
            _postRepository = postRepository;
        }

        public string ReportedUsername { get; set; }
        public string Message { get; set; }
        public string ReportedPostText { get; set; }
        public Post Post { get; set; }
        public ReportedPost Reported { get; set; }

        public class ReportedPost
        {
            public bool IsReported { get; set; }
        }

        public void OnGet(string username, string post)
        {
            ReportedUsername = username;
            Message = $"are you sure you want to report {username}";
            ReportedPostText = post;
        }

        public async Task<IActionResult> OnPost(int id,string username)
        {
            var postToUpDate = await _postRepository.GetPostById(id);
            postToUpDate.IsReported = true;

            await _postRepository.UpdatePost(postToUpDate);

            Post = await _postRepository.GetPostById(id);
            Message = $"Post by {username} reported";
            return Page();
        }
    }
}