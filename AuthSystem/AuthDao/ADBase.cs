using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AuthSystem.AuthMenu;
using AuthSystem.AuthModel;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 基础AuthDao类
    /// 只从Model取数据，不直接与数据库连接
    /// </summary>
    public class ADBase
    {
        public ADBase()
        {
            //TODO 
        }
        /// <summary>-----------------------------------------------------------------------------------------------
        /// 获取数据库连接对象
        /// </summary>
        /// <param name="amsc">数据库的配置对象</param>
        /// <returns>返回一个SqlConnection对象</returns>
        public SqlConnection GetConn(AuthSystem.AuthModel.AMSqlConf amsc)
        {
            try
            {
                SqlConnection tmpSqlConn = new SqlConnection(amsc.ConnString);
                tmpSqlConn.Open();
                tmpSqlConn.Close();
                return tmpSqlConn;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 获取一个数据对象
        /// </summary>
        /// <param name="Command">要执行的SQL语句</param>
        /// <param name="amsc">数据库的配置对象</param>
        /// <returns>返回一个SqlDataReader对象</returns>
        public SqlDataReader GetDataReader(string Command, AuthSystem.AuthModel.AMSqlConf amsc)
        {
            SqlDataReader tmpDataReader;
            SqlConnection tmpConn = new SqlConnection();
            try
            {
                tmpConn = GetConn(amsc);
                tmpConn.Open();
                SqlCommand tmpComm = new SqlCommand(Command, tmpConn);
                tmpDataReader = tmpComm.ExecuteReader();
                return tmpDataReader;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (tmpConn.State == System.Data.ConnectionState.Open)
                {
                    tmpConn.Close();
                }
            }
        }
    }
}
