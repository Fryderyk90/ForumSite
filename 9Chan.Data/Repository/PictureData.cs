using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace _9Chan.Data.Repository
{
    public class PictureData : IPictureData
    {
        private readonly ForumSiteContext _context;
        private readonly UserManager<User> _userManager;

        public PictureData(ForumSiteContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       

        public async Task<Byte[]> SaveProfilePicture(MemoryStream memoryStream, User user)
        {
            if (memoryStream.Length < 2097152)
            {
                
                
                user.ProfilePicture = memoryStream.ToArray();

                  _context.RegUsers.Update(user);
                await _context.SaveChangesAsync();

                return user.ProfilePicture;
            }

            return null;
        }


        public async Task<Byte[]> GetProfilePictureById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var profilePicture = user.ProfilePicture;
            
            if (profilePicture != null)
            {
                return profilePicture;
            }
            
            return null;
        }

        public string DisplayProfilePicture(User user)
        {
            var image = user.ProfilePicture;
            var contentType = "image/jpeg";
            if (image != null)
            {
                var convertArrayToImage = string.Format("data:{0};base64,{1}",
                    contentType, Convert.ToBase64String(image));
                return convertArrayToImage;
            }
            

            return null;
        }   
        public Task DeleteProfilePicture(Picture profilePicture)
        {
            return null;
        }

        public Task<Picture> SavePicture(string postId, string pictureLink)
        {
            throw new NotImplementedException();
        }

        public Task<Picture> GetPictureByPostId(int postId)
        {
            throw new NotImplementedException();
        }
    }
}
