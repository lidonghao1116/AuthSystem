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
    public partial class FormLogin : AFLogin
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthModel.AMSqlConf amsc = new AuthSystem.AuthModel.AMSqlConf();
            AuthSystem.AuthDao.ADSqlConf.LoadSqlConf(out amsc);
            AuthSystem.AuthModel.AMLogin aml = new AuthSystem.AuthModel.AMLogin();
            AuthSystem.AuthDao.ADLogin ld = new AuthSystem.AuthDao.ADLogin();
            if (ld.GetLoginMsg("alwcel", out aml))
            {
                MessageBox.Show(aml.AMLogins.ToString());
                MessageBox.Show(aml.Name + ":" + aml.PassWord);
            }
            else
            {
                MessageBox.Show(aml.AMLogins.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuStrip ms = new MenuStrip();
            AuthSystem.AuthModel.AMLogin aml = new AuthSystem.AuthModel.AMLogin();
            FormMain fmm = new FormMain();
            ToolStripMenuItem ts1 = new ToolStripMenuItem("文件");
            ms.Items.Add(ts1);
            fmm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuStrip ms = new MenuStrip();
            AuthSystem.AuthModel.AMMainMenu am = new AuthSystem.AuthModel.AMMainMenu();
            AuthSystem.AuthModel.AMMainMenus ams = new AuthSystem.AuthModel.AMMainMenus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

    }
}
