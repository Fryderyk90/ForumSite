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
    public class UserProfileModel : PageModel
    {
        private readonly UserManager<User> _UserManager;
        private readonly IPictureData _profilePictureData;
        private readonly IUserGroupManager _userGroupManager;
        

        public string UserName { get; set; }
        public string UserBio { get; set; }
        public string ProfilePicture { get; set; }
        public string GroupName { get; set; }
        public UserProfileModel(UserManager<User> userManager, IPictureData profilePictureData, IUserGroupManager userGroupManager)
        {
            _UserManager = userManager;
            _profilePictureData = profilePictureData;
            _userGroupManager = userGroupManager;
        }

        public async Task OnGetAsync(string userId)
        {
            var user = await _UserManager.FindByIdAsync(userId);
            UserName = user.UserName;
            var group = _userGroupManager.GetGroupByUserId(userId);
           
            if (group == null)
            {
                GroupName = "User is not in Group";
            }
            else GroupName = group.Name;
            if (string.IsNullOrEmpty(user.Bio))
            {
                UserBio = "User Has No Bio";
            }
            else
                UserBio = user.Bio;

            ProfilePicture = _profilePictureData.DisplayProfilePicture(user);
            
        }
    }
}
