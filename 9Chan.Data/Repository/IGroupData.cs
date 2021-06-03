using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public interface IGroupData
    {
        Task<List<ForumGroup>> GetAllGroups();
        Task<ForumGroup> CreateGroup(ForumGroup newGroup);
        Task<ForumGroup> DeleteGroup(ForumGroup group);
        Task<ForumGroup> GetGroupById(int groupId);
        Task<ForumGroup> EditGroup(ForumGroup editedGroup);
        Task<ForumGroup> AddUserToGroup(string userId);
        Task<ForumGroup> RemoveUserFromGroup(string userId);
    }
}
