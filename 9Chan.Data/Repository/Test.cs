using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public class Test : ITest
    {
        public async Task<string> HelloAsync()
        {
            return "Hello!!!!!!!! from Repository PROJ!";
        }
    }
}
