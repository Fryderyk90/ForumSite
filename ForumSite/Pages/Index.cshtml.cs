using _9Chan.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ForumSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IConfiguration _config;
        private readonly IEncryption _encryption;
        private readonly IProfanityFilter _profanityFilter;

        public string EncryptedMessage { get; set; }
        public string DecryptedMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config, IEncryption encryption, IProfanityFilter profanityFilter)
        {
            _logger = logger;
            _config = config;
            _encryption = encryption;
            _profanityFilter = profanityFilter;
        }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
           
        }

        public void OnPost()
        {
          
        }

        public IActionResult OnPostOther()
        {

            return Page();
        }
    }
}