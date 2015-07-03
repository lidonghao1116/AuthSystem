using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 操作配置文件类
    /// </summary>
    public class ADConfig:ADBase
    {
        public ADConfig()
        {
            //TODO：构造函数
        }
        /// <summary>
        /// 从本地加载配置文件
        /// </summary>
        /// <param name="amsc">配置文件对象</param>
        /// <returns>True 或者 False</returns>
        public static AMSqlConf LoadSqlConf()
        {
            AMSqlConf amsc = new AMSqlConf();
            try
            {
                AuthDao.ADSecret ads=new ADSecret();
                string FileName = Environment.CurrentDirectory + "\\SysConf.dat";
                Stream fStr = new FileStream(FileName, FileMode.Open);
                fStr.Position = 0;
                BinaryFormatter bf = new BinaryFormatter();
                amsc = (AMSqlConf)bf.Deserialize(fStr);
                fStr.Close();
                amsc.ConnString = ads.DesDecrypt(amsc.ConnString, "JinDi123");
                return amsc;
            }
            catch (Exception e)
            {
                amsc = new AMSqlConf();
                return amsc;
                throw e;
            }
        }
        /// <summary>
        /// 把配置文件写入磁盘
        /// </summary>
        /// <param name="amsc">配置文件对象</param>
        /// <returns>True 或者 False</returns>
        public static bool SetSqlConf(AMSqlConf amsc)
        {
            try
            {
                AuthDao.ADSecret ads = new ADSecret();
                amsc.ConnString = ads.DesEncrypt(amsc.ConnString, "JinDi123");
                System.Windows.Forms.MessageBox.Show(amsc.ConnString);
                string FileName=Environment.CurrentDirectory+"\\SysConf.dat";
                Stream fStr=new FileStream(FileName,FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                fStr.Position = 0;
                bf.Serialize(fStr, amsc);
                fStr.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }
    }
}
