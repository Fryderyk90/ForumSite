

using System.Collections.Generic;

namespace _9Chan.Core.Models
{
    public class PersonalMessage
    {
        public int Id { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public string Message { get; set; }
        public List<User> Users { get; set; }
    }
}
