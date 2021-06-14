using _9Chan.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _9Chan.Data.Services
{
    public class Encryption : IEncryption
    {
        public Encryption(IOptions<EncryptionOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public EncryptionOptions Options { get; set; }
        public string DecryptText(string text)
        {
            var publicKey = Options.PublicKey;
            var secretKey = Options.SecretKey;
            byte[] privatekeyByte = { };
            privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretKey);
            byte[] publicKeyByte = { };
            publicKeyByte = System.Text.Encoding.UTF8.GetBytes(publicKey);




            MemoryStream ms = null;
            CryptoStream cs = null;

            byte[] inputMessageArray = new byte[text.Replace(" ", "+").Length];
            inputMessageArray = Convert.FromBase64String(text.Replace(" ", "+"));

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateDecryptor(publicKeyByte, privatekeyByte), CryptoStreamMode.Write);
                cs.Write(inputMessageArray, 0, inputMessageArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                text = encoding.GetString(ms.ToArray());
            }



            return text;
        }

        public string EncryptText(string text)
        {
            var publicKey = Options.PublicKey;
            var secretKey = Options.SecretKey;
            byte[] secretKeyByte = { };
            byte[] publicKeyByte = { };

            secretKeyByte = System.Text.Encoding.UTF8.GetBytes(secretKey);
            publicKeyByte = System.Text.Encoding.UTF8.GetBytes(publicKey);
            MemoryStream ms = null;
            CryptoStream cs = null;

            byte[] inputMessageArray = System.Text.Encoding.UTF8.GetBytes(text);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateEncryptor(publicKeyByte, secretKeyByte), CryptoStreamMode.Write);

                cs.Write(inputMessageArray, 0, inputMessageArray.Length);
                cs.FlushFinalBlock();
                text = Convert.ToBase64String(ms.ToArray());
            }
            return text;
        }


    }
}
