using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthModel;
using System.Data;

namespace AuthSystem.AuthPool
{
    /// <summary>
    /// 定义 数据库的数据缓存 池
    /// </summary>
    public class APDbPool:APBase
    {
        public APDbPool()
        {
        }
        /// <summary>
        /// 初始化
        /// </summary>
        static APDbPool()
        {
            poolAll.Tables.Add(poolAMUsers);
            poolAll.Tables.Add(poolAMGroups);
            poolAll.Tables.Add(poolGr2Ca);
            poolAll.Tables.Add(poolGr2Me);
            poolAll.Tables.Add(poolGr2Ru);
            poolAll.Tables.Add(poolAMRules);
            poolAll.Tables.Add(poolRu2It);
            poolAll.Tables.Add(poolAMItems);
            poolAll.Tables.Add(poolAMItemsNo);
            poolAll.Tables.Add(poolGroupsRules);
            poolAll.Tables.Add(poolGroupsItems);
        }
        public static DataSet poolAll = new DataSet("poolALL");
        private static DataTable poolAMUsers = new DataTable("poolAMUsers");         //所有用户

        private static DataTable poolAMGroups = new DataTable("poolAMGroups");        //所有角色

        private static DataTable poolGr2Ca = new DataTable("poolGr2Ca");           //角色对应仓库
        private static DataTable poolGr2Ru = new DataTable("poolGr2Ru");           //角色对应规则
        private static DataTable poolGr2Me = new DataTable("poolGr2Me");           //角色对应菜单

        private static DataTable poolAMRules = new DataTable("poolAMRules");         //所有规则
        private static DataTable poolRu2It = new DataTable("poolRu2It");           //规则对应对象

        private static DataTable poolAMItems = new DataTable("poolAMItems");      //所有对象
        private static DataTable poolAMItemsNo = new DataTable("poolAMItemsNo");    //不进行权限管理的对象

        //以下为SQL中的视图
        private static DataTable poolGroupsRules = new DataTable("poolGroupsRules");//角色与规则的视图
        private static DataTable poolGroupsItems = new DataTable("poolGroupsItems");//角色与对象的视图
    }

    /// <summary>
    /// 连接池的类型
    /// </summary>
    public enum APPoolType
    {
        AMUsers,
        AMGroups,
        AMGr2Ca,
        AMGr2Ru,
        AMRules,
        AMRu2It,
        AMItems,
        AMItemsNo,
        AMGroupsRules,
        AMGroupsItems
    }
}
