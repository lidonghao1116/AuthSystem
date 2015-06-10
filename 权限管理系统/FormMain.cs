using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AuthSystem.AuthForm;
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

            FormMainMain fmm = new FormMainMain();
            this.Hide();
            fmm.ShowDialog();
            Application.Exit();
            
        }
    }
}
