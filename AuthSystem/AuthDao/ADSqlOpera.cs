﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 操作数据库的类
    /// </summary>
    public class ADSqlOpera:ADBase
    {
        public ADSqlOpera()
        {
            //TODO
        }
        #region 1-------权限相关的数据库操作
        public static class AuthUserOpera
        {
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

            #region 3-------从数据库取所有用户数据
            //--------------------------------------------------------------------------------------------------
            /// <summary>
            /// 从数据库取所有用户数据
            /// </summary>
            /// <param name="amsc"></param>
            public static void GetAuthUsers(AuthModel.AMSqlConf amsc)
            {

            }
            #endregion
        }

        #endregion

       

        #region 10-------执行一条SQL语句
        //--------------------------------------------------------------------------------------------------
        /// <summary>
        /// 执行一条SQL语句
        /// </summary>
        /// <param name="CommText">SQL语句</param>
        /// <param name="amsc">数据库连接配置对象</param>
        /// <returns>返回影响的行数</returns>
        public static int ExcSqlCommand(string CommText,AuthModel.AMSqlConf amsc)
        {
            int x = -1;
            try
            {
                SqlConnection tmpConn = GetConn(amsc);
                tmpConn.Open();
                SqlCommand tmpComm = new SqlCommand(CommText, tmpConn);
                x = tmpComm.ExecuteNonQuery();
                tmpConn.Close();
                return x;
            }
            catch (Exception)
            {
                return x;
                throw;
            }
        }
        #endregion

        
    }
}
