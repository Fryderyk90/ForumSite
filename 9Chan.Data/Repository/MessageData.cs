using _9Chan.Core.Models;
using _9Chan.Data.Services;
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
        private readonly IUserGroupManager _userGroupManager;
        private readonly IEncryption _encryption;
        private readonly IProfanityFilter _profanityFilter;

        public MessageData(ForumSiteContext context, IUserGroupManager userGroupManager, IEncryption encryption, IProfanityFilter profanityFilter)
        {
            _context = context;
            _userGroupManager = userGroupManager;
            _encryption = encryption;
            _profanityFilter = profanityFilter;
        }

        public async Task<Message> SendMessage(string from, string to, string message)
        {

            message = await _profanityFilter.Filter(message);
            var newMessage = new Message
            {
                From = from,
                To = to,
                Text = _encryption.EncryptText(message),
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
                .Where(pm => pm.To == id && pm.GroupId == null).ToListAsync();

            DecryptAllMessages(messages);

            return messages;
        }

        private List<Message> DecryptAllMessages(List<Message> messages)
        {
            var decryptedMessages = new List<Message>();
            foreach (var message in messages)
            {
                message.Text = _encryption.DecryptText(message.Text);

                decryptedMessages.Add(message);
            }
            return decryptedMessages;
        }

        public async Task<Message> GetMessageById(int id)
        {
            var users = await _context.RegUsers.ToArrayAsync();
            var message = await _context.Messages.FindAsync(id);

            message.Text = _encryption.DecryptText(message.Text);

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

        public async Task<Message> SendGroupMessage(string from, int groupId, string message)
        {
            message = await _profanityFilter.Filter(message);
            var newMessage = new Message
            {
                From = from,
                GroupId = groupId,
                Text = _encryption.EncryptText(message),
                DateSent = DateTime.Now
            };
            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            return newMessage;
        }

        public async Task<List<Message>> GetGroupMessagesByUserId(string userId)
        {
            
            var userGroupId = _userGroupManager.GetGroupIdByUserId(userId);
            
            
            var groupMessages = await _context.Messages.Where(message => message.GroupId == userGroupId).ToListAsync();
            var group = await _context.Groups.ToArrayAsync();
            return DecryptAllMessages(groupMessages); 

        }

      
    }
}