
using System;
using System.Collections.Generic;



namespace _9Chan.Core.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsSticky { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public int? SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int? PostId { get; set; }
        public List<Post> Posts { get; set; }
    }
}
