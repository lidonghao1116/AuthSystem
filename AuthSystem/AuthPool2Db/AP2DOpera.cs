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
        static AP2DOpera()
        {

        }

        #region 公共变量------------------------------------------------------------------------------------------------------------

        #endregion

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
            GetPoolAMRu2It();
            GetPoolAMItems();
            GetPoolAMItemsNo();
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
                case APPoolType.AMGr2Ru:
                    GetPoolAMGr2Ru();
                    break;
                case APPoolType.AMRules:
                    GetPoolAMRules();
                    break;
                case APPoolType.AMRu2It:
                    GetPoolAMRu2It();
                    break;
                case APPoolType.AMItems:
                    GetPoolAMItems();
                    break;
                case APPoolType.AMItemsNo:
                    GetPoolAMItemsNo();
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
            UpPoolAMUsers();
            UpPoolAMGroups();
            UpPoolGr2Ca();
            UpPoolGr2Ru();
            UpPoolAMRules();
            UpPoolRu2It();
            UpPoolAMItems();
            UpPoolAMItemsNo();
        }
        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交指定数据池数据到数据库
        /// </summary>
        /// <param name="apType"></param>
        public static void UpdatePool(APPoolType apType)
        {
            try
            {
                switch (apType)
                {
                    case APPoolType.AMUsers:
                        UpPoolAMUsers();
                        break;
                    case APPoolType.AMGroups:
                        UpPoolAMGroups();
                        break;
                    case APPoolType.AMGr2Ca:
                        UpPoolGr2Ca();
                        break;
                    case APPoolType.AMGr2Ru:
                        UpPoolGr2Ru();
                        break;
                    case APPoolType.AMRules:
                        UpPoolAMRules();
                        break;
                    case APPoolType.AMRu2It:
                        UpPoolRu2It();
                        break;
                    case APPoolType.AMItems:
                        UpPoolAMItems();
                        break;
                    case APPoolType.AMItemsNo:
                        UpPoolAMItemsNo();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion

        #region 提交dbPool的数据到数据库---------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交所有用户数据
        /// </summary>
        private static void UpPoolAMUsers()
        {
            try
            {
                string sql = @"select * from AuthUsers";
                SqlDataAdapter tmpSDA = GetDataAdapter(sql);
                SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                tmpSDA.Update(APDbPool.poolAll.Tables["poolAMUsers"]);
                APDbPool.poolAll.Tables["poolAMUsers"].AcceptChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交所有角色数据
        /// </summary>
        private static void UpPoolAMGroups()
        {
            try
            {
                string sql = @"select * from AuthGroups";
                SqlDataAdapter tmpSDA = GetDataAdapter(sql);
                SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                tmpSDA.Update(APDbPool.poolAll.Tables["poolAMGroups"]);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交所有角色到仓库数据
        /// </summary>
        private static void UpPoolGr2Ca()
        {
            try
            {
                string sql = @"select * from AuthGr2Ca";
                SqlDataAdapter tmpSDA = GetDataAdapter(sql);
                SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                tmpSDA.Update(APDbPool.poolAll.Tables["poolGr2Ca"]);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交所有角色到规则数据
        /// </summary>
        private static void UpPoolGr2Ru()
        {
            try
            {
                string sql = @"select * from AuthGr2Ru";
                SqlDataAdapter tmpSDA = GetDataAdapter(sql);
                SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                tmpSDA.Update(APDbPool.poolAll.Tables["poolGr2Ru"]);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交所有角色到菜单数据
        /// </summary>
        private static void UpPoolGr2Me()
        {
            try
            {
                string sql = @"select * from AuthGr2Me";
                SqlDataAdapter tmpSDA = GetDataAdapter(sql);
                SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                tmpSDA.Update(APDbPool.poolAll.Tables["poolGr2Me"]);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交所有规则数据
        /// </summary>
        private static void UpPoolAMRules()
        {
            try
            {
                string sql = @"select * from AuthRules";
                SqlDataAdapter tmpSDA = GetDataAdapter(sql);
                SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                tmpSDA.Update(APDbPool.poolAll.Tables["poolAMRules"]);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交所有规则到对象数据
        /// </summary>
        private static void UpPoolRu2It()
        {
            try
            {
                string sql = @"select * from AuthRu2It";
                SqlDataAdapter tmpSDA = GetDataAdapter(sql);
                SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                tmpSDA.Update(APDbPool.poolAll.Tables["poolRu2It"]);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交所有对象数据
        /// </summary>
        private static void UpPoolAMItems()
        {
            try
            {
                string sql = @"select * from AuthItems";
                SqlDataAdapter tmpSDA = GetDataAdapter(sql);
                SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                tmpSDA.Update(APDbPool.poolAll.Tables["poolAMItems"]);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 提交所有不做权限处理的对象数据
        /// </summary>
        private static void UpPoolAMItemsNo()
        {
            try
            {
                string sql = @"select * from AuthItemsNo";
                SqlDataAdapter tmpSDA = GetDataAdapter(sql);
                SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                tmpSDA.Update(APDbPool.poolAll.Tables["poolAMItemsNo"]);
            }
            catch (Exception)
            {
                throw;
            }
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
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APDbPool.poolAll.Tables["poolAMUsers"].Clear();
                    tmpSDA.Fill(APDbPool.poolAll.Tables["poolAMUsers"]);
                }
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
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APDbPool.poolAll.Tables["poolAMGroups"].Clear();
                    tmpSDA.Fill(APDbPool.poolAll.Tables["poolAMGroups"]);
                }
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
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APDbPool.poolAll.Tables["poolGr2Ca"].Clear();
                    tmpSDA.Fill(APDbPool.poolAll.Tables["poolGr2Ca"]);
                }
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
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APDbPool.poolAll.Tables["poolGr2Ru"].Clear();
                    tmpSDA.Fill(APDbPool.poolAll.Tables["poolGr2Ru"]);
                }
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
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APDbPool.poolAll.Tables["poolGr2Me"].Clear();
                    tmpSDA.Fill(APDbPool.poolAll.Tables["poolGr2Me"]);
                }
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
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APDbPool.poolAll.Tables["poolAMRules"].Clear();
                    tmpSDA.Fill(APDbPool.poolAll.Tables["poolAMRules"]);
                }

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
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APDbPool.poolAll.Tables["poolAMItems"].Clear();
                    tmpSDA.Fill(APDbPool.poolAll.Tables["poolAMItems"]);
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取所有规则对应对象数据到dbPool
        /// </summary>
        private static void GetPoolAMRu2It()
        {
            try
            {
                string sql = @"select * from AuthRu2It";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APDbPool.poolAll.Tables["poolRu2It"].Clear();
                    tmpSDA.Fill(APDbPool.poolAll.Tables["poolRu2It"]);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取所有不做权限管理的对象
        /// </summary>
        private static void GetPoolAMItemsNo()
        {
            try
            {
                string sql = @"select * from AuthItemsNo";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APDbPool.poolAll.Tables["poolAMItemsNo"].Clear();
                    tmpSDA.Fill(APDbPool.poolAll.Tables["poolAMItemsNo"]);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion
    }
}
