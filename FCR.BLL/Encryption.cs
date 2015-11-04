using System;
using System.Security.Cryptography;

namespace FCR.BLL
{
    
    static class Encryption
    {
        static string passphrase = "YBVtcIPLbn5rlSwRujaEftvmFCFtUFinhOL86PytgDPiTVikFZ2rCJWNuLjoiEu5pkTlI9TiXtkEnfg5ULYJtB1W0MP7rLB8LrNTr8UdVHAW5A7RqOgg9niIG3i8Ca5ppdxDGYlCGqFwwjdlrM8wtlvaRcxT6fg4AUxcSca272952eBLkF5XMN11RRo2DqG8EH3clOiE";

        static string EncryptData(string message)
        {
            byte[] results;
            var utf8 = new System.Text.UTF8Encoding();
            var hashProvider = new MD5CryptoServiceProvider();
            var tdesKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));

            var tdesAlgorithm = new TripleDESCryptoServiceProvider
            {
                Key = tdesKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };


            var dataToEncrypt = utf8.GetBytes(message);

            try
            {
                var encryptor = tdesAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }

            return Convert.ToBase64String(results);
        }

        private static string DecryptString(string message)
        {
            byte[] results;

            var utf8 = new System.Text.UTF8Encoding();
            var hashProvider = new MD5CryptoServiceProvider();
            var tdesKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));

            var tdesAlgorithm = new TripleDESCryptoServiceProvider
            {
                Key = tdesKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var dataToDecrypt = Convert.FromBase64String(message);

            try
            {
                var decryptor = tdesAlgorithm.CreateDecryptor();
                results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }

            return utf8.GetString(results);
        }

    }
}
