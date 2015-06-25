using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AuthSystem.AuthModel;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 有关数据库操作的基础类！
    /// 一些基本的方法
    /// </summary>
    public class ADDbBase:ADBase
    {
        public ADDbBase()
        {
            //Init
        }

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 从公共数据中，取数据库的配置对象
        /// </summary>
        /// <returns>返回AMSqlConf</returns>
        public static AMSqlConf GetSqlConf()
        {
             return AuthGlobal.GlobalAmsc;
        }

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 获取数据库连接对象
        /// </summary>
        /// <param name="amsc">数据库的配置对象</param>
        /// <returns>返回一个SqlConnection对象</returns>
        public static SqlConnection GetConn()
        {
            try
            {
                SqlConnection tmpSqlConn = new SqlConnection(GetSqlConf().ConnString);
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
        public static SqlCommand GetComm()
        {
            try
            {
                SqlConnection tmpConn = GetConn();
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
        public static SqlDataReader GetDataReader(string Command)
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
        public static SqlDataAdapter GetDataAdapter(string Command)
        {
            SqlDataAdapter tmpDataAdapter;
            SqlConnection tmpConn = new SqlConnection();
            try
            {
                tmpConn = GetConn();
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
        /// 获取指定AMItems与valueType的所有数据
        /// </summary>
        /// <param name="valueType">要获取的数据列</param>
        /// <param name="AMItems">AMItems</param>
        /// <returns>List.string</returns>
        public static List<string> GetAMItemsValue(AMItemValueType valueType,List<AMItem> AMItems)
        {
            List<string> tmpList = new List<string>();
            foreach (AMItem x in AMItems)
            {
                switch (valueType)
                {
                    case AMItemValueType.Item_ID:
                        tmpList.Add(x.Item_ID);
                        break;
                    case AMItemValueType.Item_Name:
                        tmpList.Add(x.Item_Name);
                        break;
                    case AMItemValueType.Item_NameSpace:
                        tmpList.Add(x.Item_NameSpace);
                        break;
                    case AMItemValueType.Item_BeiZhu:
                        tmpList.Add(x.Item_BeiZhu);
                        break;
                    default:
                        break;
                }
            }
            return tmpList;
        }

        //---------------------------------------------------------------------------------------------------------

    }
}
