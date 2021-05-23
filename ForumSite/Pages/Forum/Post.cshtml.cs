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
        public User PostedBy { get; set; }

        public PostModel(IPostRepository postRepository, ForumSiteContext context)
        {
            _postRepository = postRepository;
            _context = context;
        }

        public async Task OnGet(int id)
        {
            Posts = await _postRepository.GetPostsInThreadById(id);
            
            
        }
    }
}
