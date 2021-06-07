using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages
{
    public class MyPageModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageData _personalMessage;
        public MyPageModel(UserManager<User> userManager, IMessageData personalMessage)
        {
            _userManager = userManager;
            _personalMessage = personalMessage;
        }

        public List<Message> PersonalMessages { get; set; }
        public UserManager<User> UserManager { get; set; }


        public async Task OnGetAsync()
        {
            var user = _userManager.GetUserAsync(User).Result.Id;
            UserManager = _userManager;
            PersonalMessages = await _personalMessage.GetMessagesPersonalMessages(user);
        }
    }
}
