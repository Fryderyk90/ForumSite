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
    public class JoinGroupModel : PageModel
    {
        private readonly IGroupData _groupData;
        private UserManager<User> _userManager;
        public JoinGroupModel(IGroupData groupData, UserManager<User> userManager)
        {
            _groupData = groupData;
            _userManager = userManager;
        }

        public List<ForumGroup> Groups { get; set; }
        public async Task OnGet()
        {
            var groups = await _groupData.GetAllGroups();
            Groups = groups;
        }

        public async Task<IActionResult> OnPost(string userId, int groupId)
        {
           await _groupData.AddUserToGroup(userId);
            return Page();
        }
    }
}
