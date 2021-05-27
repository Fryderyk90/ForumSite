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
    public class PostModel : PageModel
    {
        private readonly IPostRepository _postRepository;
        private readonly IProfilePictureRepository _profilePictureRepository;

        public List<PostWithProfilePictures> Posts { get; set; }

        public class PostWithProfilePictures
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public DateTime DatePosted { get; set; }
            public string PostText { get; set; }
            public string ProfilePicture { get; set; }
        }

        public UserManager<User> PostedBy { get; }

        [BindProperty]
        public NewPost InputPost { get; set; }

        public class NewPost
        {
            public string InputText { get; set; }
        }

        public PostModel(IPostRepository postRepository, UserManager<User> postedBy, IProfilePictureRepository profilePictureRepository)
        {
            _postRepository = postRepository;

            PostedBy = postedBy;
            _profilePictureRepository = profilePictureRepository;
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