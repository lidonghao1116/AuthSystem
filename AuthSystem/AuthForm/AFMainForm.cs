using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AuthSystem.AuthForm;
using System.Runtime.InteropServices;

namespace AuthSystem.AuthForm
{
    /// <summary>
    /// 带有权限认证的WinForm ，其它窗口都要从这个窗口继承
    /// </summary>
    public class AFMainForm:AFBase
    {
        private MenuStrip MainMenu;
        #region 1-------初始化------
        public AFMainForm()
        {
            InitializeComponent();
        }
        public AFMainForm(AuthModel.AMLogin aml)
        {
            InitializeComponent();  //初始化界面
            InitMenu(aml);          //初始化菜单
        }
        private void InitializeComponent() //初始化界面
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1019, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // AFMainForm
            // 
            this.ClientSize = new System.Drawing.Size(1019, 560);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "AFMainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void InitMenu(AuthModel.AMLogin aml) //初始化菜单
        {
            
        }
        #endregion

        #region END-------关闭程序
        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
