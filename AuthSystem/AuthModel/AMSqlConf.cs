using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    /// <summary>
    /// 配置文件Model类 
    /// </summary>
    [Serializable]
    public class AMSqlConf:AMBase
    {
        
        public AMSqlConf()
        {
            //TODO：构造函数
        }

        private string _ConnString = "";//---------------------------------
        /// <summary>
        /// 连接数据库的连接字符串
        /// </summary>
        public string ConnString
        {
            get
            {
                return _ConnString;
            }
            set 
            {
                _ConnString = value;
            }
        }

        //--------------------------------------------------------------------------------------
    }
}
