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
    public class APPool:APBase
    {
        public APPool()
        {
        }
        /// <summary>
        /// 初始化
        /// </summary>
        static APPool()
        {
            poolAll.Tables.AddRange(new DataTable[]{
            poolAuthUsers,
            poolAuthUs2Gr,
            poolAuthGroups,
            poolAuthGr2Ca,
            poolAuthGr2Ru,
            poolAuthCangKu,
            poolAuthRules,
            poolAuthRu2It,
            poolAuthItems,
            poolAuthItemsNo,
            pvGroupsRules,
            pvGroupsItems
            });
        }

        public static DataSet poolAll = new DataSet("pool");
        private static DataTable poolAuthUsers = new DataTable("poolAuthUsers");         //所有用户
        private static DataTable poolAuthUs2Gr = new DataTable("poolAuthUs2Gr");            //用户对应角色

        private static DataTable poolAuthGroups = new DataTable("poolAuthGroups");        //所有角色
        private static DataTable poolAuthGr2Ca = new DataTable("poolAuthGr2Ca");           //角色对应仓库
        private static DataTable poolAuthGr2Ru = new DataTable("poolAuthGr2Ru");           //角色对应规则

        private static DataTable poolAuthCangKu = new DataTable("poolAuthCangKu");          //仓库表

        private static DataTable poolAuthRules = new DataTable("poolAuthRules");         //所有规则
        private static DataTable poolAuthRu2It = new DataTable("poolAuthRu2It");           //规则对应对象

        private static DataTable poolAuthItems = new DataTable("poolAuthItems");      //所有对象
        private static DataTable poolAuthItemsNo = new DataTable("poolAuthItemsNo");    //不进行权限管理的对象

        //以下为SQL中的视图
        private static DataTable pvGroupsRules = new DataTable("pvGroupsRules");//角色与规则的视图
        private static DataTable pvGroupsItems = new DataTable("pvGroupsItems");//角色与对象的视图
    }

    /// <summary>
    /// 连接池的类型
    /// </summary>
    public enum PoolType
    {
        Users,
        Us2Gr,
        Groups,
        Gr2Ca,
        Gr2Ru,
        Rules,
        Ru2It,
        CangKu,
        Items,
        ItemsNo,
        GroupsRules,
        GroupsItems
    }
}
