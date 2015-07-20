using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem
{
    /// <summary>
    /// 输出调试信息类！
    /// </summary>
    public class DebugMsg
    {
        static DebugMsg()
        {
        }
        /// <summary>
        /// 获取或设置是否写入DebguMsg信息到磁盘 
        /// </summary>
        public static bool CloseDebugMsg;
        /// <summary>
        /// 默认路径与文件名
        /// </summary>
        private static string _filePath = "DebugMsg\\Debug" + DateTime.Now.Date.GetDateTimeFormats('d')[1].ToString() + ".txt";
        /// <summary>
        /// 保存设置信息的路径
        /// </summary>
        public static string filePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        /// <summary>
        /// 添加出错调试信息
        /// </summary>
        /// <param name="debugMessage">信息内容</param>
        /// <param name="ClassName">标题或者类名或者方法名</param>
        public static void Add(string debugMessage,string ClassName="Unknow")
        {
            try
            {
                if (!CloseDebugMsg)
                {
                    if (!hasFile())
                    {
                        AddFile();
                    }
                    System.IO.FileStream fs = System.IO.File.Open(filePath, System.IO.FileMode.Open);
                    byte[] tmpData = System.Text.Encoding.Default.GetBytes("[" + DateTime.Now.ToString() + "] ||| [" + ClassName + "]  [" + debugMessage + "]\r\n");
                    fs.Position = fs.Length;
                    fs.Write(tmpData, 0, tmpData.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.WriteLine("DebugMsg.Add:"+x.Message);
                throw;
            }
        }
        /// <summary>
        /// 添加出错调试信息
        /// </summary>
        /// <param name="exception">抛出的异常实体Exception</param>
        public static void Add(Exception exception)
        {
            try
            {
                if (!hasFile())
                {
                    AddFile();
                }
                System.IO.FileStream fs = System.IO.File.Open(filePath, System.IO.FileMode.Open);
                string tmpStr = exception.StackTrace.Remove(0, exception.StackTrace.LastIndexOf("在") - 1);
                byte[] tmpData = System.Text.Encoding.Default.GetBytes("[" + DateTime.Now.ToString() + "] ||| [" + tmpStr + "]<...>[" + exception.Message + "]\r\n");
                fs.Position = fs.Length;
                fs.Write(tmpData, 0, tmpData.Length);
                fs.Flush();
                fs.Close();
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.WriteLine("DebugMsg.Add:" + x.Message);
                throw;
            }
        }
        /// <summary>
        /// 检测是否存在输出文件
        /// </summary>
        /// <returns></returns>
        public static bool hasFile()
        {
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 新建配置文件，在指定路径
        /// </summary>
        /// <returns>返回Bool</returns>
        public static bool AddFile()
        {
            try
            {
                string tmpPath = filePath.Remove(filePath.LastIndexOf('\\'));
                System.IO.Directory.CreateDirectory(tmpPath);
                System.IO.File.Open(filePath, System.IO.FileMode.OpenOrCreate).Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
