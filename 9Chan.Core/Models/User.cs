using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace _9Chan.Core.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        [PersonalData]
        public byte[] ProfilePicture { get; set; }
        [PersonalData]
        public string Bio { get; set; }
        public List<Thread> Threads { get; set; }
        public List<Post> Posts { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }

    }
}