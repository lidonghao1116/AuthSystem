using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 权限管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthModel.AMLogin am = new AuthSystem.AuthModel.AMLogin();
            am.Name = textBox1.Text;
            am.PassWord = textBox2.Text;
            AuthSystem.AuthDao.ADLogin al = new AuthSystem.AuthDao.ADLogin();
            //MessageBox.Show(al.CanLogin(am));
        }
    }
}
