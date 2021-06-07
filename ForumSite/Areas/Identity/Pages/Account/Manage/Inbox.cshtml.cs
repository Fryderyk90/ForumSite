using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumSite.Areas.Identity.Pages.Account.Manage
{
    public class InboxModel : PageModel
    {
        private readonly IMessageData _personalMessageRepository;
        private readonly UserManager<User> _userManager;

        public List<Message> PersonalMessages { get; set; }

        public InboxModel(IMessageData personalMessageRepository, UserManager<User> userManager)
        {
            _personalMessageRepository = personalMessageRepository;
            _userManager = userManager;
        }

        public async Task OnGet()
        {
            var user = _userManager.GetUserAsync(User).Result.Id;
            PersonalMessages = await _personalMessageRepository.GetMessagesPersonalMessages(user);
        }
    }
}