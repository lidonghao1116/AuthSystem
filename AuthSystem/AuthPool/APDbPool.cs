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
        }
        public static DataSet poolAll = new DataSet("poolALL");
        public static DataTable poolAMUsers = new DataTable("poolAMUsers");         //所有用户

        public static DataTable poolAMGroups = new DataTable("poolAMGroups");        //所有角色

        public static DataTable poolGr2Ca = new DataTable("poolGr2Ca");           //角色对应仓库
        public static DataTable poolGr2Ru = new DataTable("poolGr2Ru");           //角色对应规则
        public static DataTable poolGr2Me = new DataTable("poolGr2Me");           //角色对应菜单

        public static DataTable poolAMRules = new DataTable("poolAMRules");         //所有规则
        public static DataTable poolRu2It = new DataTable("poolRu2It");           //规则对应对象

        public static DataTable poolAMItems = new DataTable("poolAMItems");      //所有对象
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
        AMItems
    }
}
