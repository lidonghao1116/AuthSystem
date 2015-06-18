using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 权限管理系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AuthSystem.AuthGlobal.GlobalAmsc = AuthSystem.AuthDao.ADConfig.LoadSqlConf();
            AuthSystem.AuthDao.ADAuthOpera.AMSqlConfig = AuthSystem.AuthGlobal.GlobalAmsc;
            AuthSystem.AuthGlobal.GlobalAmu = AuthSystem.AuthDao.ADAuthOpera.GetAuthUser("alwcel");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Windows.FormTest());
        }
    }
}
