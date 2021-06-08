using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        public int ThreadId { get; set; }
        public string CommentText { get; set; }
        public string Picture { get; set; }
        public DateTime DateReplied { get; set; }
        public User User { get; set; }
    }
}
