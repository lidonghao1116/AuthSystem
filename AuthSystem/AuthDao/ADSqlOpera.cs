using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class ADSqlOpera:ADBase
    {
        public ADSqlOpera()
        {
            //TODO
        }
        /// <summary>
        /// 从数据库读取所有菜单项
        /// </summary>
        /// <param name="amsc">数据库连接配置对象</param>
        /// <returns>返回AMMainMenus.AMMainMenuValue</returns>
        public AuthSystem.AuthModel.AMMainMenus GetAuthMenu(AuthSystem.AuthModel.AMSqlConf amsc)
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

        public AuthSystem.AuthModel.AMGroup GetAuthGroup(AuthSystem.AuthModel.AMSqlConf amsc)
        {
            string CommText = @"select * from AuthGroup";
            SqlDataReader tmpSDR = GetDataReader(CommText, amsc);
            AuthSystem.AuthModel.AMGroup amg = new AuthSystem.AuthModel.AMGroup();
            return amg;
        }
    }
}
