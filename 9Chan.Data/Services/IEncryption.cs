using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Data.Services
{
    public interface IEncryption
    {
        string EncryptText(string text);

        string DecryptText(string text);
    }
}
