using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthModel;

namespace AuthSystem.AuthPool
{
    /// <summary>
    /// 定义 数据库的数据缓存 池
    /// </summary>
    public class APDbPool:APBase
    {
        public APDbPool()
        {
            //Init
        }

        public static AMUser poolAMUser = null;             //用户
        public static List<AMUser> poolAMUsers = null;      //所有用户

        public static AMGroup poolAMGroup = null;           //角色
        public static List<AMGroup> poolAMGroups = null;    //所有角色
        public static List<AMX2Y> poolGr2Ca = null;               //角色对应仓库
        public static List<AMX2Y> poolGr2Ru = null;               //角色对应规则
        public static List<AMX2Y> poolGr2Me = null;               //角色对应菜单

        public static AMRule poolAMRule = null;             //规则
        public static List<AMRule> poolAMRules = null;      //所有规则
        public static List<AMX2Y> poolRu2It = null;               //规则对应对象

        public static AMItem poolAMItem = null;             //对象
        public static List<AMItem> poolAMItems = null;      //所有对象
    }

    /// <summary>
    /// 连接池的类型
    /// </summary>
    public enum APPoolType
    {
        AMUsers,
        AMGroups,
        AMGr2Ca,
        AMGr2RU,
        AMRules,
        AMItems
    }
}
