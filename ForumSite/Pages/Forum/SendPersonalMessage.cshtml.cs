using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum
{
    public class SendPersonalMessageModel : PageModel
    {
        private readonly IPersonalMessageRepository _personalMessageRepository;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public string Input { get; set; }
      
        
        public string ToUser { get; set; }
        public SendPersonalMessageModel(IPersonalMessageRepository personalMessageRepository, UserManager<User> userManager)
        {
            _personalMessageRepository = personalMessageRepository;
            _userManager = userManager;
        }

        public void OnGet(string id, string username)
        {
            ToUser = username;

          
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
           

            if (ModelState.IsValid)
            {
                var message = Input;
                var from =  _userManager.GetUserAsync(User).Result.Id;
                var to = id;
                await _personalMessageRepository.SendMessage(from, to, message);
            }
            


            return RedirectToPage("./Index");
        }

    }
}