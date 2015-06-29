using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AuthSystem.AuthPool2Soft;


namespace AuthTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //AuthSystem.AuthPool2Db.AP2DOpera.GetPool();//初始化所有数据池！
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tmpDt = AP2SOpera.ReadPool(AuthSystem.AuthPool.APPoolType.AMUsers);
            dataGridView1.DataSource = tmpDt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AP2SOpera.SavePool((DataTable)dataGridView1.DataSource, AuthSystem.AuthPool.APPoolType.AMUsers);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthPool2Db.AP2DOpera.GetPool();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthPool2Db.AP2DOpera.UpdatePool(AuthSystem.AuthPool.APPoolType.AMUsers);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthForm.AFAuthRuleBinding afarb = new AuthSystem.AuthForm.AFAuthRuleBinding();
            afarb.ShowDialog();
        }

    }
}
