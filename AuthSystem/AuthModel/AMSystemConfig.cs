using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AuthSystem.AuthModel
{
    /// <summary>
    /// 用于保存到客户端硬盘的数据的模块
    /// </summary>
    [Serializable]
    public class AMSystemConfig:AMBase
    {
        public AMSystemConfig()
        {
            //Init
        }
        /// <summary>
        /// 登陆过的用户名列表
        /// </summary>
        public string LoginUserNames=null;

        /// <summary>
        /// 自动登陆的密码
        /// </summary>
        public string LoginPassword="";

        /// <summary>
        /// 数据库的连接字符串
        /// </summary>
        public string ConnectionString="";

        /// <summary>
        /// 是否自动登陆
        /// </summary>
        public bool LoginSavePass=false;


    }
    public enum ConfigItem
    {
        ConnectionString,
        LoginUserName,
        LoginPassword
    }
}
