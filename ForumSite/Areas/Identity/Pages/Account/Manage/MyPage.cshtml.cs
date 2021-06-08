using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Areas.Identity.Pages.Account.Manage
{
    public class MyPageModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageData _messages;
        private readonly IPictureData _pictureData;

        public MyPageModel(UserManager<User> userManager, IMessageData personalMessage, IPictureData pictureData)
        {
            _userManager = userManager;
            _messages = personalMessage;
            _pictureData = pictureData;
        }
        [BindProperty]
        public string UserBio { get; set; }

        [BindProperty]
        public PictureFile FileUpload { get; set; }
        public class PictureFile
        {
            [Required]
            [Display(Name = "File")]
            public IFormFile FormFile { get; set; }
        }

        public string ProfilePicture { get; set; }        
        public List<Message> PersonalMessages { get; set; }
        public List<Message> GroupMessages { get; set; }
        public UserManager<User> UserManager { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            UserManager = _userManager;
            PersonalMessages = await _messages.GetMessagesPersonalMessages(userId);
            GroupMessages = await _messages.GetGroupMessagesByUserId(userId);
            ProfilePicture = _pictureData.DisplayProfilePicture(user);
            UserBio = user.Bio;

            return Page();
        }
        public async Task<IActionResult> OnPostUpdateProfilePicture()
        {
            var user = await _userManager.GetUserAsync(User);
            UserManager = _userManager;
        

            var memoryStream = new MemoryStream();
            await FileUpload.FormFile.CopyToAsync(memoryStream);
            await _pictureData.SaveProfilePicture(memoryStream, user);
            PersonalMessages = await _messages.GetMessagesPersonalMessages(user.Id);
            GroupMessages = await _messages.GetGroupMessagesByUserId(user.Id);
            ProfilePicture = _pictureData.DisplayProfilePicture(user);
            //   RedirectToPage("./Index");
            //   Message = "Profile Picture Updated";


            ProfilePicture = _pictureData.DisplayProfilePicture(user);
            UserBio = user.Bio;
            return Page();
        }
        public async Task<IActionResult> OnPostUpdateBio()
        {
            var user = await _userManager.GetUserAsync(User);

            user.Bio = UserBio;
            await _userManager.UpdateAsync(user);
            return RedirectToPage();
        }
    }
}
