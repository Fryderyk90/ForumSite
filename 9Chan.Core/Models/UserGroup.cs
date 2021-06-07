using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Core.Models
{
    public class UserGroup
    {
        public ForumGroup ForumGroup { get; set; }
        public int ForumGroupId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }

    }
}
