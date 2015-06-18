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
                this.Text = "成功";
            else
                this.Text = "失败";
            List<object> tobj = AuthSystem.AuthDao.ADAuthOpera.GetWindowsContrul(this.Controls);
            foreach (var x in tobj)
            {
                listBox1.Items.Add(((Control)x).Name);
            }
            List<object> tMenu = AuthSystem.AuthDao.ADAuthOpera.GetWindowsMenu(this.Controls);
            foreach (var x in tMenu)
            {
                listBox2.Items.Add(((ToolStripMenuItem)x).Text);
            }
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
