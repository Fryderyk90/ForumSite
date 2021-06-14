using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class GroupData : IGroupData
    {
        private readonly ForumSiteContext _context;

        public GroupData(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<List<ForumGroup>> GetAllGroups()
        {
            var groups = await _context.Groups.ToListAsync();

            return groups;
        }

        public async Task<ForumGroup> CreateGroup(ForumGroup newGroup)
        {
            var k = await _context.Groups.AddAsync(newGroup);
            await _context.SaveChangesAsync();
         //   await _context.UserGroups.AddAsync(newGroup.ForumGroupId);
            return newGroup;
        }

        public Task<ForumGroup> DeleteGroup(ForumGroup @group)
        {
            throw new NotImplementedException();
        }

        public async Task<ForumGroup> GetGroupById(int groupId)
        {

            // var groupToDelete = await _context.Groups.FirstOrDefaultAsync(group => group.Id == groupId);

            //_context.Groups.Remove(groupToDelete);
            //await  _context.SaveChangesAsync();
            //return groupToDelete;
            return null;
        }

        public async Task<ForumGroup> EditGroup(ForumGroup editedGroup)
        {
            _context.Groups.Update(editedGroup);
            await _context.SaveChangesAsync();

            return editedGroup;
        }

        public Task<ForumGroup> AddUserToGroup(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ForumGroup> AddUserToGroup(string userId,int groupId)
        {
            var addToGroup = await GetGroupById(groupId);

            return addToGroup;

        }

        public Task<ForumGroup> RemoveUserFromGroup(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
