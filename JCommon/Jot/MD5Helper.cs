using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JCommon.Jot
{
    public class MD5Helper
    {
        public static string MD5(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(pwd);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str;
        }

        /// <summary>
        /// 文件MD5
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static string MD5(FileInfo fi)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var localBytes = File.ReadAllBytes(fi.FullName);
            byte[] retVal = md5.ComputeHash(localBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
