using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 加密解密类
    /// </summary>
    
    public class ADSecret:ADBase
    {
        public ADSecret()
        {
            //Init
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// 使用MD5加密字符串
        /// </summary>
        /// <param name="souStr">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public string MD5Encrypt(string souStr)
        {
            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF7.GetBytes(souStr);
            bytes = crypto.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte x in bytes)
            {
                sb.AppendFormat("{0:x2}", x);
            }
            return sb.ToString();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Des加密
        /// </summary>
        /// <param name="souStr">要加密的字符串</param>
        /// <returns>字符串</returns>
        public string DesEncrypt(string souStr,string Keys)
        {
            if (Keys.Length != 8)
            {
                if (Keys.Length > 8)
                {
                    Keys = Keys.Substring(0, 8);
                }
                else
                {
                    Keys = Keys.PadRight(8);
                }
            }
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            
            byte[] Key = Encoding.ASCII.GetBytes(Keys);
            byte[] IV = Encoding.ASCII.GetBytes(Keys);
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(souStr);
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(bytes, 0, bytes.Length);
                        cs.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
                catch
                {
                    return souStr;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="serStr">要解密的密文</param>
        /// <param name="Keys">Key</param>
        /// <returns>字符串</returns>
        public string DesDecrypt(string serStr, string Keys)
        {
            if (Keys.Length != 8)
            {
                if (Keys.Length > 8)
                {
                    Keys = Keys.Substring(0, 8);
                }
                else
                {
                    Keys = Keys.PadRight(8);
                }
            }
            byte[] key = Encoding.ASCII.GetBytes(Keys);
            byte[] IV = Encoding.ASCII.GetBytes(Keys);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData = Convert.FromBase64String(serStr);
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                catch(Exception x)
                {
                    System.Windows.Forms.MessageBox.Show(x.Message);
                    return serStr;
                }
            }
        }
    }
}
