using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace ForumSite.Areas.Identity.Pages.Account.Manage
{
    public class UploadProfilePictureModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ForumSiteContext _context;
        private readonly IProfilePictureRepository _profilePictureRepository;

        public UploadProfilePictureModel(UserManager<User> userManager, ForumSiteContext context, IProfilePictureRepository profilePictureRepository)
        {
            _userManager = userManager;
            _context = context;
            _profilePictureRepository = profilePictureRepository;
        }

        [BindProperty]
        public PictureFile FileUpload { get; set; }

        public string DisplayPicture { get; set; }
        public class PictureFile
        {
            [Required]
            [Display(Name = "File")]
            public IFormFile FormFile { get; set; }
        }
        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            DisplayPicture = await _profilePictureRepository.DisplayPictureFromDatabase(user.Id);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var memoryStream = new MemoryStream();
            
                await FileUpload.FormFile.CopyToAsync(memoryStream);
                var user = await _userManager.GetUserAsync(User);
                await _profilePictureRepository.UploadPicture(memoryStream, user.Id);
                RedirectToPage("./Index");
            
            DisplayPicture = await _profilePictureRepository.DisplayPictureFromDatabase(user.Id);
            return Page();
        }


        


    }

}

