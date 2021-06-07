using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace _9Chan.Data.Repository
{
    public class ProfilePictureData : IProfilePictureData
    {
        private readonly ForumSiteContext _context;

        public ProfilePictureData(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<ProfilePicture> UploadPicture(MemoryStream memoryStream, string userId)
        {

            if (memoryStream.Length < 2097152)
            {
                var file = new ProfilePicture
                {
                    Content = memoryStream.ToArray(),
                    UserId = userId

                };
                await _context.ProfilePictures.AddAsync(file);
                await _context.SaveChangesAsync();

                return file;
            }

            return null;

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


        public async Task<ProfilePicture> GetProfilePictureById(string userId)
        {

            var profilePicture = await _context.ProfilePictures.FirstOrDefaultAsync(p => p.UserId == userId);
            
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




        public async Task<string> DisplayPictureFromDatabase(string userId)
        {
            var picture = await GetProfilePictureById(userId);
            var image = picture.Content;
            var contentType = "image/jpeg";
            var convertedImage = $"data:{contentType};base64,{Convert.ToBase64String(image)}";


            return convertedImage;
        }

        public Task DeleteProfilePicture(ProfilePicture profilePicture)
        {
            return null;
        }
    }
}
