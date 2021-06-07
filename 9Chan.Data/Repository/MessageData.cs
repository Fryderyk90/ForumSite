using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public class MessageData : IMessageData
    {
        private readonly ForumSiteContext _context;

        public MessageData(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<Message> SendMessage(string from, string to, string message)
        {
            var newMessage = new Message
            {
                From = from,
                To = to,
                Text = message,
                DateSent = DateTime.Now               
            };
            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            return newMessage;
        }

        public async Task<List<Message>> GetMessagesPersonalMessages(string id)
        {
            var users = await _context.RegUsers.ToArrayAsync();
            var messages = await _context.Messages
                .Where(pm => pm.To == id).ToListAsync();

            return messages;
        }

        public async Task<Message> GetMessageById(int id)
        {
            var users = await _context.RegUsers.ToArrayAsync();
            var message = await _context.Messages.FindAsync(id);

            return message;
        }

        public async Task<Message> EditMessageById(int id, string message)
        {
            var users = await _context.RegUsers.ToArrayAsync();
            var getMessage = await GetMessageById(id);

            getMessage.Text = message;
            _context.Update(getMessage);

            await _context.SaveChangesAsync();

            return getMessage;
        }

        public async Task<Message> SendGroupMessage(string from, string groupId, string message)
        {
            var newMessage = new Message
            {
                From = from,
                To = groupId,
                Text = message,
                DateSent = DateTime.Now
            };
            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            return newMessage;
        }

        public Task<Message> GetGroupMessageById(string UserId)
        {
            

        }
    }
}