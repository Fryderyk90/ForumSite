using System;

namespace _9Chan.Core.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsReported { get; set; }
        public string PostText { get; set; }

        public int? ThreadId { get; set; }
        public Thread Thread { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}