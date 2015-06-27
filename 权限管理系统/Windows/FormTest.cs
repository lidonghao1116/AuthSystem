using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AuthSystem.AuthForm;
using AuthSystem.AuthModel;


namespace 权限管理系统.Windows
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            AuthSystem.AuthDao.ADAuthOpera.SetWindowsAuth(AuthSystem.AuthGlobal.GlobalAmu, this.Controls);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthPool2Db.AP2DOpera.GetPool(AuthSystem.AuthPool.APPoolType.AMUsers);
            
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
            AuthSystem.AuthForm.AFAuthSet afas = new AFAuthSet();
            
            afas.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

    }
}
