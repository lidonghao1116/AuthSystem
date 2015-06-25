using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem
{
    public class AuthGlobal
    {
        /// <summary>
        /// 设置或获取当前的用户对象
        /// </summary>
        public static AuthModel.AMUser GlobalAmu;

        /// <summary>
        /// 设置或获取当前的数据库配置对象
        /// </summary>
        public static AuthModel.AMSqlConf GlobalAmsc;

        /// <summary>
        /// 设置或获取当前用户的角色对象
        /// </summary>
        public static AuthModel.AMGroup GlobalAmg;
    }
}
