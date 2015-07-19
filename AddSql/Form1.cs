using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AuthSystem;

namespace AddSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //SqlAction.globalConnectionString = @"Password=alwcel;Persist Security Info=True;User ID=sa;Initial Catalog=NewAuth;Data Source=ALWCEL-PC";
        }

        private void bt_GetConn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlAction.GetServerTime();
                DebugMsg.Add("alwcel");
                string a="";
                a.GetType().GetProperty("a").GetValue(a, null).ToString();
            }
            catch (Exception x)
            {
                DebugMsg.Add(x);
            }
        }
    }
}
