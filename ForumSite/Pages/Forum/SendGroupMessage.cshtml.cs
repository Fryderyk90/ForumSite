using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum
{
    public class SendGroupMessageModel : PageModel
    {

        private readonly IUserGroupManager _userGroupManager;
        private readonly IMessageData _messageData;
        private readonly UserManager<User> _userManager;
        [BindProperty]
        [Required(ErrorMessage = "Field Is Required")]
        public string GroupMessage { get; set; }
        public string GroupName { get; set; }
        public string Message { get; set; }

        public SendGroupMessageModel(IUserGroupManager userGroupManager, IMessageData messageData, UserManager<User> userManager)
        {
            _userGroupManager = userGroupManager;
            _messageData = messageData;
            _userManager = userManager;
        }

        public async Task OnGetAsync(string groupName,string message)
        {
            var user = await _userManager.GetUserAsync(User);
            var group = _userGroupManager.GetGroupByUserId(user.Id);
            if (!string.IsNullOrEmpty(message))
            {
                Message = message;
            }
            GroupName = group.Name;
        }

        public async Task OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var group = _userGroupManager.GetGroupByUserId(user.Id);
          
           
            await _messageData.SendGroupMessage
                (
                user.Id,
                group.ForumGroupId,
                GroupMessage
                );
            RedirectToPage("./MyPage");

        }
    }
}
