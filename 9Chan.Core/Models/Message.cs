using System;
using System.Collections.Generic;

namespace _9Chan.Core.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public int GroupId { get; set; }
        public DateTime DateSent { get; set; }
        public List<User> Users { get; set; }
        public List<UserGroup> groups { get; set;}
    }
}