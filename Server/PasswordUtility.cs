using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Server
{
    /// <summary>
    /// For password hashing
    /// </summary>
    public class PasswordUtility
    {
        /// <summary>
        /// Encrypt string
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Encrypted string</returns>
        public static string Encrypt(string password)
        {
            var provider = MD5.Create();
            string salt = "S0m3R@nd0mSalt";
            byte[] bytes = provider.ComputeHash(Encoding.UTF32.GetBytes(salt + password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
