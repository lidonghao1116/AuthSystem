using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AuthSystem.AuthForm;
using System.Data.SqlClient;
namespace 权限管理系统
{
    public partial class FormMain : AFLogin
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthModel.AMSqlConf amsc = new AuthSystem.AuthModel.AMSqlConf();
            AuthSystem.AuthDao.ADSqlConf.LoadSqlConf(out amsc);
        }
    }
}
