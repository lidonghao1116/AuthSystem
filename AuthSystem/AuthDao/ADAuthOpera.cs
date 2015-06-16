using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AuthSystem.AuthModel;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 权限数据的数据库操作类
    /// </summary>
    public class ADAuthOpera:ADSqlOpera
    {
        public ADAuthOpera()
        {
            //Init
        }
        private static AMSqlConf amsc=null;
        public static AMSqlConf AMSqlConfig
        {
            get { return amsc; }
            set { amsc = value; }
        }

        #region 1-------从数据库取所有用户数据
        public static AMUsers GetAuthUsers()
        {
            AMUsers amus = new AMUsers();
            return amus;
        }
        public static AMUser GetAuthUser(string UserName)
        {
            if (amsc == null) //判断配置对象是否为空
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            AMUser tmpAmu = new AMUser();
            string sql=@"select * from AuthUsers";
            SqlDataReader tmpSDR = GetDataReader(sql, amsc);
            while (tmpSDR.Read())
            {
                if (tmpSDR["User_Name"].ToString() == UserName)
                {
                    tmpAmu.User_ID = tmpSDR["User_ID"].ToString();
                    tmpAmu.User_Name = tmpSDR["User_Name"].ToString();
                    tmpAmu.User_Text = tmpSDR["User_Text"].ToString();
                    tmpAmu.User_Pass = tmpSDR["User_Pass"].ToString();
                    
                }
            }


        }
        #endregion
        #region 1-------从数据库取菜单数据
        //--------------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库读取所有菜单项
        /// </summary>
        /// <param name="amsc">数据库连接配置对象</param>
        /// <returns>返回AMMainMenus.AMMainMenuValue</returns>
        public static AuthSystem.AuthModel.AMMainMenus GetAuthMenu(AuthSystem.AuthModel.AMSqlConf amsc)
        {
            AuthSystem.AuthModel.AMMainMenus amms = new AuthSystem.AuthModel.AMMainMenus();
            AuthSystem.AuthModel.AMMainMenu amm = new AuthSystem.AuthModel.AMMainMenu();
            string CommText = @"select * from AuthMenu";
            SqlDataReader tmpSDR = GetDataReader(CommText, amsc);
            amms.AMMainMenuValue.Clear();
            while (tmpSDR.Read())
            {
                amm = null;
                amm.MenuID = tmpSDR["ID"].ToString();
                amm.MenuName = tmpSDR["MenuName"].ToString();
                amm.MenuText = tmpSDR["MenuText"].ToString();
                amm.MenuType = tmpSDR["MenuType"].ToString();
                amm.MenuUpID = tmpSDR["MenuUpID"].ToString();
                amms.AMMainMenuValue.Add(amm);
            }
            return amms;
        }
        #endregion

        #region 2-------从数据库取权限组数据
        //--------------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库读取权限组数据
        /// </summary>
        /// <param name="amsc"></param>
        /// <returns></returns>
        public static AuthSystem.AuthModel.AMGroup GetAuthGroup(AuthSystem.AuthModel.AMSqlConf amsc)
        {
            string CommText = @"select * from AuthGroup";
            SqlDataReader tmpSDR = GetDataReader(CommText, amsc);
            AuthSystem.AuthModel.AMGroup amg = new AuthSystem.AuthModel.AMGroup();
            return amg;
        }
        #endregion


    }
}
