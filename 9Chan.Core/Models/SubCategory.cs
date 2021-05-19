using System.Collections.Generic;

namespace _9Chan.Core.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int? ThreadId { get; set; }
        public List<Thread> Threads { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
