using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Core.Models
{
    public class ForumGroup
    {
        public int ForumGroupId { get; set; }
    //  public string UserId { get; set; }
        public string AdminId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> User { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }


    }
}
