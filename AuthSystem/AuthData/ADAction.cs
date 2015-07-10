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
        public string SetTreeView(TreeView TV, DataTable DT)
        {
            try
            {


                return "true";
            }
            catch (Exception x)
            {
                //return "SetTreeView:" + x.Message;
                throw;
            }
        }
        #endregion
    }
}
