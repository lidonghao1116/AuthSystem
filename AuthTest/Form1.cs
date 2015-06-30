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
        private DataTable tmpDt;
        
        private void button1_Click(object sender, EventArgs e)
        {
            tmpDt = AP2SOpera.ReadPool(AuthSystem.AuthPool.APPoolType.AMUsers);
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

        private void button6_Click(object sender, EventArgs e)
        {
            int currIndex = dataGridView1.SelectedRows[0].Index;
            dataGridView1.Rows.RemoveAt(currIndex);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<string> str1 = AuthSystem.AuthPool2Soft.AP2SOpera.ReadPool_Ru2It("5");
            foreach (string x in str1)
            {
                MessageBox.Show(x);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthForm.AFAuthSetItemNo afasin = new AuthSystem.AuthForm.AFAuthSetItemNo();
            afasin.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthForm.AFAuthSet afas = new AuthSystem.AuthForm.AFAuthSet();
            afas.ShowDialog();
        }

    }
}
