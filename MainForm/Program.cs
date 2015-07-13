using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MainForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //定义公共数据
            AuthSystem.AuthData.ADConfig tmpADC = new AuthSystem.AuthData.ADConfig();
            string ConnString;
            bool b;
            tmpADC.ReadConfig(AuthSystem.AuthModel.ConfigItem.ConnectionString, out ConnString, out b);
            //ConnString = @"Password=alwcel;Persist Security Info=True;User ID=sa;Initial Catalog=NewAuth;Data Source=JD-056-AC\ACSQL";
            AuthSystem.AuthPool.APPoolGlobal.GlobalAMSystemConfig.ConnectionString = ConnString;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
