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
    /// SQL配置文件保存与加载
    /// </summary>
    public class ADSqlConf:ADBase
    {
        public ADSqlConf()
        {
            //TODO：构造函数
        }
        /// <summary>
        /// 从本地加载配置文件
        /// </summary>
        /// <param name="amsc">配置文件对象</param>
        /// <returns>True 或者 False</returns>
        public static bool LoadSqlConf(out AMSqlConf amsc)
        {
            try
            {
                string FileName = Environment.CurrentDirectory + "\\SysConf.dat";
                Stream fStr = new FileStream(FileName, FileMode.Open);
                fStr.Position = 0;
                BinaryFormatter bf = new BinaryFormatter();
                amsc = (AMSqlConf)bf.Deserialize(fStr);
                fStr.Close();
                return true;
            }
            catch (Exception e)
            {
                amsc = new AMSqlConf();
                return false;
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
