using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace AuthTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string sql = @"select * from AuthGr2Ru";
        SqlDataAdapter sda = AuthSystem.AuthPool2Db.AP2DOpera.GetDataAdapter(sql);
        private void button1_Click(object sender, EventArgs e)
        {
            
            /*
            SqlDataReader sdr = AuthSystem.AuthPool2Db.AP2DOpera.GetDataReader(sql);
            DataTable dt = new DataTable("AuthUsers1");
            dt.Load(sdr);
            dataSet1.Tables.Add(dt);
            sdr.Close();
            dataGridView1.DataSource = dataSet1.Tables["AuthUsers1"];
            MessageBox.Show(dataSet1.Tables.Count.ToString());
            */
            
            sda.Fill(dataSet1, "AuthGr2Ru");

            dataGridView1.DataSource = dataSet1.Tables["AuthGr2Ru"];

            //SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            //sda.Update(dataSet1.GetChanges());
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcomm = AuthSystem.AuthPool2Db.AP2DOpera.GetComm();
            sqlcomm.CommandText = @"insert into AuthUsers values(@Group_Rule_ID,@Rule_ID)";
            sqlcomm.Parameters.Add("@Group_Rule_ID", "Group_Rule_ID");
            sqlcomm.Parameters.Add("@Rule_ID", "Rule_ID");
            sda.InsertCommand = sqlcomm;
            sda.Update(dataSet1.Tables[0].GetChanges());
        }

    }
}
