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
            AuthSystem.AuthDao.ADAuthOpera.AMSqlConfig = amsc;//加载DAO所用的配置文件
            amu = AuthSystem.AuthDao.ADAuthOpera.GetAuthUser();
        }
    }
}
