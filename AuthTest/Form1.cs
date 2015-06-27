using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AuthTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthPool2Db.AP2DOpera.GetPool(AuthSystem.AuthPool.APPoolType.AMUsers);
            List<AuthSystem.AuthModel.AMUser> tmpamus = new List<AuthSystem.AuthModel.AMUser>();
            tmpamus = AuthSystem.AuthPool.APDbPool.poolAMUsers;
            foreach (var x in tmpamus)
            {
                MessageBox.Show(x.User_Name);
            }
        }
    }
}
