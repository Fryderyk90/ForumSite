using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.Extensions.Configuration;

namespace ForumSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITest _iTest;
        private readonly IConfiguration _config;

        public string fromTest { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ITest iTest, IConfiguration config)
        {
            _logger = logger;
            _iTest = iTest;
            _config = config;
        }

        public async Task OnGet()
        {
            

            

            

        }
    }
}
