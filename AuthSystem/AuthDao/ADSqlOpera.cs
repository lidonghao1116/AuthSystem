using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 操作数据库的类
    /// </summary>
    public class ADSqlOpera:ADBase
    {
        public ADSqlOpera()
        {
            //TODO
        }

        #region 10-------执行一条SQL语句
        //--------------------------------------------------------------------------------------------------
        /// <summary>
        /// 执行一条SQL语句
        /// </summary>
        /// <param name="CommText">SQL语句</param>
        /// <param name="amsc">数据库连接配置对象</param>
        /// <returns>返回影响的行数</returns>
        public static int ExcSqlCommand(string CommText,AuthModel.AMSqlConf amsc)
        {
            int x = -1;
            try
            {
                SqlConnection tmpConn = GetConn(amsc);
                tmpConn.Open();
                SqlCommand tmpComm = new SqlCommand(CommText, tmpConn);
                x = tmpComm.ExecuteNonQuery();
                tmpConn.Close();
                return x;
            }
            catch (Exception)
            {
                return x;
                throw;
            }
        }
        #endregion

        
    }
}
