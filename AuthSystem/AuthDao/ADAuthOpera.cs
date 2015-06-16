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
            if(amsc==null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMUsers AllAmus = new AMUsers();
                AMUser tmpAmu = new AMUser();
                List<AMUser> tmpAmus = new List<AMUser>();
                //tmpAmus.ListAMUsers.Clear();
                string sql = @"select * from AuthUsers";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    //先清空
                    tmpAmu.User_ID = "";
                    tmpAmu.User_Name = "";
                    tmpAmu.User_Text = "";
                    tmpAmu.User_Pass = "";
                    tmpAmu.User_Tel = "";
                    tmpAmu.User_QQ = "";
                    tmpAmu.User_Email = "";
                    tmpAmu.User_Status = false;
                    tmpAmu.User_Group = "";
                    tmpAmu.User_CangKu = "";
                    tmpAmu.User_BeiZhu = "";
                    //再赋值
                    tmpAmu.User_ID = tmpSDR["User_ID"].ToString();
                    tmpAmu.User_Name = tmpSDR["User_Name"].ToString();
                    tmpAmu.User_Text = tmpSDR["User_Text"].ToString();
                    tmpAmu.User_Pass = tmpSDR["User_Pass"].ToString();
                    tmpAmu.User_Tel = tmpSDR["User_Tel"].ToString();
                    tmpAmu.User_QQ = tmpSDR["User_QQ"].ToString();
                    tmpAmu.User_Email = tmpSDR["User_Email"].ToString();
                    tmpAmu.User_Status = (bool)tmpSDR["User_Status"];
                    tmpAmu.User_Group = tmpSDR["User_Group"].ToString();
                    tmpAmu.User_CangKu = tmpSDR["User_CangKu"].ToString();
                    tmpAmu.User_BeiZhu = tmpSDR["User_BeiZhu"].ToString();
                    //添加到列表
                    tmpAmus.Add(tmpAmu);
                }
                tmpSDR.Close();
                AllAmus.ListAMUsers = tmpAmus;
                return AllAmus;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 从数据库取单个用户的数据
        /// </summary>
        /// <param name="UserName">要取的用户的登陆名字</param>
        /// <returns>返回一个AMUser对象</returns>
        public static AMUser GetAuthUser(string UserName)
        {
            if (amsc == null) //判断配置对象是否为空
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMUser tmpAmu = new AMUser();
                string sql = @"select * from AuthUsers where User_Name='" + UserName + "'";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    if (tmpSDR["User_Name"].ToString() == UserName)
                    {
                        tmpAmu.User_ID = tmpSDR["User_ID"].ToString();
                        tmpAmu.User_Name = tmpSDR["User_Name"].ToString();
                        tmpAmu.User_Text = tmpSDR["User_Text"].ToString();
                        tmpAmu.User_Pass = tmpSDR["User_Pass"].ToString();
                        tmpAmu.User_Tel = tmpSDR["User_Tel"].ToString();
                        tmpAmu.User_QQ = tmpSDR["User_QQ"].ToString();
                        tmpAmu.User_Email = tmpSDR["User_Email"].ToString();
                        tmpAmu.User_Status = (bool)tmpSDR["User_Status"];
                        tmpAmu.User_Group = tmpSDR["User_Group"].ToString();
                        tmpAmu.User_CangKu = tmpSDR["User_CangKu"].ToString();
                        tmpAmu.User_BeiZhu = tmpSDR["User_BeiZhu"].ToString();
                    }
                }
                tmpSDR.Close();
                return tmpAmu;
                
            }
            catch (Exception e)
            {
                throw e;
            }


        }
        #endregion

        #region 2-------从数据库取用户的角色(组)数据
        /// <summary>
        /// 根据用户数据，取用户的权限
        /// </summary>
        /// <param name="amu">用户数据对象</param>
        /// <returns>返回AMGroup对象</returns>
        public static AMGroup GetAuthGroup(AMUser amu)
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMGroup tmpAmg = new AMGroup();
                string tmpGroupID = amu.User_Group;
                string sql = @"select * from AuthGroups where Group_ID='" + tmpGroupID + "'";
                SqlDataReader SDR = GetDataReader(sql, amsc);
                while (SDR.Read())
                {
                    tmpAmg.Group_ID = SDR["Group_ID"].ToString();
                    tmpAmg.Group_Name = SDR["Group_Name"].ToString();
                    tmpAmg.Group_Status = (bool)SDR["Group_Status"];
                    tmpAmg.Group_BeiZhu = SDR["Group_BeiZhu"].ToString();
                    tmpAmg.Group_Rule_ID.Add(SDR["Group_Rule_ID"].ToString());
                }
                SDR.Close();
                return tmpAmg;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 取所有的角色组
        /// </summary>
        /// <returns>返回AMGroups对象</returns>
        public static AMGroups GetAuthGroups()
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                //取所有分组的Group_ID;---------------------------------------------------------
                List<string> tmpGroupID = new List<string>();
                string sqlGroupID = @"select Group_ID from AuthGroups group by Group_ID";
                SqlDataReader tmpSDR = GetDataReader(sqlGroupID, amsc);
                while (tmpSDR.Read())
                {
                    tmpGroupID.Add(tmpSDR["Group_ID"].ToString());
                }
                tmpSDR.Close();
                //取所有的分组数据;-------------------------------------------------------------
                AMGroups tmpAmgs = new AMGroups();
                AMGroup tmpAmg = new AMGroup();
                string sql = "";
                foreach (string x in tmpGroupID)
                {
                    sql = @"select * from AuthGroups where Group_ID='" + x + "'";
                    tmpSDR = GetDataReader(sql, amsc);
                    while (tmpSDR.Read())
                    {
                        tmpAmg.Group_ID = tmpSDR["Group_ID"].ToString();
                        tmpAmg.Group_Name = tmpSDR["Group_Name"].ToString();
                        tmpAmg.Group_Status = (bool)tmpSDR["Group_Status"];
                        tmpAmg.Group_BeiZhu = tmpSDR["Group_BeiZhu"].ToString();
                        tmpAmg.Group_Rule_ID.Add(tmpSDR["Group_Rule_ID"].ToString());
                    }
                    tmpSDR.Close();
                    tmpAmgs.Add(tmpAmg);
                }
                return tmpAmgs;
            }
            catch (Exception)
            {
                throw;
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
