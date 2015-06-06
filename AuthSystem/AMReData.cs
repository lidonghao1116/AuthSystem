using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    /// <summary>
    /// 表示从数据库取回来的user信息AuthModel类
    /// </summary>
    public class AMReUserData:AMBase
    {
        public AMReUserData()
        {
            //构造类
        }
        private string _Name = ""; //用户名
        private string _PassWord = "";//密码

    }

    public class AMReRuleData : AMBase
    {

    }
}
