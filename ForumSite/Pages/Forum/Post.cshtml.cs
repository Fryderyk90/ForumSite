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
        public Post Post { get; set; }

        public PostModel(IPostRepository postRepository, ForumSiteContext context, UserManager<User> postedBy)
        {
            _postRepository = postRepository;
            _context = context;
            PostedBy = postedBy;
        }

        public async Task OnGet(int id)
        {
            Posts = await _postRepository.GetPostsInThreadById(id);
            
            
        }
        //TODO FIX THREAD ID THROWS NULLEXCEPTION
        public async Task<IActionResult> OnPost(int? id)
        {
            Post.ThreadId = id;
            var postedBy = await PostedBy.GetUserAsync(User);
            
            Post.UserId = postedBy.Id;
            
            Post.DatePosted = DateTime.Now;
            await _postRepository.AddPostToThreadById(Post);

            return Page();
        }
    }
}
