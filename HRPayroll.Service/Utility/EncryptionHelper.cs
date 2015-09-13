using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Service.Utility
{
  public  class EncryptionHelper
    {
        private const string cryptoKey = "cryptoKey";

        // The Initialization Vector for the DES encryption routine
        private static readonly byte[] IV =
            new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        /// <summary>
        /// Encrypts provided string parameter
        /// </summary>
        public static string Encrypt(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            var result = string.Empty;

            try
            {
                var buffer = Encoding.ASCII.GetBytes(s);

                var des =
                    new TripleDESCryptoServiceProvider();

                var MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(Encoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;
                result = Convert.ToBase64String(
                    des.CreateEncryptor().TransformFinalBlock(
                        buffer, 0, buffer.Length));
            }
            catch
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Decrypts provided string parameter
        /// </summary>
        public static string Decrypt(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            string result;

            try
            {
                var buffer = Convert.FromBase64String(s);

                var des =
                    new TripleDESCryptoServiceProvider();

                var md5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    md5.ComputeHash(Encoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;

                result = Encoding.ASCII.GetString(
                    des.CreateDecryptor().TransformFinalBlock(
                    buffer, 0, buffer.Length));
            }
            catch
            {
                throw;
            }

            return result;
        }
    }
}
