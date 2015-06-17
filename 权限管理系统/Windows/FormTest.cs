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

        private void button4_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthModel.AMSqlConf amsc = AuthSystem.AuthDao.ADConfig.LoadSqlConf(); //加载配置文件
            AuthSystem.AuthModel.AMUser amu = new AuthSystem.AuthModel.AMUser();
            AuthSystem.AuthModel.AMUsers amus = new AuthSystem.AuthModel.AMUsers();
            AuthSystem.AuthDao.ADAuthOpera.AMSqlConfig = amsc;//加载DAO所用的配置文件
            amu = AuthSystem.AuthDao.ADAuthOpera.GetAuthUser("alw");
            amus = AuthSystem.AuthDao.ADAuthOpera.GetAuthUsers();
            //MessageBox.Show(amus.ListAMUsers.Count.ToString());
            //MessageBox.Show(amus.ListAMUsers[1].User_Text.ToString());
            MessageBox.Show(amu.User_Name);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthModel.AMSqlConf amsc = new AuthSystem.AuthModel.AMSqlConf();
            amsc.ConnString = @"Password=alwcel;Persist Security Info=True;User ID=sa;Initial Catalog=TestAuth;Data Source=JD-056-AC\ACSQL";
            AuthSystem.AuthDao.ADConfig.SetSqlConf(amsc);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthModel.AMSqlConf amsc = AuthSystem.AuthDao.ADConfig.LoadSqlConf(); //加载配置文件
            AuthSystem.AuthDao.ADAuthOpera.AMSqlConfig = amsc;//加载DAO所用的配置文件
            AuthSystem.AuthModel.AMUser amu = new AuthSystem.AuthModel.AMUser();
            amu = AuthSystem.AuthDao.ADAuthOpera.GetAuthUser("alwcel");
            List<object> objs=AuthSystem.AuthDao.ADAuthOpera.GetWindowsContrul(amu, this.Controls);

            foreach (object x in objs)
            {
                ((Control)x).Enabled = false;
            }
            

        }
    }
}
