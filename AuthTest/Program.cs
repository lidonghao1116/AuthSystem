﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AuthTest
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}