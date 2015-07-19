using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AuthSystem
{
    /// <summary>
    /// SQL server 操作类
    /// </summary>
    public sealed class SqlAction
    {
        #region ----初始化----
        static SqlAction()
        {
        }
        #endregion

        #region 0---公共变量
        public static string globalConnectionString = "";//默认连接字符串

        #endregion

        #region 1---取基础对象

        #region SqlConnection
        //==============================================================================================================
        /// <summary>
        /// 获取数据库连接对象;
        /// </summary>
        /// <returns>返回SqlConnection</returns>
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection tmpConn = new SqlConnection(globalConnectionString);
                return tmpConn;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetConnection" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库连接对象;
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns>返回SqlConnection</returns>
        public static SqlConnection GetConnection(string connectionString)
        {
            try
            {
                SqlConnection tmpConn = new SqlConnection(connectionString);
                return tmpConn;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetConnection" + x.Message);
                throw;
            }
        }

        #endregion

        #region SqlCommand
        //==============================================================================================================
        /// <summary>
        /// 获取数据库命令对象;
        /// </summary>
        /// <returns>返回SqlCommand</returns>
        public static SqlCommand GetCommand()
        {
            try
            {
                SqlCommand tmpComm = GetConnection().CreateCommand();
                return tmpComm;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetCommand" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库命令对象;
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <returns>返回SqlCommand</returns>
        public static SqlCommand GetCommand(string commandText)
        {
            try
            {
                SqlCommand tmpComm = GetCommand();
                tmpComm.CommandText = commandText;
                return tmpComm;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetCommand" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库命令对象;
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandText">SQL命令</param>
        /// <returns>返回SqlCommand</returns>
        public static SqlCommand GetCommand(string connectionString,string commandText)
        {
            try
            {
                SqlCommand tmpComm = new SqlConnection(connectionString).CreateCommand();
                tmpComm.CommandText = commandText;
                return tmpComm;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetCommand" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库命令对象;
        /// </summary>
        /// <param name="sqlConnection">数据库连接对象</param>
        /// <returns>返回SqlCommand</returns>
        public static SqlCommand GetCommand(SqlConnection sqlConnection)
        {
            try
            {
                SqlCommand tmpComm = sqlConnection.CreateCommand();
                return tmpComm;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetCommand" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库命令对象;
        /// </summary>
        /// <param name="sqlConnection">数据库连接对象</param>
        /// <param name="commandText">SQL命令</param>
        /// <returns>返回SqlCommand</returns>
        public static SqlCommand GetCommand(SqlConnection sqlConnection, string commandText)
        {
            try
            {
                SqlCommand tmpComm = sqlConnection.CreateCommand();
                tmpComm.CommandText = commandText;
                return tmpComm;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetCommand" + x.Message);
                throw;
            }
        }
        #endregion

        #region SqlDataReader
        //==============================================================================================================
        /// <summary>
        /// 获取数据库DataReader;
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <returns>返回SqlDataReader</returns>
        public static SqlDataReader GetDataReader(string commandText)
        {
            try
            {
                SqlDataReader tmpSDR = GetCommand(commandText).ExecuteReader();
                return tmpSDR;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetDataReader" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库DataReader;
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="commandBehavior">提供对查询结果和查询对数据库的影响的说明</param>
        /// <returns>返回SqlDataReader</returns>
        public static SqlDataReader GetDataReader(string commandText,CommandBehavior commandBehavior)
        {
            try
            {
                SqlDataReader tmpSDR = GetCommand(commandText).ExecuteReader(commandBehavior);
                return tmpSDR;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetDataReader" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库DataReader;
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="connectionString">连接字符串</param>
        /// <returns>返回SqlDataReader</returns>
        public static SqlDataReader GetDataReader(string commandText,string connectionString)
        {
            try
            {
                SqlDataReader tmpSDR = GetCommand(connectionString, commandText).ExecuteReader();
                return tmpSDR;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetDataReader" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库DataReader;
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandBehavior">提供对查询结果和查询对数据库的影响的说明</param>
        /// <returns>返回SqlDataReader</returns>
        public static SqlDataReader GetDataReader(string commandText, string connectionString, CommandBehavior commandBehavior)
        {
            try
            {
                SqlCommand tmpComm = GetCommand(connectionString, commandText);
                SqlDataReader tmpSDR = tmpComm.ExecuteReader(commandBehavior);
                return tmpSDR;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetDataReader" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库DataReader;
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="sqlConnection">数据库连接对象</param>
        /// <<returns>返回SqlDataReader</returns>
        public static SqlDataReader GetDataReader(string commandText, SqlConnection sqlConnection)
        {
            try
            {
                SqlDataReader tmpSDR = GetCommand(sqlConnection, commandText).ExecuteReader();
                return tmpSDR;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetDataReader" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库DataReader;
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="sqlConnection">数据库连接对象</param>
        /// <param name="commandBehavior">提供对查询结果和查询对数据库的影响的说明</param>
        /// <returns>返回SqlDataReader</returns>
        public static SqlDataReader GetDataReader(string commandText, SqlConnection sqlConnection, CommandBehavior commandBehavior)
        {
            try
            {
                SqlDataReader tmpSDR = GetCommand(sqlConnection, commandText).ExecuteReader(commandBehavior);
                return tmpSDR;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetDataReader" + x.Message);
                throw;
            }
        }
        #endregion

        #region SqlDataAdapter
        //==============================================================================================================
        /// <summary>
        /// 获取数据库DataAdapter;
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="connectionString">连接字符串</param>
        /// <returns>返回SqlDataAdapter</returns>
        public static SqlDataAdapter GetDataAdapter(string commandText,string connectionString)
        {
            try
            {
                SqlDataAdapter tmpSDA = new SqlDataAdapter(commandText, connectionString);
                return tmpSDA;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetDataAdapter" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库DataAdapter;
        /// </summary>
        /// <param name="sqlCommand">数据库命令对象</param>
        /// <returns>返回SqlDataAdapter</returns>
        public static SqlDataAdapter GetDataAdapter(SqlCommand sqlCommand)
        {
            try
            {
                SqlDataAdapter tmpSDA = new SqlDataAdapter(sqlCommand);
                return tmpSDA;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetDataAdapter" + x.Message);
                throw;
            }
        }

        //==============================================================================================================
        /// <summary>
        /// 获取数据库DataAdapter;
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="sqlConnection">数据库连接对象</param>
        /// <returns>返回SqlDataAdapter</returns>
        public static SqlDataAdapter GetDataAdapter(string commandText,SqlConnection sqlConnection)
        {
            try
            {
                SqlDataAdapter tmpSDA = new SqlDataAdapter(commandText,sqlConnection);
                return tmpSDA;
            }
            catch (Exception x)
            {
                Console.WriteLine("模块:GetDataAdapter" + x.Message);
                throw;
            }
        }
        #endregion

        #region 

        #endregion

        //==============================================================================================================
        //==============================================================================================================
        //==============================================================================================================
        //==============================================================================================================
        //==============================================================================================================
        //==============================================================================================================
        //==============================================================================================================
        //==============================================================================================================
        

        #endregion

        #region 2---取服务器信息
        public static string GetServerTime()
        {
            try
            {
                string tmp;
                SqlCommand tmpComm = GetCommand("select sysdatetime()");
                tmpComm.Connection.Open();
                tmp = tmpComm.ExecuteScalar().ToString();

                return tmp;
            }
            catch (Exception x)
            {
                DebugMsg.Add(x);
                return null;
            }
        }
        #endregion
    }
}
