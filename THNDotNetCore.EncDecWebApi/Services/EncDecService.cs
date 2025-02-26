using Effortless.Net.Encryption;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Text;

namespace THNDotNetCore.EncDecWebApi.Services
{
    public class EncDecService
    {
        private readonly byte[] key;
        private readonly byte[] iv;

        public EncDecService(IConfiguration configurtion)
        {
            key = Encoding.ASCII.GetBytes(configurtion["Security:Key"]!);
            iv = Encoding.ASCII.GetBytes(configurtion["Security:IV"]!);
        }   

        public string Encrypt(string plainText)
        {
            return Strings.Encrypt(plainText, key, iv);
        }

        public string Decrypt (string encryptedText)
        {
            return Strings.Decrypt(encryptedText, key, iv);
        }
    }
}
