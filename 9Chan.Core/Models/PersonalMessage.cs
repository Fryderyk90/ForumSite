

namespace _9Chan.Core.Models
{
    public class PersonalMessage
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User ToUser { get; set; }
        public string Message { get; set; }
    }
}
