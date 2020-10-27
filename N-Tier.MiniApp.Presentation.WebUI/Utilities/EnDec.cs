using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace N_Tier.MiniApp.Presentation.WebUI.Utilities
{
    static class EnDec
    {
        public static string Encryption(string val)
        {
            string hash = @"ecivecivOkk3";
            string valTo = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes(val);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    valTo = Convert.ToBase64String(results);
                }
            }
            return valTo;
        }

        public static string Decryption(string val)
        {
            string hash = @"ecivecivOkk3";
            string valTo = "";
            byte[] data = Convert.FromBase64String(val);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    valTo = UTF8Encoding.UTF8.GetString(results);
                }
            }

            return valTo;
        }

    }
}