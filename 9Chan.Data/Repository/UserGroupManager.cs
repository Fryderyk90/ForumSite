using _9Chan.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public class UserGroupManager : IUserGroupManager
    {
        private readonly ForumSiteContext _context;
        private readonly UserManager<User> _userManager;


        public UserGroupManager(ForumSiteContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<UserGroup> AddUserToGroup(string userId, int forumGroupId)
        {
            var userToGroup = new UserGroup
            {
                UserId = userId,
                ForumGroupId = forumGroupId
            };
            if(!GetUserInGroup(userId))
            {
                var Groups = _context.Groups.ToList();
                await _context.AddAsync(userToGroup);
                await _context.SaveChangesAsync();
                return userToGroup;
            }
            userToGroup = null;
            return userToGroup;
        }

        public int? GetGroupIdByUserId(string userId)
        {

            var group = _context.UserGroups.FirstOrDefault(group => group.UserId == userId);
            if (group == null)
            {
                return null;
            }
            else

            return  group.ForumGroupId;           
        }

        public async Task<List<User>> GetGroupMembers(int groupId)
        {
            var members = _context.UserGroups.Where(ug => ug.ForumGroupId == groupId).ToList();

            var groupmembers = new List<User>();
            foreach (var member in members)
            {
                var groupmember = await _userManager.FindByIdAsync(member.UserId); 

                 groupmembers.Add(groupmember);
            }
            return groupmembers;

        }

        public bool IsUserInGroup(string userId)
        {
            var user = _context.UserGroups.FirstOrDefault(ug => ug.UserId == userId);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<UserGroup> RemoveUserFromGroup(string userId)
        {
            var remove = _context.UserGroups.FirstOrDefault(ug => ug.UserId == userId);
            
            var userToRemove = _context.UserGroups.Remove(remove);
            await _context.SaveChangesAsync();
            
            return remove;


        }

        ForumGroup IUserGroupManager.GetGroupByUserId(string userId)
        {
            
            var groupId = GetGroupIdByUserId(userId);
            if (groupId == null)
            {
                return null;
            }
            
            var group =  _context.Groups.FirstOrDefault(group => group.ForumGroupId == groupId);
            
            return group;
        }

        private bool GetUserInGroup(string userId)
        {
            
            var userExists =_context.UserGroups.FirstOrDefault(user => user.UserId == userId);
            if (userExists != null)
            {
                return true;
            }
            return false;
        }
    }
}
