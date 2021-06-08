using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum
{
    public class SendGroupMessageModel : PageModel
    {

        private readonly IUserGroupManager _userGroupManager;
        private readonly IMessageData _messageData;
        [BindProperty]
        public string GroupMessage { get; set; }
        public string GroupName { get; set; }

        public SendGroupMessageModel(IUserGroupManager userGroupManager, IMessageData messageData)
        {
            _userGroupManager = userGroupManager;
            _messageData = messageData;
        }

        public void OnGet(string groupName)
        {
            GroupName = groupName;
        }

        public async Task OnPostAsync(int groupId,string userId)
        {

           
          
           
            await _messageData.SendGroupMessage
                (
                userId,
                groupId,
                GroupMessage
                );
            RedirectToPage("./MyPage");

        }
    }
}
