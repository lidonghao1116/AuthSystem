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
    public class AFLogin:AFBase
    {
        #region 1-------初始化------------
        public AFLogin()
        {
            InitializeComponent();
        }

        private Button bt_Close;
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.bt_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_Close
            // 
            this.bt_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Close.ForeColor = System.Drawing.Color.Red;
            this.bt_Close.Location = new System.Drawing.Point(0, 0);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(20, 20);
            this.bt_Close.TabIndex = 0;
            this.bt_Close.TabStop = false;
            this.bt_Close.Text = "X";
            this.bt_Close.UseVisualStyleBackColor = false;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // AFLogin
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bt_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AFLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AFLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            this.ResumeLayout(false);

        }
        #endregion
        #region 2-------本程序中用到的API函数
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();  //用来释放被当前线程中某个窗口捕获的光标

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwdn, int wMsg, int mParam, int lParam);//向指定的窗体发送Windows消息
        #endregion
        #region 3-------本程序中需要声明的变量
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        #endregion
        #region 4-------按鼠标左键可以移动窗口
        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

        private void AFLogin_Load(object sender, EventArgs e)   //加载时移动关闭按钮
        {
            this.bt_Close.Location = new System.Drawing.Point(this.Size.Width - 20, 0);
        }

        private void bt_Close_Click(object sender, EventArgs e)//点击关闭，退出程序
        {
            Application.Exit();
        }
    }
}
