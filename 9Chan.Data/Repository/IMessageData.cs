using _9Chan.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public interface IMessageData
    {
        Task<Message> SendMessage(string from, string to, string message);

        Task<List<Message>> GetMessagesPersonalMessages(string id);

        Task<Message> GetMessageById(int id);

        Task<Message> EditMessageById(int id, string message);

        Task<Message> SendGroupMessage(string from, int groupId, string message);
        Task<List<Message>> GetGroupMessagesByUserId(string UserId);
    }
}