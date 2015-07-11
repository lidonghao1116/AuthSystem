using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AuthSystem.AuthDao;

namespace AuthSystem.AuthForm
{
    public partial class AFSetPassword : Form
    {
        public AFSetPassword()
        {
            InitializeComponent();
        }
        public AFSetPassword(string User)
        {
            InitializeComponent();
            UserName = User;
            lb_UserName.Text = UserName;
        }
        private string UserName;
        public string PassWord;

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (tb_1Password.Text == tb_2Password.Text)
            {
                ADSecret ads = new ADSecret();
                PassWord = ads.MD5Encrypt(tb_1Password.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                MessageBox.Show("两次输入的密码不匹配，请重新输入!");
                tb_1Password.Text = "";
                tb_2Password.Text = "";
                tb_1Password.Focus();
            }

        }

        private void bt_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
