using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum.Admin
{
    public class ConfirmRemoveUserFromGroupModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserGroupManager _userGroupManager;

        public ConfirmRemoveUserFromGroupModel(UserManager<User> userManager, IUserGroupManager userGroupManager)
        {
            _userManager = userManager;
            _userGroupManager = userGroupManager;
        }

        public string UserName { get; set; }

        public async Task OnGetAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UserName = user.UserName;

        }


        public async Task<IActionResult> OnPost(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            if (user == null)
            {
                return RedirectToPage("Pages/NotFound");
            }
            await _userGroupManager.RemoveUserFromGroup(user.Id);

            return RedirectToPage("./GroupPage");
        }
    }
}
