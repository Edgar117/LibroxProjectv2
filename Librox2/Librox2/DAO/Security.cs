using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librox2.DAO
{
    public class Security
    {
        public string encrypt(string StringToencrip)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(StringToencrip);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        // This function decrypts the string that we send in the input parameter.
        public string desencrypt(string StringToDesencrip)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(StringToDesencrip);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}