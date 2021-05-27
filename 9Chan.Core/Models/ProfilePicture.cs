using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Core.Models
{
    public class ProfilePicture
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
        public string UserId { get; set; }
    }
}
