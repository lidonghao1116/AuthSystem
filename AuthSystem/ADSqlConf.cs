using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthSystem.AuthModel;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 基础AuthDao类
    /// 只从Model取数据，不直接与数据库连接
    /// </summary>
    public class ADSqlConf:ADBase
    {
        public ADSqlConf()
        {
            //TODO：构造函数
        }
        /// <summary>
        /// 操作连接数据库的配置文件
        /// </summary>
        /// <param name="ams">AMSqlConf，SQL配置数据对象</param>
        /// <param name="adsa">对配置数据的操作方式</param>
        public ADSqlConf(AMSqlConf ams, ADSqlConfAction adsa)
        {
            if(adsa==ADSqlConfAction.Read)//从硬盘配置文件读取配置
            {

            }
            else if(adsa==ADSqlConfAction.Write)//把配置写入硬盘配置文件
            {

            }
            else if(adsa==ADSqlConfAction.Edit)//修改配置文件
            {

            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 对配置文件的操作方式
        /// </summary>
        public enum ADSqlConfAction 
        {
            Read,
            Write,
            Edit
        }
    }
}
