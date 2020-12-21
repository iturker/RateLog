using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurLog.Classes
{
    public static class SecurityMethods
    {
        //private const string Key = "cut-the-night-with-the-light";
        private const string Key = "adef@@kfxcbv@";

        public static string Encrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }

            input += Key;
            var inputBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes);
        }

        public static string Decrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData))
            {
                return "";
            }
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }
    }
}
