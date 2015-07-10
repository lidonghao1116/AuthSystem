using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AuthSystem.AuthData;


namespace MainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tmpConnstring = AuthSystem.AuthPool.APPoolGlobal.GlobalAMSystemConfig.ConnectionString;
            
            ADAction ac = new ADAction();
            ac.ConnString = tmpConnstring;
            MessageBox.Show(ac.ReadToPool());
            DataTable dt=ac.ReadPool(AuthSystem.AuthPool.PoolType.Users);
            MessageBox.Show(dt.Rows.Count.ToString());
        }

        private void SaveConfig_Click(object sender, EventArgs e)
        {
            string tmpConnString = tb_Conn.Text;
            string tmpUsername = tb_Username.Text;
            string tmpPassword = tb_password.Text;
            bool tmpIsSave = cb_isSave.Checked;
            AuthSystem.AuthModel.AMSystemConfig amsc = new AuthSystem.AuthModel.AMSystemConfig();
            amsc.ConnectionString = tmpConnString;
            amsc.LoginUserNames = tmpUsername;
            amsc.LoginPassword = tmpPassword;
            amsc.LoginSavePass = tmpIsSave;
            ADConfig ac = new ADConfig();
            tb_Status.Text = ac.SaveConfig(amsc);
        }

        private void ReadConfig_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthModel.AMSystemConfig amsc = new AuthSystem.AuthModel.AMSystemConfig();
            ADConfig ac = new ADConfig();
            tb_Status.Text = ac.ReadConfig(out amsc);
            tb_Conn.Text = amsc.ConnectionString;
            tb_password.Text = amsc.LoginPassword;
            tb_Username.Text = amsc.LoginUserNames;
            cb_isSave.Checked = amsc.LoginSavePass;
        }

        private void Form_RuleItem_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthForm.AFAuthRuleBinding tmpForm = new AuthSystem.AuthForm.AFAuthRuleBinding();
            tmpForm.ShowDialog();
        }

        private void Form_AuthSet_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthForm.AFAuthSet tmpForm = new AuthSystem.AuthForm.AFAuthSet();
            tmpForm.ShowDialog();
        }
    }
}
