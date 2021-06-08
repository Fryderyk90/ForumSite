using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public interface IPictureData
    {
        Task<Picture> SavePicture(string postId, string pictureLink);
        Task<Picture> GetPictureByPostId(int postId);
        Task<Byte[]> GetProfilePictureById(string userId);
        Task<Byte[]> SaveProfilePicture(MemoryStream memoryStream, User user);
        string DisplayProfilePicture(User user);
    }
}
