using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum
{
    public class SendPersonalMessageModel : PageModel
    {
        private readonly IMessageData _personalMessageRepository;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        [Required]
        public string Input { get; set; }

        public string ToUser { get; set; }
        public string Message { get; set; }

        public SendPersonalMessageModel(IMessageData personalMessageRepository, UserManager<User> userManager)
        {
            _personalMessageRepository = personalMessageRepository;
            _userManager = userManager;
        }

        public void OnGet(string id, string username, string message)
        {
            ToUser = username;
            if(!string.IsNullOrEmpty(message))
            {
                Message = message;
            }
            
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (ModelState.IsValid)
            {
                var message = Input;
                var from = _userManager.GetUserAsync(User).Result.Id;
                var to = id;
                await _personalMessageRepository.SendMessage(from, to, message);
            }
            
            return RedirectToPage("/Index");
        }
    }
}