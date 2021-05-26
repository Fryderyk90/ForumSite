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
    public class PromoteToAdminModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ForumSiteContext _context;

        public User UserToPromote { get; set; }
        public PromoteToAdminModel(UserManager<User> userManager,ForumSiteContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task OnGet(string id)
        {

           UserToPromote = await _userManager.FindByIdAsync(id);
           
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var promoteUser = await _userManager.FindByIdAsync(id);

            var roleAssigner = await _userManager.AddToRoleAsync(promoteUser, "Admin");


            Console.WriteLine();
            return RedirectToPage("./Index");
        }
    }
}
