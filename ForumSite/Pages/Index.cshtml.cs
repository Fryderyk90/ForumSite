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
        private readonly _9ChanContext _context;

        public string fromTest { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ITest iTest, IConfiguration config, _9ChanContext context)
        {
            _logger = logger;
            _iTest = iTest;
            _config = config;
            _context = context;
        }

        public async Task OnGet()
        {
            

            

            

        }
    }
}
