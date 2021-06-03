using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Core.Models
{
    public class UserGroups
    {
        public User User { get; set; }
        public ForumGroup Group { get; set; }
        [Key, Column(Order = 1)]
        public int GroupId { get; set; }
        [Key, Column(Order = 2)]
        public string UserId { get; set; }
    }
}
