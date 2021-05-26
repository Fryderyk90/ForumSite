using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum.Admin
{
    public class RemoveAdminRoleModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        public User OutputUser { get; set; }
     

        public RemoveAdminRoleModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGet(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            OutputUser = user;
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var user = await _userManager.FindByIdAsync(id);
                await _userManager.RemoveFromRoleAsync(user, "Admin");
            }
            

            return RedirectToPage("./Index");
        }
    }
}
