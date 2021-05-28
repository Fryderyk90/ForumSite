using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public interface IProfilePictureData
    {
        Task<ProfilePicture> UploadPicture(MemoryStream memoryStream, string userId);
        Task<ProfilePicture> GetProfilePictureById(string userId);
        Task<string> DisplayPictureFromDatabase(string userId);
        Task<Byte[]> SaveProfilePicture(MemoryStream memoryStream, User user);
        string DisplayProfilePicture(User user);
    }
}
