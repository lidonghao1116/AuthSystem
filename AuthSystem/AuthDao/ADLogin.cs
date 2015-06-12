using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AuthSystem.AuthModel;
using AuthSystem.AuthMenu;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 操作登陆AuthDao类
    /// </summary>
    public class ADLogin:ADBase
    {
        public ADLogin()
        {
            //TODO
        }
        /// <summary>
        /// 从数据库读取用户数据
        /// </summary>
        /// <param name="Name">要读取的用户的名字</param>
        /// <param name="AML">返回一个AMLogin，保存了登陆信息</param>
        /// <returns>TRUE返回成功，FALSE返回失败</returns>
        public bool GetLoginMsg(string Name, out AMLogin AML)
        {
            //构造要保存的AMLogin
            AMLogin aml = new AMLogin();            //登陆数据对象
            aml.AMLogins = false;                   //指示本对象为无效对象
            aml.nameCanEmail = false;               //是否可以用EMAIL做用户名
            aml.Name = Name;                        //保存用户名
            //连接数据库
            AMSqlConf amsc = ADConfig.LoadSqlConf();       //数据库配置对象


                SqlConnection sqlConn = GetConn(amsc);
                SqlCommand sqlComm = new SqlCommand();
                SqlDataReader sqlDR;
                string CommText = @"Select * from AuthUser where name='" + Name + "'";
                try
                {
                    sqlConn.Open();
                    sqlComm.CommandText = CommText;
                    sqlComm.Connection = sqlConn;
                    sqlDR = sqlComm.ExecuteReader();
                    while (sqlDR.Read())
                    {
                        aml.AMLogins = true; //对象有效
                        aml.PassWord = sqlDR["password"].ToString(); //取密码
                    }
                    AML = aml;
                    return true;
                }
                catch (Exception e)
                {
                    AML = aml;
                    return false;
                    throw e;
                }
                finally
                {
                    if (sqlConn.State == System.Data.ConnectionState.Open)
                    {
                        sqlConn.Close();
                    }
                }

            AML = aml;
            return true;
        }


    }
}
