using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using AuthSystem.AuthPool;

namespace AuthSystem.AuthData
{
    /// <summary>
    /// 操作SQL与Pool的类
    /// </summary>
    public class ADAction:ADBase
    {
        public ADAction()
        {
            //Init
        }

        #region 1------从数据库读取数据到数据池
        //==================================================================================================
        /// <summary>
        /// 从数据库读取数据到数据池
        /// </summary>
        public string ReadToPool()
        {
            try
            {
                ReadAuthUsers();
                ReadAuthUs2Gr();
                ReadAuthGroups();
                ReadAuthGr2Ca();
                ReadAuthGr2Ru();
                ReadAuthRules();
                ReadAuthRu2It();
                ReadAuthCangKu();
                ReadAuthItems();
                ReadAuthItemsNo();
                ReadAuthGroupsRules();
                ReadAuthGroupsItems();
                return "true";
            }
            catch (Exception x)
            {
                return "ReadToPool:" + x.Message;
                throw;
            }
        }

        //==================================================================================================
        /// <summary>
        /// 从数据库读取指定类型数据到数据池
        /// </summary>
        /// <param name="poolType">数据类型</param>
        public string ReadToPool(PoolType poolType)
        {
            try
            {
                switch (poolType)
                {
                    case PoolType.Users:
                        ReadAuthUsers();
                        break;
                    case PoolType.Us2Gr:
                        ReadAuthUs2Gr();
                        break;
                    case PoolType.Groups:
                        ReadAuthGroups();
                        break;
                    case PoolType.Gr2Ca:
                        ReadAuthGr2Ca();
                        break;
                    case PoolType.Gr2Ru:
                        ReadAuthGr2Ru();
                        break;
                    case PoolType.Rules:
                        ReadAuthRules();
                        break;
                    case PoolType.Ru2It:
                        ReadAuthRu2It();
                        break;
                    case PoolType.CangKu:
                        ReadAuthCangKu();
                        break;
                    case PoolType.Items:
                        ReadAuthItems();
                        break;
                    case PoolType.ItemsNo:
                        ReadAuthItemsNo();
                        break;
                    case PoolType.GroupsRules:
                        ReadAuthGroupsRules();
                        break;
                    case PoolType.GroupsItems:
                        ReadAuthGroupsItems();
                        break;
                    default:
                        break;
                }
                return "true";
            }
            catch (Exception x)
            {
                return "ReadToPool:" + x.Message;
                throw;
            }
        }

