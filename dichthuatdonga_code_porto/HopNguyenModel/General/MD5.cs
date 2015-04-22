using System;
using System.Text;

namespace HopNguyenModel.General
{
    public static class MD5
    {
        public static String Encrypt(String strSource)
        {
            try
            {
                var x = new System.Security.Cryptography.MD5CryptoServiceProvider();

                var bs = Encoding.UTF8.GetBytes(strSource);
                bs = x.ComputeHash(bs);
                var s = new StringBuilder();
                foreach (var b in bs)
                {
                    s.Append(b.ToString("x2").ToLower());
                }
                return s.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static String RadomPassword()
        {
            try
            {
                var r = new Random();
                return r.Next(100000, 999999).ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
