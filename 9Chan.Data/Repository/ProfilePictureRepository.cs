using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class ProfilePictureRepository : IProfilePictureRepository
    {
        private readonly ForumSiteContext _context;

        public ProfilePictureRepository(ForumSiteContext context)
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

        public async Task<ProfilePicture> GetProfilePictureById(string userId)
        {

            var profilePicture = await _context.ProfilePictures.FirstOrDefaultAsync(p => p.UserId == userId);
            
            if (profilePicture != null)
            {
                return profilePicture;
            }
            
            return null;
        }

        public async Task<string> DisplayPictureFromDatabase(string userId)
        {
            var picture = await GetProfilePictureById(userId);
            var image = picture.Content;
            var contentType = "image/jpeg";
            var convertedImage = string.Format("data:{0};base64,{1}",
                contentType, Convert.ToBase64String(image));


            return convertedImage;
        }
    }
}
