using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public interface ITest
    {
        Task<string> HelloAsync();
    }
}
