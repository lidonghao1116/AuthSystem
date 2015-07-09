using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AuthSystem.AuthData
{
    /// <summary>
    /// 操作SQL与Pool的基类
    /// </summary>
    public class ADBase
    {
        public string ConnString = "";
        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 获取数据库连接对象
        /// </summary>
        /// <param name="amsc">数据库的配置对象</param>
        /// <returns>返回一个SqlConnection对象</returns>
        public  SqlConnection GetConn()
        {
            try
            {
                SqlConnection tmpSqlConn = new SqlConnection(ConnString);
                return tmpSqlConn;
            }
            catch (Exception x)
            {
                throw x;
            }
        }


        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 获取一个数据对象SqlDataReader
        /// </summary>
        /// <param name="Command">要执行的SQL语句</param>
        /// <returns>返回一个SqlDataReader对象</returns>
        public SqlDataReader GetDataReader(string Command)
        {
            SqlDataReader tmpDataReader;
            SqlConnection tmpConn = new SqlConnection();
            try
            {
                tmpConn = GetConn();
                tmpConn.Open();
                SqlCommand tmpComm = new SqlCommand(Command, tmpConn);
                tmpDataReader = tmpComm.ExecuteReader();
                return tmpDataReader;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 返回一个适配器sqlDataAdapter
        /// </summary>
        /// <param name="Command">SQL语句</param>
        /// <param name="amsc">数据库配置对象</param>
        /// <returns>返回一个SqlDataAdapter</returns>
        public SqlDataAdapter GetDataAdapter(string Command)
        {
            SqlDataAdapter tmpDataAdapter;
            SqlConnection tmpConn = GetConn();
            try
            {
                SqlCommand tmpComm = new SqlCommand(Command, tmpConn);
                tmpDataAdapter = new SqlDataAdapter(tmpComm);
                return tmpDataAdapter;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
