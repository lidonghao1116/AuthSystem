using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthModel;

namespace AuthSystem.AuthPool
{
    /// <summary>
    /// 存储软件的公共数据
    /// </summary>
    public class APPoolGlobal:APBase
    {
        public APPoolGlobal() { }

        /// <summary>
        /// 设置或获取当前的用户对象
        /// </summary>
        public static AMUser GlobalAMUser = new AMUser();

        /// <summary>
        /// 设置或获取配置对象
        /// </summary>
        public static AMSystemConfig GlobalAMSystemConfig = new AMSystemConfig();
    }
}
