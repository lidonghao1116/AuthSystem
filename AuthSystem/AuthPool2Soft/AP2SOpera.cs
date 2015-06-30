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

        //-----------------------------------------------------------------------------------------------
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
                    case APPoolType.AMItemsNo:
                        tmpDT = AuthPool.APDbPool.poolAll.Tables["poolAMItemsNo"].Copy();
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

        //-----------------------------------------------------------------------------------------------
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
                    case APPoolType.AMItemsNo:
                        AuthPool.APDbPool.poolAll.Tables["poolAMItemsNo"].Clear();
                        AuthPool.APDbPool.poolAll.Tables["poolAMItemsNo"].Merge(dataTable, true);
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

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 从Ru2It数据池读取Item_ID
        /// </summary>
        /// <param name="Rule_Item_ID">参数：Rule_Item_ID</param>
        /// <returns>List.String</returns>
        public static List<string> ReadPool_Ru2It(string Rule_Item_ID)
        {
            try
            {

                List<string> tmpStr = new List<string>();
                var requit = from s1 in AuthPool.APDbPool.poolAll.Tables["poolRu2It"].AsEnumerable()
                             where s1.Field<string>("Rule_Item_ID") == Rule_Item_ID
                             select s1;
                foreach (var x in requit)
                {
                    tmpStr.Add(x[2].ToString());
                }
                return tmpStr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 对poolRu2It添加一行
        /// </summary>
        /// <param name="Rule_Item_ID">Rule_Item_ID</param>
        /// <param name="Item_ID">Item_ID</param>
        public static void AddRowPool_Ru2It(string Rule_Item_ID, string Item_ID)
        {
            DataRow tmpDR = APDbPool.poolAll.Tables["poolRu2It"].NewRow();
            tmpDR[0] = 0;
            tmpDR[1] = Rule_Item_ID;
            tmpDR[2] = Item_ID;
            //检测是否有重复数据，有就不改动
            bool isAdd = true;
            foreach (DataRow x in APDbPool.poolAll.Tables["poolRu2It"].Rows)
            {
                if (x[1] == tmpDR[1] && x[2] == tmpDR[2])
                {
                    isAdd = false;
                }
            }
            //如果不重复，则添加行
            if (isAdd)
            {
                APDbPool.poolAll.Tables["poolRu2It"].Rows.Add(tmpDR);
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 对poolRu2It删除一行
        /// </summary>
        /// <param name="Rule_Item_ID">Rule_Item_ID</param>
        /// <param name="Item_ID">Item_ID</param>
        public static void DelRowPool_Ru2It(string Rule_Item_ID, string Item_ID)
        {
            foreach (DataRow x in APDbPool.poolAll.Tables["poolRu2It"].Rows)
            {
                if (x[1].ToString() == Rule_Item_ID && x[2].ToString() == Item_ID)
                {
                    x.Delete();
                }
            }
            //APDbPool.poolAll.Tables["poolRu2It"].AcceptChanges();
        }
        /// <summary>
        /// 对poolRu2It删除Rule_Item_ID对应行
        /// </summary>
        /// <param name="Rule_Item_ID">Rule_Item_ID</param>
        public static void DelRowPool_Ru2It(string Rule_Item_ID)
        {
            foreach (DataRow x in APDbPool.poolAll.Tables["poolRu2It"].Rows)
            {
                if (x[1].ToString() == Rule_Item_ID)
                {
                    //APDbPool.poolAll.Tables["poolRu2It"].Rows.Remove(x);
                    x.Delete();
                }
            }
            //APDbPool.poolAll.Tables["poolRu2It"].AcceptChanges();
        }

    }
}
