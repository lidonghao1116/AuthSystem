using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthForm
{
    /// <summary>
    /// 用户与角色权限管理模块
    /// </summary>
    public class AFAuthSet:AFBase
    {
        public AFAuthSet()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AFAuthSet
            // 
            this.ClientSize = new System.Drawing.Size(1132, 686);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFAuthSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "权限管理";
            this.ResumeLayout(false);

        }
    }
}
