using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public interface IPersonalMessageRepository
    {
        Task<PersonalMessage> SendMessage(string from, string to, string message);
        Task<List<PersonalMessage>> GetMessagesToInbox(string id);
        Task<PersonalMessage> GetMessageById(int id);
        Task<PersonalMessage> EditMessageById(int id, string message);
    }
}
