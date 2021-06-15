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
       
        
        
        public async Task<string> Filter(string input)
        {
            HttpClient client = new HttpClient();
            var apiCall = "https://www.purgomalum.com/service/plain?text=" + input;
            var apiResponse = await client.GetStringAsync(apiCall);
            client.Dispose();
            return apiResponse;
        }
    }
}
