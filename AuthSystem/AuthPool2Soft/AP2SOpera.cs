using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthPool;
using System.Data;
using System.Windows.Forms;

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
                    case APPoolType.AMGroupsRules:
                        tmpDT = AuthPool.APDbPool.poolAll.Tables["poolGroupsRules"].Copy();
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
                        AuthPool.APDbPool.poolAll.Tables["poolAMUsers"].Merge(dataTable, true);
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

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 添加用户的角色
        /// </summary>
        /// <param name="groupID">角色ID</param>
        /// <param name="userID">用户ID</param>
        public static void AddGroup_AMUsers(string groupID, string userID)
        {
            List<string> tmpGroup = new List<string>();
            foreach (DataRow x in APDbPool.poolAll.Tables["poolAMUsers"].Rows)
            {
                if (x["User_ID"].ToString().Equals(userID)) //当匹配到用户ID的时候处理
                {
                    tmpGroup = x["User_Group"].ToString().Split(',').ToList<string>();
                    if (!tmpGroup.Contains(groupID))
                    {
                        tmpGroup.Add(groupID);
                    }
                    StringBuilder sb = new StringBuilder();
                    foreach (string i in tmpGroup)
                    {
                        if (i != "")
                        {
                            sb.Append(i).Append(",");
                        }
                    }
                    if (sb.Length > 1) { sb.Remove(sb.Length - 1, 1); }
                    x["User_Group"] = sb.ToString();
                }
            }
        }
        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 删除用户的角色
        /// </summary>
        /// <param name="groupID">角色ID</param>
        /// <param name="userID">用户ID</param>
        public static void DelGroup_AMUsers(string groupID, string userID)
        {
            List<string> tmpGroup = new List<string>();
            foreach (DataRow x in APDbPool.poolAll.Tables["poolAMUsers"].Rows)
            {
                if (x["User_ID"].ToString().Equals(userID))
                {
                    tmpGroup = x["User_Group"].ToString().Split(',').ToList<string>();
                    if (tmpGroup.Contains(groupID))
                    {
                        tmpGroup.Remove(groupID);
                    }
                    StringBuilder sb = new StringBuilder();
                    foreach (string i in tmpGroup)
                    {
                        if (i != "")
                        {
                            sb.Append(i).Append(",");
                        }
                    }
                    if (sb.Length > 1) { sb.Remove(sb.Length - 1, 1); }
                    x["User_Group"] = sb.ToString();
                }
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// 把规则的DataTable转换成TreeView
        /// </summary>
        /// <param name="dtAMRules">规则DataTable</param>
        /// <returns>TreeNode[]</returns>
        public static TreeNode[] Rules2Tree()
        {
            DataTable dtAMRules = ReadPool(APPoolType.AMRules);
            List<TreeNode> tmpTree = new List<TreeNode>();
            //添加一级菜单
            var miniUpID = (from tmp in dtAMRules.AsEnumerable() select tmp.Field<string>("Rule_Up_RuleID")).Min();
            if (miniUpID == "0")//当存在最小上级ID为0时，才进行处理
            {
                //添加1级菜单
                var oneNodes = from tmp in dtAMRules.AsEnumerable() where tmp.Field<string>("Rule_Up_RuleID") == miniUpID select tmp; //显示1级菜单
                foreach (DataRow x in oneNodes)
                {
                    TreeNode d1CreateNode =(TreeNode)Activator.CreateInstance(typeof(TreeNode),true);
                    d1CreateNode.Text = x["Rule_Name"].ToString();
                    d1CreateNode.Name = x["Rule_Name"].ToString();
                    tmpTree.Add(d1CreateNode);
                    //添加2级菜单
                    var twoNodes = from tmp in dtAMRules.AsEnumerable() where tmp.Field<string>("Rule_Up_RuleID") == x["Rule_ID"].ToString() select tmp;//显示当前1级菜单的2级菜单
                    foreach (DataRow y in twoNodes)
                    {
                        TreeNode d2CreateNode = (TreeNode)Activator.CreateInstance(typeof(TreeNode), true);
                        d2CreateNode.Text = y["Rule_Name"].ToString();
                        d2CreateNode.Name = y["Rule_name"].ToString();
                        d1CreateNode.Nodes.Add(d2CreateNode);
                        //添加3级菜单
                        var threeNodes = from tmp in dtAMRules.AsEnumerable() where tmp.Field<string>("Rule_Up_RuleID") == y["Rule_ID"].ToString() select tmp;//显示当前2级菜单的3级菜单
                        foreach (DataRow z in threeNodes)
                        {
                            TreeNode d3CreateNode = (TreeNode)Activator.CreateInstance(typeof(TreeNode), true);
                            d3CreateNode.Text = z["Rule_Name"].ToString();
                            d3CreateNode.Name = z["Rule_Name"].ToString();
                            d2CreateNode.Nodes.Add(d3CreateNode);
                            //添加4级菜单
                            var fourNodes = from tmp in dtAMRules.AsEnumerable() where tmp.Field<string>("Rule_Up_RuleID") == z["Rule_ID"].ToString() select tmp;//显示当前3级菜单的4级菜单
                            foreach (DataRow z4 in fourNodes)
                            {
                                TreeNode d4CreateNode = (TreeNode)Activator.CreateInstance(typeof(TreeNode), true);
                                d4CreateNode.Text = z4["Rule_Name"].ToString();
                                d4CreateNode.Name = z4["Rule_Name"].ToString();
                                d3CreateNode.Nodes.Add(d4CreateNode);
                                //添加5级菜单（暂未添加）
                            }
                        }
                    }
                }
            }
            else
            {
                throw new Exception("请检查规则列表，不存在一级菜单（即上级菜单为0）");
            }

            return tmpTree.ToArray();
        }

        //-----------------------------------------------------------------------------------------------
        public static bool SetTreeViewCheckBox(TreeView TV, string Group_ID)
        {
            //取Group_ID的所有权限
            AuthPool2Db.AP2DOpera.GetPool(APPoolType.AMGroupsRules);
            DataTable tmpDT = ReadPool(APPoolType.AMGroupsRules);
            var request = from tmp in tmpDT.AsEnumerable() where tmp.Field<string>("Group_ID") == Group_ID select tmp;
            
            return true;
        }
    }
}
