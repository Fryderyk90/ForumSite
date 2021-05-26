using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ForumSite.Pages.Forum.Admin
{
    public class RoleHandelingModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleHandelingModel(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public string RoleName { get; set; }

        public IList<User> Users { get; set; }
        public IList<User> Admins { get; set; }

        public List<IdentityRole> IdentityRoles { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            IdentityRoles = await _roleManager.Roles.ToListAsync();
            Users = await _userManager.GetUsersInRoleAsync("User");
            Admins = await _userManager.GetUsersInRoleAsync("Admin");
            
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (RoleName != null)
            {
                await CreateRole(RoleName);
            }

            return RedirectToPage("./Index");
        }

        public async Task CreateRole(string RoleName)
        {
            bool exists = await _roleManager.RoleExistsAsync(RoleName);

            if (!exists)
            {
                var role = new IdentityRole
                {
                    Name = RoleName,

                };
                await _roleManager.CreateAsync(role);
            }

        }
    }
}
