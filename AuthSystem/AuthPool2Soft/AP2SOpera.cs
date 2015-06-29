using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthPool;
using System.Data;
namespace AuthSystem.AuthPool2Soft
{
    /// <summary>
    /// 软件与数据库缓存池的通讯控制类
    /// </summary>
    public class AP2SOpera:AP2SBase
    {
        static AP2SOpera()
        {
            
        }

        /// <summary>
        /// 从数据池读取数据
        /// </summary>
        /// <param name="poolType">要读取的pool类型</param>
        /// <returns>DataTable</returns>
        public static DataTable ReadPool(APPoolType poolType)
        {
            try
            {
                DataTable tmpDT = new DataTable();
                switch (poolType)
                {
                    case APPoolType.AMUsers:
                        tmpDT = AuthPool.APDbPool.poolAll.Tables["poolAMUsers"].Copy();
                        break;
                    case APPoolType.AMGroups:
                        tmpDT = AuthPool.APDbPool.poolAll.Tables["poolAMGroups"].Copy();
                        break;
                    case APPoolType.AMGr2Ca:
                        tmpDT = AuthPool.APDbPool.poolAll.Tables["poolGr2Ca"].Copy();
                        break;
                    case APPoolType.AMGr2Ru:
                        tmpDT = AuthPool.APDbPool.poolAll.Tables["poolGr2Ru"].Copy();
                        break;
                    case APPoolType.AMRules:
                        tmpDT = AuthPool.APDbPool.poolAll.Tables["poolAMRules"].Copy();
                        break;
                    case APPoolType.AMRu2It:
                        tmpDT = AuthPool.APDbPool.poolAll.Tables["poolRu2It"].Copy();
                        break;
                    case APPoolType.AMItems:
                        tmpDT = AuthPool.APDbPool.poolAll.Tables["poolAMItems"].Copy();
                        break;
                    default:
                        tmpDT = null;
                        break;
                }
                return tmpDT;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// 保存数据到数据池
        /// </summary>
        /// <param name="dataTable">要保存的数据</param>
        /// <param name="poolType">数据的类型</param>
        /// <returns>Bool</returns>
        public static bool SavePool(DataTable dataTable,APPoolType poolType)
        {
            try
            {
                switch (poolType)
                {
                    case APPoolType.AMUsers:
                        AuthPool.APDbPool.poolAll.Tables["poolAMUsers"].Clear();
                        AuthPool.APDbPool.poolAll.Tables["poolAMUsers"].Merge(dataTable,true);
                        break;
                    case APPoolType.AMGroups:
                        AuthPool.APDbPool.poolAll.Tables["poolAMGroups"].Clear();
                        AuthPool.APDbPool.poolAll.Tables["poolAMGroups"].Merge(dataTable, true);
                        break;
                    case APPoolType.AMGr2Ca:
                        AuthPool.APDbPool.poolAll.Tables["poolGr2Ca"].Clear();
                        AuthPool.APDbPool.poolAll.Tables["poolGr2Ca"].Merge(dataTable, true);
                        break;
                    case APPoolType.AMGr2Ru:
                        AuthPool.APDbPool.poolAll.Tables["poolGr2Ru"].Clear();
                        AuthPool.APDbPool.poolAll.Tables["poolGr2Ru"].Merge(dataTable, true);
                        break;
                    case APPoolType.AMRules:
                        AuthPool.APDbPool.poolAll.Tables["poolAMRules"].Clear();
                        AuthPool.APDbPool.poolAll.Tables["poolAMRules"].Merge(dataTable, true);
                        break;
                    case APPoolType.AMRu2It:
                        AuthPool.APDbPool.poolAll.Tables["poolRu2It"].Clear();
                        AuthPool.APDbPool.poolAll.Tables["poolRu2It"].Merge(dataTable, true);
                        break;
                    case APPoolType.AMItems:
                        AuthPool.APDbPool.poolAll.Tables["poolAMItems"].Clear();
                        AuthPool.APDbPool.poolAll.Tables["poolAMItems"].Merge(dataTable, true);
                        break;
                    default:
                        break;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