        //==================================================================================================
        /// <summary>
        /// 读取指定用户与命名空间的Items表
        /// (不进入缓存)
        /// </summary>
        /// <param name="NameSpace">命名空间</param>
        /// <param name="UserID">用户ID</param>
        /// <returns>DataTable</returns>
        public DataTable ReadUserItems(string NameSpace, string UserID)
        {
            try
            {
                DataTable tmpDt = new DataTable();
                long UID = Convert.ToInt64(UserID);
                string sql = @"select * from AuthUsersItems where Item_NameSpace='" + NameSpace + "' and User_ID=" + UID;
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    tmpSDA.Fill(tmpDt);
                }
                return tmpDt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //==================================================================================================
        /// <summary>
        /// 读取指定命名空间的ItemsNo表
        /// (不进入缓存)
        /// </summary>
        /// <param name="NameSpace">命名空间</param>
        /// <returns>DataTable</returns>
        public DataTable ReadUserItemsNo(string NameSpace)
        {
            try
            {
                DataTable tmpDt = new DataTable();
                string sql = @"select * from AuthItemsNo where Item_NameSpace='" + NameSpace + "'";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    tmpSDA.Fill(tmpDt);
                }
                return tmpDt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //==================================================================================================
        #region 单个方法
        private void ReadAuthUsers()
        {
            try
            {
                string sql = @"select * from AuthUsers";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["poolAuthUsers"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["poolAuthUsers"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ReadAuthUs2Gr()
        {
            try
            {
                string sql = @"select * from AuthUs2Gr";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["poolAuthUs2Gr"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["poolAuthUs2Gr"]);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void ReadAuthGroups()
        {
            try
            {
                string sql = @"select * from AuthGroups";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["poolAuthGroups"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["poolAuthGroups"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReadAuthGr2Ca()
        {
            try
            {
                string sql = @"select * from AuthGr2Ca";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["poolAuthGr2Ca"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["poolAuthGr2Ca"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReadAuthGr2Ru()
        {
            try
            {
                string sql = @"select * from AuthGr2Ru";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["poolAuthGr2Ru"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["poolAuthGr2Ru"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReadAuthCangKu()
        {
            try
            {
                string sql = @"select * from AuthCangKu";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["poolAuthCangKu"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["poolAuthCangKu"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReadAuthRules()
        {
            try
            {
                string sql = @"select * from AuthRules";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["poolAuthRules"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["poolAuthRules"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReadAuthRu2It()
        {
            try
            {
                string sql = @"select * from AuthRu2It";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["poolAuthRu2It"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["poolAuthRu2It"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReadAuthItems()
        {
            try
            {
                string sql = @"select * from AuthItems";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["poolAuthItems"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["poolAuthItems"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReadAuthItemsNo()
        {
            try
            {
                string sql = @"select * from AuthItemsNo";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["poolAuthItemsNo"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["poolAuthItemsNo"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReadAuthGroupsRules()
        {
            try
            {
                string sql = @"select * from AuthGroupsRules";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["pvGroupsRules"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["pvGroupsRules"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReadAuthGroupsItems()
        {
            try
            {
                string sql = @"select * from AuthGroupsItems";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    APPool.poolAll.Tables["pvGroupsItems"].Clear();
                    tmpSDA.Fill(APPool.poolAll.Tables["pvGroupsItems"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        //==================================================================================================
        #endregion

        #region 2------把数据池的数据同步到数据库
        //==================================================================================================
        /// <summary>
        /// 把数据池的数据上传到数据库
        /// </summary>
        public string UpdatePool()
        {
            try
            {
                UpdateAuthUsers();
                UpdateAuthUs2Gr();
                UpdateAuthGroups();
                UpdateAuthGr2Ca();
                UpdateAuthCangKu();
                UpdateAuthGr2Ru();
                UpdateAuthRules();
                UpdateAuthRu2It();
                UpdateAuthItems();
                UpdateAuthItemsNo();
                UpdateAuthGroupsRules();
                UpdateAuthGroupsItems();
                return "true";
            }
            catch (Exception x)
            {
                return "UpdatePool:" + x.Message;
                throw;
            }
        }
        //==================================================================================================
        /// <summary>
        /// 把指定的数据池的数据上传到数据库
        /// </summary>
        /// <param name="poolType">要上传的数据池类型</param>
        public string UpdatePool(PoolType poolType)
        {
            try
            {
                switch (poolType)
                {
                    case PoolType.Users:
                        UpdateAuthUsers();
                        break;
                    case PoolType.Us2Gr:
                        UpdateAuthUs2Gr();
                        break;
                    case PoolType.Groups:
                        UpdateAuthGroups();
                        break;
                    case PoolType.Gr2Ca:
                        UpdateAuthGr2Ca();
                        break;
                    case PoolType.Gr2Ru:
                        UpdateAuthGr2Ru();
                        break;
                    case PoolType.Rules:
                        UpdateAuthRules();
                        break;
                    case PoolType.Ru2It:
                        UpdateAuthRu2It();
                        break;
                    case PoolType.CangKu:
                        UpdateAuthCangKu();
                        break;
                    case PoolType.Items:
                        UpdateAuthItems();
                        break;
                    case PoolType.ItemsNo:
                        UpdateAuthItemsNo();
                        break;
                    case PoolType.GroupsRules:
                        UpdateAuthGroupsRules();
                        break;
                    case PoolType.GroupsItems:
                        UpdateAuthGroupsItems();
                        break;
                    default:
                        break;
                }

                return "true";
            }
            catch (Exception x)
            {
                return "UpdatePool:" + x.Message;
                throw;
            }
        }

        //==================================================================================================
        #region 单个方法 
        private void UpdateAuthUsers()
        {
            try
            {
                string sql = @"select * from AuthUsers";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["poolAuthUsers"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthUs2Gr()
        {
            try
            {
                string sql = @"select * from AuthUs2Gr";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["poolAuthUs2Gr"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthGroups()
        {
            try
            {
                string sql = @"select * from AuthGroups";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["poolAuthGroups"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthGr2Ca()
        {
            try
            {
                string sql = @"select * from AuthGr2Ca";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["poolAuthGr2Ca"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthCangKu()
        {
            try
            {
                string sql = @"select * from AuthCangKu";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["poolAuthCangKu"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthGr2Ru()
        {
            try
            {
                string sql = @"select * from AuthGr2Ru";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["poolAuthGr2Ru"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthRules()
        {
            try
            {
                string sql = @"select * from AuthRules";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["poolAuthRules"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthRu2It()
        {
            try
            {
                string sql = @"select * from AuthRu2It";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["poolAuthRu2It"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthItems()
        {
            try
            {
                string sql = @"select * from AuthItems";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["poolAuthItems"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthItemsNo()
        {
            try
            {
                string sql = @"select * from AuthItemsNo";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["poolAuthItemsNo"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthGroupsRules()
        {
            try
            {
                string sql = @"select * from AuthGroupsRules";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["pvGroupsRules"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateAuthGroupsItems()
        {
            try
            {
                string sql = @"select * from AuthGroupsItems";
                using (SqlDataAdapter tmpSDA = GetDataAdapter(sql))
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(tmpSDA);
                    tmpSDA.Update(APPool.poolAll.Tables["pvGroupsItems"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        //==================================================================================================
        #endregion

        #region 3------从数据池读取数据到软件
        //==================================================================================================
        /// <summary>
        /// 从Pool读取指定类型数据到DataTable
        /// </summary>
        /// <param name="poolType">数据类型</param>
        /// <returns>DataTable</returns>
        public DataTable ReadPool(PoolType poolType)
        {
            try
            {
                DataTable tmpDt = new DataTable();
                switch (poolType)
                {
                    case PoolType.Users:
                        tmpDt = APPool.poolAll.Tables["poolAuthUsers"].Copy();
                        break;
                    case PoolType.Us2Gr:
                        tmpDt = APPool.poolAll.Tables["poolAuthUs2Gr"].Copy();
                        break;
                    case PoolType.Groups:
                        tmpDt = APPool.poolAll.Tables["poolAuthGroups"].Copy();
                        break;
                    case PoolType.Gr2Ca:
                        tmpDt = APPool.poolAll.Tables["poolAuthGr2Ca"].Copy();
                        break;
                    case PoolType.Gr2Ru:
                        tmpDt = APPool.poolAll.Tables["poolAuthGr2Ru"].Copy();
                        break;
                    case PoolType.Rules:
                        tmpDt = APPool.poolAll.Tables["poolAuthRules"].Copy();
                        break;
                    case PoolType.Ru2It:
                        tmpDt = APPool.poolAll.Tables["poolAuthRu2It"].Copy();
                        break;
                    case PoolType.CangKu:
                        tmpDt = APPool.poolAll.Tables["poolAuthCangKu"].Copy();
                        break;
                    case PoolType.Items:
                        tmpDt = APPool.poolAll.Tables["poolAuthItems"].Copy();
                        break;
                    case PoolType.ItemsNo:
                        tmpDt = APPool.poolAll.Tables["poolAuthItemsNo"].Copy();
                        break;
                    case PoolType.GroupsRules:
                        tmpDt = APPool.poolAll.Tables["pvGroupsRules"].Copy();
                        break;
                    case PoolType.GroupsItems:
                        tmpDt = APPool.poolAll.Tables["pvGroupsItems"].Copy();
                        break;
                    default:
                        break;
                }
                return tmpDt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //==================================================================================================
        /// <summary>
        /// 从数据池读取列数据，指定类型与列序号
        /// </summary>
        /// <param name="poolType">数据类型</param>
        /// <param name="index">列序号</param>
        /// <returns>List.String</returns>
        public List<string> ReadPoolSigItems(PoolType poolType, int index)
        {
            try
            {
                List<string> tmpData = new List<string>();//缓存数据
                DataTable tmpDt=ReadPool(poolType);
                var requ = from tmp in tmpDt.AsEnumerable() select tmp.Field<string>(index);
                foreach (string x in requ)
                {
                    tmpData.Add(x);
                }
                return tmpData;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //==================================================================================================
        /// <summary>
        /// 从数据池读取数据，指定类型与列名称
        /// </summary>
        /// <param name="poolType">数据类型</param>
        /// <param name="ColumnsName">列名称</param>
        /// <returns>List.String</returns>
        public List<string> ReadPoolSigItems(PoolType poolType, string ColumnsName)
        {
            try
            {
                List<string> tmpData = new List<string>();//缓存数据
                DataTable tmpDt = ReadPool(poolType);
                var requ = from tmp in tmpDt.AsEnumerable() select tmp.Field<string>(ColumnsName);
                foreach (string x in requ)
                {
                    tmpData.Add(x);
                }
                return tmpData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //==================================================================================================
        /// <summary>
        /// 从数据池读取数据，指定规则ID,取对应的ItemID列表
        /// </summary>
        /// <param name="RuleID"></param>
        /// <returns></returns>
        public List<string> ReadPoolRu2It(string RuleID)
        {
            try
            {
                List<string> tmpData = new List<string>();
                DataTable tmpDt = ReadPool(PoolType.Ru2It);
                var requ = from tmp in tmpDt.AsEnumerable() where tmp.Field<object>("Rule_ID").ToString() == RuleID select tmp.Field<object>("Item_ID");
                foreach (object x in requ)
                {
                    tmpData.Add(x.ToString());
                }
                return tmpData;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //==================================================================================================
        /// <summary>
        /// 从数据池读取数据，指定用户ID,取对应的角色ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<string> ReadPoolUs2Gr(string UserID)
        {
            try
            {
                List<string> tmpData = new List<string>();
                DataTable tmpDt = ReadPool(PoolType.Us2Gr);
                var requ = from tmp in tmpDt.AsEnumerable() where tmp.Field<object>("User_ID").ToString() == UserID select tmp.Field<object>("Group_ID");
                foreach (object x in requ)
                {
                    tmpData.Add(x.ToString());
                }
                return tmpData;
            }
            catch (Exception)
            {
                
                throw;
            }
        }



        #endregion

        #region 4------把数据保存到数据池
        public void SavePool(PoolType poolType, DataTable dataTable)
        {
            try
            {
                switch (poolType)
                {
                    case PoolType.Users:
                        APPool.poolAll.Tables["poolAuthUsers"].Clear();
                        APPool.poolAll.Tables["poolAuthUsers"].Merge(dataTable, true);
                        break;
                    case PoolType.Us2Gr:
                        APPool.poolAll.Tables["poolAuthUs2Gr"].Clear();
                        APPool.poolAll.Tables["poolAuthUs2Gr"].Merge(dataTable, true);
                        break;
                    case PoolType.Groups:
                        APPool.poolAll.Tables["poolAuthGroups"].Clear();
                        APPool.poolAll.Tables["poolAuthGroups"].Merge(dataTable, true);
                        break;
                    case PoolType.Gr2Ca:
                        APPool.poolAll.Tables["poolAuthGr2Ca"].Clear();
                        APPool.poolAll.Tables["poolAuthGr2Ca"].Merge(dataTable, true);
                        break;
                    case PoolType.Gr2Ru:
                        APPool.poolAll.Tables["poolAuthGr2Ru"].Clear();
                        APPool.poolAll.Tables["poolAuthGr2Ru"].Merge(dataTable, true);
                        break;
                    case PoolType.Rules:
                        APPool.poolAll.Tables["poolAuthRules"].Clear();
                        APPool.poolAll.Tables["poolAuthRules"].Merge(dataTable, true);
                        break;
                    case PoolType.Ru2It:
                        APPool.poolAll.Tables["poolAuthRu2It"].Clear();
                        APPool.poolAll.Tables["poolAuthRu2It"].Merge(dataTable, true);
                        break;
                    case PoolType.CangKu:
                        APPool.poolAll.Tables["poolAuthCangKu"].Clear();
                        APPool.poolAll.Tables["poolAuthCangKu"].Merge(dataTable, true);
                        break;
                    case PoolType.Items:
                        APPool.poolAll.Tables["poolAuthItems"].Clear();
                        APPool.poolAll.Tables["poolAuthItems"].Merge(dataTable, true);
                        break;
                    case PoolType.ItemsNo:
                        APPool.poolAll.Tables["poolAuthItemsNo"].Clear();
                        APPool.poolAll.Tables["poolAuthItemsNo"].Merge(dataTable, true);
                        break;
                    case PoolType.GroupsRules:
                        APPool.poolAll.Tables["pvGroupsRules"].Clear();
                        APPool.poolAll.Tables["pvGroupsRules"].Merge(dataTable, true);
                        break;
                    case PoolType.GroupsItems:
                        APPool.poolAll.Tables["pvGroupsItems"].Clear();
                        APPool.poolAll.Tables["pvGroupsItems"].Merge(dataTable, true);
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

        #region 5------处理规则Tree
        //==================================================================================================
        /// <summary>
        /// 把Rules转换成TreeView的Nodes数组
        /// </summary>
        /// <returns>TreeNode[]</returns>
        public TreeNode[] SetTreeViewData()
        {
            try
            {
                DataTable tmpDT = ReadPool(PoolType.Rules);
                List<TreeNode> tmpTree = new List<TreeNode>();
                //添加一级菜单
                var tmpsss = from tmp in tmpDT.AsEnumerable() select tmp.Field<long>("Rule_UpID");
                long miniUpID = tmpsss.Min();
                //int miniUpID = (from tmp in tmpDT.AsEnumerable() select tmp.Field<int>("Rule_UpID")).Min();
                if (miniUpID == 0)//当存在最小上级ID为0时，才进行处理
                {
                    //添加1级菜单
                    var oneNodes = from tmp in tmpDT.AsEnumerable() where tmp.Field<long>("Rule_UpID") == miniUpID select tmp; //显示1级菜单
                    foreach (DataRow x in oneNodes)
                    {
                        TreeNode d1CreateNode = (TreeNode)Activator.CreateInstance(typeof(TreeNode), true);
                        d1CreateNode.Text = x["Rule_Name"].ToString();
                        d1CreateNode.Name = x["Rule_ID"].ToString();
                        tmpTree.Add(d1CreateNode);
                        //添加2级菜单
                        var twoNodes = from tmp in tmpDT.AsEnumerable() where tmp.Field<long>("Rule_UpID") == (long)x["Rule_ID"] select tmp;//显示当前1级菜单的2级菜单
                        foreach (DataRow y in twoNodes)
                        {
                            TreeNode d2CreateNode = (TreeNode)Activator.CreateInstance(typeof(TreeNode), true);
                            d2CreateNode.Text = y["Rule_Name"].ToString();
                            d2CreateNode.Name = y["Rule_ID"].ToString();
                            d1CreateNode.Nodes.Add(d2CreateNode);
                            //添加3级菜单
                            var threeNodes = from tmp in tmpDT.AsEnumerable() where tmp.Field<long>("Rule_UpID") == (long)y["Rule_ID"] select tmp;//显示当前2级菜单的3级菜单
                            foreach (DataRow z in threeNodes)
                            {
                                TreeNode d3CreateNode = (TreeNode)Activator.CreateInstance(typeof(TreeNode), true);
                                d3CreateNode.Text = z["Rule_Name"].ToString();
                                d3CreateNode.Name = z["Rule_ID"].ToString();
                                d2CreateNode.Nodes.Add(d3CreateNode);
                                //添加4级菜单
                                var fourNodes = from tmp in tmpDT.AsEnumerable() where tmp.Field<long>("Rule_UpID") == (long)z["Rule_ID"] select tmp;//显示当前3级菜单的4级菜单
                                foreach (DataRow z4 in fourNodes)
                                {
                                    TreeNode d4CreateNode = (TreeNode)Activator.CreateInstance(typeof(TreeNode), true);
                                    d4CreateNode.Text = z4["Rule_Name"].ToString();
                                    d4CreateNode.Name = z4["Rule_ID"].ToString();
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
            catch (Exception)
            {
                throw;
            }
        }

        //==================================================================================================
        /// <summary>
        /// 根据Group_ID，选择TreeView的CheckBox状态
        /// </summary>
        /// <param name="TV">DataTable</param>
        /// <param name="Group_ID">角色ID</param>
        /// <returns>string</returns>
        public string SetTreeViewCheckBox(TreeView TV, long Group_ID)
        {
            try
            {
                //取Group_ID的所有权限
                ReadToPool(PoolType.GroupsRules);
                DataTable tmpDT = ReadPool(PoolType.GroupsRules);
                var request = from tmp in tmpDT.AsEnumerable() where tmp.Field<long>("Group_ID") == Group_ID select tmp;
                List<long> tmpRuleIDs = new List<long>();
                foreach (DataRow x in request)
                {
                    tmpRuleIDs.Add((long)x["Rule_ID"]);
                }
                foreach (TreeNode x1 in TV.Nodes)//1级
                {
                    if (tmpRuleIDs.Contains(Convert.ToInt64(x1.Name)))
                    {
                        x1.Checked = true;
                    }
                    else
                    {
                        x1.Checked = false;
                    }
                    if (x1.Nodes.Count > 0)
                    {
                        foreach (TreeNode x2 in x1.Nodes)//2级
                        {
                            if (tmpRuleIDs.Contains(Convert.ToInt64(x2.Name)))
                            {
                                x2.Checked = true;
                            }
                            else
                            {
                                x2.Checked = false;
                            }
                            if (x2.Nodes.Count > 0)
                            {
                                foreach (TreeNode x3 in x2.Nodes)//3级
                                {
                                    if (tmpRuleIDs.Contains(Convert.ToInt64(x3.Name)))
                                    {
                                        x3.Checked = true;
                                    }
                                    else
                                    {
                                        x3.Checked = false;
                                    }
                                    if (x3.Nodes.Count > 0)
                                    {
                                        foreach (TreeNode x4 in x3.Nodes)//4级
                                        {
                                            if (tmpRuleIDs.Contains(Convert.ToInt64(x4.Name)))
                                            {
                                                x4.Checked = true;
                                            }
                                            else
                                            {
                                                x4.Checked = false;
                                            }
                                            if (x4.Nodes.Count > 0)
                                            {
                                                //5级（暂未添加）
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return "true";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetTreeViewCheckedSave(TreeView TV,long Group_ID)
        {
            try
            {
                DataTable tmpGr2Ru = ReadPool(PoolType.Gr2Ru);//取角色与规则对应表
                DataTable tmpGr2RuNotes = tmpGr2Ru.Clone(); //根据TreeView生成DataTable
                DataRow tmpRow;
                foreach (TreeNode x1 in TV.Nodes)//1级
                {
                    if (x1.Checked)
                    {
                        tmpRow = tmpGr2RuNotes.NewRow();
                        tmpRow[0] = Group_ID;
                        tmpRow[1] = Convert.ToInt64(x1.Name);
                        tmpGr2RuNotes.Rows.Add(tmpRow);
                        if (x1.Nodes.Count > 0)
                        {
                            foreach (TreeNode x2 in x1.Nodes)//2级
                            {
                                if (x2.Checked)
                                {
                                    tmpRow = tmpGr2RuNotes.NewRow();
                                    tmpRow[0] = Group_ID;
                                    tmpRow[1] = Convert.ToInt64(x2.Name);
                                    tmpGr2RuNotes.Rows.Add(tmpRow);
                                    if (x2.Nodes.Count > 0)
                                    {
                                        foreach (TreeNode x3 in x2.Nodes)//3级
                                        {
                                            if (x3.Checked)
                                            {
                                                tmpRow = tmpGr2RuNotes.NewRow();
                                                tmpRow[0] = Group_ID;
                                                tmpRow[1] = Convert.ToInt64(x3.Name);
                                                tmpGr2RuNotes.Rows.Add(tmpRow);
                                                if (x3.Nodes.Count > 0)
                                                {
                                                    foreach (TreeNode x4 in x3.Nodes)//4级
                                                    {
                                                        if (x4.Checked)
                                                        {
                                                            tmpRow = tmpGr2RuNotes.NewRow();
                                                            tmpRow[0] = Group_ID;
                                                            tmpRow[1] = Convert.ToInt64(x4.Name);
                                                            tmpGr2RuNotes.Rows.Add(tmpRow);
                                                            if (x4.Nodes.Count > 0)
                                                            {
                                                                //5级，（暂未做）
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (DataRow x in tmpGr2Ru.AsEnumerable())
                {
                    if (Convert.ToInt64(x["Group_ID"]) == Group_ID)
                    {
                        x.Delete();
                    }
                }

                tmpGr2Ru.Merge(tmpGr2RuNotes, true);
                SavePool(PoolType.Gr2Ru,tmpGr2Ru);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion

        #region 9------一些其它方法
        #region 1--密码转换
        //==================================================================================================
        /// <summary>
        /// 把密码进行MD5加密
        /// </summary>
        /// <param name="souPass">密码明文</param>
        /// <returns>string</returns>
        public string SecToMd5(string souPass)
        {
            string Md5Pass = "";
            AuthDao.ADSecret ads = new AuthDao.ADSecret();
            Md5Pass = ads.MD5Encrypt(souPass);
            ads = null;
            return Md5Pass;
        }
        #endregion
        #endregion
    }
}
