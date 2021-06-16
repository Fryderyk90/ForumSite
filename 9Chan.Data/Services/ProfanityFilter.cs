using _9Chan.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Data.Services
{
    public class ProfanityFilter : IProfanityFilter
    {

        public ProfanityFilter(IOptions<ProfanityFilterOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public ProfanityFilterOptions Options { get; set; }

        public async Task<string> Filter(string input)
        {

            HttpClient client = new HttpClient();
            var apiCall = Options.ProfanityFilter + input;
            var apiResponse = await client.GetStringAsync(apiCall);
            client.Dispose();
            return apiResponse;
        
        }
    }
}
