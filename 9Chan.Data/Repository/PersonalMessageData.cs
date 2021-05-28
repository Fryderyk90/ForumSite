using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public class PersonalMessageData : IPersonalMessageData
    {
        private readonly ForumSiteContext _context;

        public PersonalMessageData(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<PersonalMessage> SendMessage(string from, string to, string message)
        {
            var newMessage = new PersonalMessage
            {
                FromUserId = from,
                ToUserId = to,
                Message = message
            };
            await _context.PersonalMessages.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            return newMessage;
        }

        public async Task<List<PersonalMessage>> GetMessagesToInbox(string id)
        {
            var users = await _context.RegUsers.ToArrayAsync();
            var messages = await _context.PersonalMessages
                .Where(pm => pm.ToUserId == id).ToListAsync();

            return messages;
        }

        public async Task<PersonalMessage> GetMessageById(int id)
        {
            var users = await _context.RegUsers.ToArrayAsync();
            var message = await _context.PersonalMessages.FindAsync(id);

            return message;
        }

        public async Task<PersonalMessage> EditMessageById(int id, string message)
        {
            var users = await _context.RegUsers.ToArrayAsync();
            var getMessage = await GetMessageById(id);

            getMessage.Message = message;
            _context.Update(getMessage);

            await _context.SaveChangesAsync();

            return getMessage;
        }
    }
}