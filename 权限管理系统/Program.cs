﻿using System;
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
            AuthSystem.AuthPool.APSoftPool.poolSoftSqlConf = AuthSystem.AuthDao.ADConfig.LoadSqlConf();
            AuthSystem.AuthGlobal.GlobalAmsc = AuthSystem.AuthDao.ADConfig.LoadSqlConf();

            AuthSystem.AuthPool.APSoftPool.poolSoftAMUser = AuthSystem.AuthDao.ADAuthOpera.GetAuthUser("alwcel");
            AuthSystem.AuthGlobal.GlobalAmu = AuthSystem.AuthDao.ADAuthOpera.GetAuthUser("alwcel");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Windows.FormTest());
        }
    }
}
