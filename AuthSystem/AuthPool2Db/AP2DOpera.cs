using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthPool;
using AuthSystem.AuthModel;
using System.Data.SqlClient;

namespace AuthSystem.AuthPool2Db
{
    /// <summary>
    /// 数据库缓存池与数据库通讯控制类
    /// </summary>
    public class AP2DOpera:AP2DBase
    {
        public AP2DOpera()
        {
            //Init
        }
        #region 公共数据池操作-------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取所有的池
        /// </summary>
        public static void GetPool()
        {
            GetPoolAMUsers();
            GetPoolAMGroups();
            GetPoolAMGr2Ca();
            GetPoolAMGr2Ru();
            GetPoolAMRules();
            GetPoolAMItems();
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取指定的数据池
        /// </summary>
        /// <param name="apType">要更新的数据池的类型</param>
        public static void GetPool(APPoolType apType)
        {
            
            switch (apType)
            {
                case APPoolType.AMUsers:
                    GetPoolAMUsers();
                    break;
                case APPoolType.AMGroups:
                    GetPoolAMGroups();
                    break;
                case APPoolType.AMGr2Ca:
                    GetPoolAMGr2Ca();
                    break;
                case APPoolType.AMGr2RU:
                    GetPoolAMGr2Ru();
                    break;
                case APPoolType.AMRules:
                    GetPoolAMRules();
                    break;
                case APPoolType.AMItems:
                    GetPoolAMItems();
                    break;
                default:
                    break;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交数据池数据到数据库
        /// </summary>
        public static void UpdatePool()
        {

        }
        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交指定数据池数据到数据库
        /// </summary>
        /// <param name="apType"></param>
        public static void UpdatePool(APPoolType apType)
        {
            switch (apType)
            {
                case APPoolType.AMUsers:
                    break;
                case APPoolType.AMGroups:
                    break;
                case APPoolType.AMGr2Ca:
                    break;
                case APPoolType.AMGr2RU:
                    break;
                case APPoolType.AMRules:
                    break;
                case APPoolType.AMItems:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 提交dbPool的数据到数据库---------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        private static void UpPoolAMUsers()
        {

        }
        #endregion

        #region 从数据库取数据到DbPool-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取所有用户数据到dbPool
        /// </summary>
        private static void GetPoolAMUsers()
        {
            try
            {
                string sql = @"select * from AuthUsers";
                SqlDataReader tmpSDR = GetDataReader(sql);
                List<AMUser> tmpAMUsers = new List<AMUser>();
                while (tmpSDR.Read())
                {
                    AMUser tmpAMUser = new AMUser();
                    tmpAMUser.User_ID = tmpSDR["User_ID"].ToString();
                    tmpAMUser.User_Name = tmpSDR["User_Name"].ToString();
                    tmpAMUser.User_Text = tmpSDR["User_Text"].ToString();
                    tmpAMUser.User_Pass = tmpSDR["User_Pass"].ToString();
                    tmpAMUser.User_Tel = tmpSDR["User_Tel"].ToString();
                    tmpAMUser.User_QQ = tmpSDR["User_QQ"].ToString();
                    tmpAMUser.User_Email = tmpSDR["User_Email"].ToString();
                    tmpAMUser.User_Status = (bool)tmpSDR["User_Status"];
                    tmpAMUser.User_Group = tmpSDR["User_Group"].ToString();
                    tmpAMUser.User_CangKu = tmpSDR["User_CangKu"].ToString();
                    tmpAMUser.User_BeiZhu = tmpSDR["User_BeiZhu"].ToString();
                    tmpAMUsers.Add(tmpAMUser);
                }
                tmpSDR.Close();
                APDbPool.poolAMUsers = tmpAMUsers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取所有的角色数据到dbPool
        /// </summary>
        private static void GetPoolAMGroups()
        {
            try
            {
                string sql = @"select * from AuthGroups";
                SqlDataReader tmpSDR = GetDataReader(sql);
                List<AMGroup> tmpAMGroups = new List<AMGroup>();
                while (tmpSDR.Read())
                {
                    AMGroup tmpAMGroup = new AMGroup();
                    tmpAMGroup.Group_ID = tmpSDR["Group_ID"].ToString();
                    tmpAMGroup.Group_Name = tmpSDR["Group_Name"].ToString();
                    tmpAMGroup.Group_Status = (bool)tmpSDR["Group_Status"];
                    tmpAMGroup.Group_BeiZhu = tmpSDR["Group_BeiZhu"].ToString();
                    tmpAMGroup.Group_Rule_ID = tmpSDR["Group_Rule_ID"].ToString();
                    tmpAMGroup.Group_CangKu_ID = tmpSDR["Group_CangKu_ID"].ToString();
                    tmpAMGroup.Group_Menu_ID = tmpSDR["Group_Menu_ID"].ToString();
                    tmpAMGroups.Add(tmpAMGroup);
                }
                tmpSDR.Close();
                APDbPool.poolAMGroups = tmpAMGroups;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取所有角色对应仓库数据到dbPool
        /// </summary>
        private static void GetPoolAMGr2Ca()
        {
            try
            {
                string sql = @"select * from AuthGr2Ca";
                SqlDataReader tmpSDR = GetDataReader(sql);
                List<AMX2Y> tmpAMGr2Cas = new List<AMX2Y>();
                while (tmpSDR.Read())
                {
                    AMX2Y tmpAMGr2Ca = new AMX2Y();
                    tmpAMGr2Ca.ID1 = tmpSDR["Group_CangKu_ID"].ToString();
                    tmpAMGr2Ca.ID2 = tmpSDR["CangKu_ID"].ToString();
                    tmpAMGr2Cas.Add(tmpAMGr2Ca);
                }
                tmpSDR.Close();
                APDbPool.poolGr2Ca = tmpAMGr2Cas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取所有角色对应规则数据到dbPool
        /// </summary>
        private static void GetPoolAMGr2Ru()
        {
            try
            {
                string sql = @"select * from AuthGr2Ru";
                SqlDataReader tmpSDR = GetDataReader(sql);
                List<AMX2Y> tmpAMGr2Rus = new List<AMX2Y>();
                while (tmpSDR.Read())
                {
                    AMX2Y tmpAMGr2Ru = new AMX2Y();
                    tmpAMGr2Ru.ID1 = tmpSDR["Group_Rule_ID"].ToString();
                    tmpAMGr2Ru.ID2 = tmpSDR["Rule_ID"].ToString();
                    tmpAMGr2Rus.Add(tmpAMGr2Ru);
                }
                tmpSDR.Close();
                APDbPool.poolGr2Ru = tmpAMGr2Rus; 
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取角色对应菜单数据的dbPool
        /// </summary>
        private static void GetPoolAMGr2Me()
        {
            try
            {
                string sql = @"select * from AuthGr2Me";
                SqlDataReader tmpSDR = GetDataReader(sql);
                List<AMX2Y> tmpAMGr2Mes = new List<AMX2Y>();
                while (tmpSDR.Read())
                {
                    AMX2Y tmpAMGr2Me = new AMX2Y();
                    tmpAMGr2Me.ID1 = tmpSDR["Group_Menu_ID"].ToString();
                    tmpAMGr2Me.ID2 = tmpSDR["Menu_ID"].ToString();
                    tmpAMGr2Mes.Add(tmpAMGr2Me);
                }
                tmpSDR.Close();
                APDbPool.poolGr2Me = tmpAMGr2Mes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取所有规则数据到dbPool
        /// </summary>
        private static void GetPoolAMRules()
        {
            try
            {
                string sql = @"select * from AuthRules";
                SqlDataReader tmpSDR = GetDataReader(sql);
                List<AMRule> tmpAMRules = new List<AMRule>();
                while (tmpSDR.Read())
                {
                    AMRule tmpAMRule = new AMRule();
                    tmpAMRule.Rule_ID = tmpSDR["Rule_ID"].ToString();
                    tmpAMRule.Rule_Name = tmpSDR["Rule_Name"].ToString();
                    tmpAMRule.Rule_Item_ID = tmpSDR["Rule_Item_ID"].ToString();
                    tmpAMRule.Rule_Up_RuleID = tmpSDR["Rule_Up_RuleID"].ToString();
                    tmpAMRule.Rule_BeiZhu = tmpSDR["Rule_BeiZhu"].ToString();
                    tmpAMRules.Add(tmpAMRule);
                }
                tmpSDR.Close();
                APDbPool.poolAMRules = tmpAMRules;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取所有对象数据到dbPool
        /// </summary>
        private static void GetPoolAMItems()
        {
            try
            {
                string sql = @"select * from AuthItems";
                SqlDataReader tmpSDR = GetDataReader(sql);
                List<AMItem> tmpAMItems = new List<AMItem>();
                while (tmpSDR.Read())
                {
                    AMItem tmpAMItem = new AMItem();
                    tmpAMItem.Item_ID = tmpSDR["Item_ID"].ToString();
                    tmpAMItem.Item_Name = tmpSDR["Item_Name"].ToString();
                    tmpAMItem.Item_NameSpace = tmpSDR["Item_NameSpace"].ToString();
                    tmpAMItem.Item_BeiZhu = tmpSDR["Item_BeiZhu"].ToString();
                    tmpAMItems.Add(tmpAMItem);
                }
                tmpSDR.Close();
                APDbPool.poolAMItems = tmpAMItems;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion
    }
}
