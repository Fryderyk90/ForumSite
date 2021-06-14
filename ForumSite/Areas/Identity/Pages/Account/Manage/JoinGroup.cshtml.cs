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
        private readonly IUserGroupManager _userGroupManager;
        public JoinGroupModel(IGroupData groupData, UserManager<User> userManager, IUserGroupManager userGroupManager)
        {
            _groupData = groupData;
            _userManager = userManager;
            _userGroupManager = userGroupManager;
        }
        [TempData]
        public string Message { get; set; }
        [TempData]
        public  string NameOfGroup { get; set; }
        public List<ForumGroup> Groups { get; set; }
        public UserGroup AddToGroup { get; set; }
        public async Task OnGet()
        {
            var groups = await _groupData.GetAllGroups();
            Groups = groups;
        }

        public async Task<IActionResult> OnPost(string userId, int groupId)
        {
            
            AddToGroup = await _userGroupManager.AddUserToGroup(userId, groupId);
            
            if (AddToGroup == null)
            {
                
                Message = $"Already In Group";
                
                var groupss = await _groupData.GetAllGroups();
                Groups = groupss;
                return Page();
            }
            var nameOfGroup = AddToGroup.ForumGroup.Name;
            Message = $"Joined {nameOfGroup}";
            var groups = await _groupData.GetAllGroups();
            Groups = groups;
            
            return Page();
        }

        public async Task<IActionResult> OnPostLeaveGroup()
        {
            var user = await _userManager.GetUserAsync(User);
          
            await _userGroupManager.RemoveUserFromGroup(user.Id);
            var groups = await _groupData.GetAllGroups();
            Groups = groups;
            Message = "Left Group";
            return RedirectToPage();
        }
    }
}
