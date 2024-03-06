using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JCommon.Jot
{
    public class DESEncrypt
    {
        #region ========加密========

        private static string desKey = "CY";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text">需加密的内容</param>
        /// <returns>需解密的内容</returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, desKey);
        }

        /// <summary>
        /// 加密数据
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = UTF8Encoding.UTF8.GetBytes(Text);
            des.Key = UTF8Encoding.UTF8.GetBytes(MD5Helper.MD5(sKey).Substring(0, 8));
            des.IV = UTF8Encoding.UTF8.GetBytes(MD5Helper.MD5(sKey).Substring(0, 8));

            StringBuilder ret = new StringBuilder();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                }

                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
            }

            return ret.ToString();
        }

        #endregion ========加密========

        #region ========解密========

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text">需解密内容</param>
        /// <returns>解密后的内容</returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, desKey);
        }

        /// <summary>
        /// 解密数据
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }

            des.Key = UTF8Encoding.UTF8.GetBytes(MD5Helper.MD5(sKey).Substring(0, 8));
            des.IV = UTF8Encoding.UTF8.GetBytes(MD5Helper.MD5(sKey).Substring(0, 8));
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                }

                return UTF8Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        #endregion ========解密========
    }
}
