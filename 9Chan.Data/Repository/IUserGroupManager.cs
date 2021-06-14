using _9Chan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public interface IUserGroupManager
    {
        Task<UserGroup> AddUserToGroup(string userId, int forumgroupId);
        Task<UserGroup> RemoveUserFromGroup(string userId);
        bool IsUserInGroup(string userId);
        int? GetGroupIdByUserId(string userId);
        ForumGroup GetGroupByUserId(string userId);
    }
}
