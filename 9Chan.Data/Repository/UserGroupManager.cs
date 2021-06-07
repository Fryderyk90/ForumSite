﻿using _9Chan.Core.Models;
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
        

        public UserGroupManager(ForumSiteContext context)
        {
            _context = context;
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

        public async Task<UserGroup> RemoveUserFromGroup(string userId)
        {
            var remove = _context.UserGroups.FirstOrDefault(ug => ug.UserId == userId);
            
            var userToRemove = _context.UserGroups.Remove(remove);
            await _context.SaveChangesAsync();
            
            return remove;


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
