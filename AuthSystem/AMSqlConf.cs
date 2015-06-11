using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    /// <summary>
    /// 配置文件Model类
    /// </summary>
    public class AMSqlConf:AMBase
    {
        public AMSqlConf()
        {
            //TODO：构造函数
        }
        //--------------------------------------------------------------------------------------------
        private string _Name = "";//-----------------------------------
        /// <summary>
        /// 数据库登陆用户名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _PassWord = "";//--------------------------------- 
        /// <summary>
        /// 数据库登陆密码
        /// </summary>
        public string PassWord
        {
            get { return _PassWord;}
            set{_PassWord=value;}
        }
        private string _ServerAddress = "";//------------------------------
        /// <summary>
        /// 服务器名字或者IP地址
        /// </summary>
        public string ServerAddress
        {
            get { return _ServerAddress; }
            set { _ServerAddress = value; }
        }
        private string _DatabaseName = "";//-------------------------------
        /// <summary>
        /// 要连接的数据库的名字
        /// </summary>
        public string DatabaseName
        {
            get { return _DatabaseName; }
            set { _DatabaseName = value; }
        }
        private string _ConnString = "";//---------------------------------
        /// <summary>
        /// 连接数据库的连接字符串
        /// </summary>
        public string ConnString
        {
            get { return _ConnString; }
            set { _ConnString = value; }
        }

        //--------------------------------------------------------------------------------------
    }
}
