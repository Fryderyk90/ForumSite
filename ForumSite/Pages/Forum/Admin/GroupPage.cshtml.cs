using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using ForumSite.Pages.Forum.Group;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum.Admin
{
    public class GroupPageModel : PageModel
    {
        private readonly IGroupData _groupData;
        private readonly UserManager<User> userManager;

        public List<ForumGroup> Groups { get; set; }
        [BindProperty]
        public InputGroup Input { get; set; }
        public class InputGroup
        {
            public string Name { get; set; }
            public string Description { get; set; }

            public string UserId { get; set; }
        }

        public GroupPageModel(IGroupData groupData, UserManager<User> userManager)
        {
            _groupData = groupData;
            this.userManager = userManager;
        }

        public async Task OnGet()
        {
            var groups = await _groupData.GetAllGroups();
            Groups = groups;


        }

        public async Task<IActionResult> OnPost()
        {
            var newGroup = new ForumGroup();
            //var inputGroup = new InputGroup()
            //{
            //    AdminId = userManager.GetUserId(User),
            //    Name = Input.Name,
            //    Description = Input.Description
            //};
            if (ModelState.IsValid)
            {
                newGroup.Name = Input.Name;
                newGroup.Description = Input.Description;
             //   newGroup.UserId = userManager.GetUserId(User);


                await _groupData.CreateGroup(newGroup);
            }

            var groups = await _groupData.GetAllGroups();
            Groups = groups;
            return Page();
        }
    }
}
