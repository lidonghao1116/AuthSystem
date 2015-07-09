using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AuthSystem.AuthData
{
    /// <summary>
    /// 管理本地配置文件与部分配置缓存磁盘类
    /// </summary>
    public class ADConfig:ADBase
    {
        public ADConfig()
        {
            //Init
        }

        #region 保存配置
        /// <summary>
        /// 保存配置-所有配置
        /// </summary>
        /// <param name="systemConfig">配置对象</param>
        /// <returns>String</returns>
        public string SaveConfig(AMSystemConfig systemConfig)
        {
            try
            {
                if (!systemConfig.LoginSavePass) //如果不是自动登陆，要清除自动登陆的密码
                {
                    systemConfig.LoginPassword = "";
                }

                AuthDao.ADSecret ads = new AuthDao.ADSecret();//创建加密类
                systemConfig.ConnectionString = ads.DesEncrypt(systemConfig.ConnectionString, "JinDi123");//加密连接字符串
                //systemConfig.AutoPassword = ads.MD5Encrypt(systemConfig.AutoPassword);//加密用户密码
                string FileName = Environment.CurrentDirectory + "\\Config.dat"; //配置文件保存路径与文件名
                Stream fStr = new FileStream(FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                fStr.Position = 0;
                bf.Serialize(fStr, systemConfig);
                fStr.Close();
                return "true";
            }
            catch (Exception x)
            {
                return "SaveConfig:" + x.Message;
            }
        }

        /// <summary>
        /// 单项保存配置
        /// </summary>
        /// <param name="Item">要保存的数据的类型</param>
        /// <param name="a">可以转换成字符串的数据</param>
        /// <param name="b">是否保存密码，可以不设</param>
        /// <returns></returns>
        public string SaveConfig(ConfigItem Item, object a, bool b=false)
        {
            try
            {
                //是否有配置文件，没有就新建
                HasConfig();
                AMSystemConfig amsc = new AMSystemConfig();
                ReadConfig(out amsc);

                switch (Item)
                {
                    case ConfigItem.ConnectionString:
                        amsc.ConnectionString = (string)a;
                        break;
                    case ConfigItem.LoginUserName:
                        amsc.LoginUserNames = (string)a;
                        break;
                    case ConfigItem.LoginPassword:
                        if (b)
                        {
                            amsc.LoginSavePass = b;
                            amsc.LoginPassword = (string)a;
                        }
                        else
                        {
                            amsc.LoginPassword = "";
                        }
                        break;
                    default:
                        break;
                }
                AuthDao.ADSecret ads = new AuthDao.ADSecret();//创建加密类
                amsc.ConnectionString = ads.DesEncrypt(amsc.ConnectionString, "JinDi123");//加密连接字符串
                string FileName = Environment.CurrentDirectory + "\\Config.dat"; //配置文件保存路径与文件名
                Stream fStr = new FileStream(FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                fStr.Position = 0;
                bf.Serialize(fStr, amsc);
                fStr.Close();

                return "true";
            }
            catch (Exception x)
            {
                return "SaveConfig:" + x.Message;
            }
        }

        #endregion

        #region 读取配置
        public string ReadConfig(out AMSystemConfig systemConfig)
        {
            try
            {
                AMSystemConfig tmpConfig = new AMSystemConfig();
                AuthDao.ADSecret ads = new AuthDao.ADSecret();
                string FileName = Environment.CurrentDirectory + "\\Config.dat";
                Stream fStr = new FileStream(FileName, FileMode.Open);
                fStr.Position = 0;
                BinaryFormatter bf = new BinaryFormatter();
                tmpConfig = (AMSystemConfig)bf.Deserialize(fStr);
                fStr.Close();
                tmpConfig.ConnectionString = ads.DesDecrypt(tmpConfig.ConnectionString, "JinDi123");
                systemConfig = tmpConfig;
                return "true";
            }
            catch (Exception x)
            {
                systemConfig = new AMSystemConfig();
                return "ReadConfig:" + x.Message;
            }
        }

        public string ReadConfig(ConfigItem Item,out string a,out bool b)
        {
            try
            {
                HasConfig();//没有配置文件就新建

                AMSystemConfig tmpConfig = new AMSystemConfig();
                AuthDao.ADSecret ads = new AuthDao.ADSecret();
                string FileName = Environment.CurrentDirectory + "\\Config.dat";
                Stream fStr = new FileStream(FileName, FileMode.Open);
                fStr.Position = 0;
                BinaryFormatter bf = new BinaryFormatter();
                tmpConfig = (AMSystemConfig)bf.Deserialize(fStr);
                fStr.Close();
                tmpConfig.ConnectionString = ads.DesDecrypt(tmpConfig.ConnectionString, "JinDi123");
                switch (Item)
                {
                    case ConfigItem.ConnectionString:
                        a = tmpConfig.ConnectionString;
                        b = false;
                        break;
                    case ConfigItem.LoginUserName:
                        a = tmpConfig.LoginUserNames;
                        b = false;
                        break;
                    case ConfigItem.LoginPassword:
                        a = tmpConfig.LoginPassword;
                        b = tmpConfig.LoginSavePass;
                        break;
                    default:
                        a = "";
                        b = false;
                        break;
                }
                return "true";
            }
            catch (Exception x)
            {
                a = "";
                b = false;
                return "ReadConfig:" + x.Message;
            }
        }

        #endregion

        #region 其它
        /// <summary>
        /// 是否存在配置文件,没有就新建
        /// </summary>
        /// <returns></returns>
        private void HasConfig()
        {
            string FileName = Environment.CurrentDirectory + "\\Config.dat"; //配置文件保存路径与文件名
            //System.Windows.Forms.MessageBox.Show(System.IO.File.Exists(FileName).ToString());
            if (!System.IO.File.Exists(FileName))
            {
                AuthModel.AMSystemConfig amsc = new AMSystemConfig();
                Stream fStr = new FileStream(FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                fStr.Position = 0;
                bf.Serialize(fStr, amsc);
                fStr.Close();
            }
        }
        #endregion
    }
}
