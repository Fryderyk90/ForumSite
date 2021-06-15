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

 

        public async Task<ForumGroup> EditGroup(ForumGroup editedGroup)
        {
            _context.Groups.Update(editedGroup);
            await _context.SaveChangesAsync();

            return editedGroup;
        }
   

        public Task<ForumGroup> RemoveUserFromGroup(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
