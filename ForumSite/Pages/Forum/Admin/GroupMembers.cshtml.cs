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
    public class GroupMembersModel : PageModel
    {

        private readonly IUserGroupManager _userGroupManager;
        private readonly UserManager<User> _userManger;
        private readonly IGroupData _groupData;


        public GroupMembersModel(IUserGroupManager userGroupManager, UserManager<User> userManger, IGroupData groupData)
        {
            _userGroupManager = userGroupManager;
            _userManger = userManger;
            _groupData = groupData;
        }

        public List<User> GroupMembers { get; set; }
        public string GroupName { get; set; }


        public async Task OnGetAsync(int id)
        {
            var group = await _groupData.GetGroupById(id);
            var groupMembers = await _userGroupManager.GetGroupMembers(group.ForumGroupId);
            if (groupMembers.Count() > 0)
            {
                GroupName = group.Name;
                GroupMembers = groupMembers;
            }
            else
                GroupName = "No members in Group";
        }
    }
}
