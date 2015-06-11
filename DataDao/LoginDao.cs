using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthModel;

namespace DataDao
{
    public class LoginDao:BaseDao
    {
        //默认DAO
        public LoginDao()
        {
            //TODO:初始化
        }
        /// <summary>
        /// 从数据库读取用户数据
        /// </summary>
        /// <param name="Name">要读取的用户的名字</param>
        /// <param name="AML">返回一个AMLogin，保存了登陆信息</param>
        /// <returns>TRUE返回成功，FALSE返回失败</returns>
        public static bool ReadLoginMsg(string Name, out AMLogin AML)
        {
            //构造要保存的AMLogin
            AMLogin aml = new AMLogin();
            aml.nameCanEmail = false;               //是否可以用EMAIL做用户名
            aml.Name = Name;                        //保存用户名
            //连接数据库
            AML = aml;
            return true;
        }
    }
}
