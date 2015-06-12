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
    public partial class FormMain : AuthSystem.AuthForm.AFMainForm
    {
        public FormMain()
        {
            InitializeComponent();
            AuthSystem.AuthModel.AMLogin aml = new AuthSystem.AuthModel.AMLogin();
            MenuStrip ms = new MenuStrip();
            ms.Name = "MainMenu";
            ms.Items.Add("文件");
            ms.Items.Add("其它");
            ToolStripComboBox cb = new ToolStripComboBox();
            ms.Items.Add(cb);
            AuthMenuShow(aml, ms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthModel.AMLogin aml = new AuthSystem.AuthModel.AMLogin();
            MenuStrip ms = new MenuStrip();
            ms.Name = "MainMenu";
            ms.Items.Add("编辑");
            AuthMenuShow(aml, ms);
        }
    }
}
