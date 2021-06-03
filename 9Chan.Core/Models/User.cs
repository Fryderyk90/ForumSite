using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace _9Chan.Core.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {

        public byte[] ProfilePicture { get; set; }
        public int ThreadId { get; set; }
        public List<Thread> Threads { get; set; }
        public int PostId { get; set; }
        public List<Post> Posts { get; set; }
        public IList<UserGroups> UserGroups { get; set; }
    }
}