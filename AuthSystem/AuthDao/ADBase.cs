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
        /// 获取数据库连接对象
        /// </summary>
        /// <param name="amsc">数据库的配置对象</param>
        /// <returns>返回一个SqlConnection对象</returns>
        public static SqlConnection GetConn(AuthSystem.AuthModel.AMSqlConf amsc)
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

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 获取数据库命令对象
        /// </summary>
        /// <param name="amsc">数据库的配置对象</param>
        /// <returns>返回SqlCommand对象</returns>
        public static SqlCommand GetComm(AuthSystem.AuthModel.AMSqlConf amsc)
        {
            try
            {
                SqlConnection tmpConn = GetConn(amsc);
                tmpConn.Open();
                SqlCommand tmpComm = new SqlCommand();
                tmpComm.Connection = tmpConn;
                return tmpComm;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 获取一个数据对象SqlDataReader
        /// </summary>
        /// <param name="Command">要执行的SQL语句</param>
        /// <param name="amsc">数据库的配置对象</param>
        /// <returns>返回一个SqlDataReader对象</returns>
        public static SqlDataReader GetDataReader(string Command, AuthSystem.AuthModel.AMSqlConf amsc)
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
        }

        //---------------------------------------------------------------------------------------------------------
        public static SqlDataAdapter GetDataAdapter(string Command, AuthSystem.AuthModel.AMSqlConf amsc)
        {
            SqlDataAdapter tmpDataAdapter;
            SqlConnection tmpConn = new SqlConnection();
            try
            {
                tmpConn = GetConn(amsc);
                SqlCommand tmpComm = new SqlCommand(Command, tmpConn);
                tmpDataAdapter = new SqlDataAdapter(tmpComm);
                return tmpDataAdapter;
            }
            catch (Exception)
            {
                throw;
            }
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
