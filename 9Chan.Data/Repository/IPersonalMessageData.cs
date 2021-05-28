using _9Chan.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public interface IPersonalMessageData
    {
        Task<PersonalMessage> SendMessage(string from, string to, string message);

        Task<List<PersonalMessage>> GetMessagesToInbox(string id);

        Task<PersonalMessage> GetMessageById(int id);

        Task<PersonalMessage> EditMessageById(int id, string message);
    }
}