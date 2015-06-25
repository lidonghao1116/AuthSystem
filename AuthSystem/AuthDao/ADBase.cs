using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AuthSystem.AuthModel;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 基础AuthDao类
    /// 基础数据操作类
    /// </summary>
    public class ADBase
    {
        public ADBase()
        {
            //TODO 
        }
        
        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Bool转换成Int
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        public static int Bool2Int(bool bl)
        {
            if (bl)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        

    }
}
