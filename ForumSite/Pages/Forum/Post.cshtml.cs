using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum
{
    public class PostModel : PageModel
    {
        private readonly IPostRepository _postRepository;
        private readonly ForumSiteContext _context;

        public List<Post> Posts { get; set; }
        public UserManager<User> PostedBy { get; }
        [BindProperty]
        public NewPost InputPost { get; set; }
        public class NewPost
        {
            public string InputText { get; set; }

        }

        public PostModel(IPostRepository postRepository, UserManager<User> postedBy)
        {
            _postRepository = postRepository;

            PostedBy = postedBy;
        }

        public async Task OnGet(int id)
        {
            Posts = await _postRepository.GetPostsInThreadById(id);


        }
        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var inputUser = await PostedBy.GetUserAsync(User);
                var newPost = new Post
                {
                    ThreadId = id,
                    UserId = inputUser.Id,
                    DatePosted = DateTime.Now,
                    PostText = InputPost.InputText,
                    IsReported = false,


                };
                await _postRepository.AddPostToThreadById(newPost);
                Posts = await _postRepository.GetPostsInThreadById(id);
            }
            return Page();
        }
    }
}
