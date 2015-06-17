using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 权限管理系统.Windows
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            AuthAct();
        }
        private void AuthAct()
        {
            //当前登陆的用户
            AuthSystem.AuthModel.AMSqlConf amsc = AuthSystem.AuthDao.ADConfig.LoadSqlConf();
            AuthSystem.AuthDao.ADAuthOpera.AMSqlConfig = amsc;
            AuthSystem.AuthModel.AMUser amu = AuthSystem.AuthDao.ADAuthOpera.GetAuthUser("alwcel");
            //MessageBox.Show(amu.User_Name + amu.User_Text+amu.User_Group);
            if (AuthSystem.AuthDao.ADAuthOpera.SetWindowsAuth(amu, this.Controls))
                MessageBox.Show("成功");
            else
                MessageBox.Show("失败");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("添加!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("修改!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("删除");
        }
    }
}
