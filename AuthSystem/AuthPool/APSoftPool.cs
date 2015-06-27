using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthModel;

namespace AuthSystem.AuthPool
{
    public class APSoftPool:APBase
    {
        public APSoftPool() { }

        /// <summary>
        /// 设置或获取当前的用户对象
        /// </summary>
        public static AMUser poolSoftAMUser = null;

        /// <summary>
        /// 设置或获取当前的角色对象
        /// </summary>
        public static AMGroup poolSoftAMGroup = null;

        /// <summary>
        /// 设置或获取数据库的连接配置对象
        /// </summary>
        public static AMSqlConf poolSoftSqlConf = null;
    }
}
