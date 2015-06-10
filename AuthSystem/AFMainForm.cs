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
        #region 1-------初始化------
        public AFMainForm()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.panel_zhong = new System.Windows.Forms.Panel();
            this.panel_xia = new System.Windows.Forms.Panel();
            this.panel_shang = new System.Windows.Forms.Panel();
            this.bt_Close = new System.Windows.Forms.Button();
            this.panel_shang.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_zhong
            // 
            this.panel_zhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_zhong.Location = new System.Drawing.Point(0, 40);
            this.panel_zhong.Name = "panel_zhong";
            this.panel_zhong.Size = new System.Drawing.Size(1019, 520);
            this.panel_zhong.TabIndex = 1;
            // 
            // panel_xia
            // 
            this.panel_xia.BackgroundImage = global::AuthSystem.Properties.Resources.bg_0068;
            this.panel_xia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_xia.Location = new System.Drawing.Point(0, 539);
            this.panel_xia.Name = "panel_xia";
            this.panel_xia.Size = new System.Drawing.Size(1019, 21);
            this.panel_xia.TabIndex = 2;
            // 
            // panel_shang
            // 
            this.panel_shang.BackgroundImage = global::AuthSystem.Properties.Resources.bg_0068;
            this.panel_shang.Controls.Add(this.bt_Close);
            this.panel_shang.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_shang.Location = new System.Drawing.Point(0, 0);
            this.panel_shang.Name = "panel_shang";
            this.panel_shang.Size = new System.Drawing.Size(1019, 40);
            this.panel_shang.TabIndex = 0;
            this.panel_shang.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AFMainForm_DBClick);
            this.panel_shang.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AFMainForm_MouseDown);
            // 
            // bt_Close
            // 
            this.bt_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Close.ForeColor = System.Drawing.Color.Red;
            this.bt_Close.Location = new System.Drawing.Point(999, 0);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(20, 20);
            this.bt_Close.TabIndex = 1;
            this.bt_Close.TabStop = false;
            this.bt_Close.Text = "X";
            this.bt_Close.UseVisualStyleBackColor = false;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // AFMainForm
            // 
            this.ClientSize = new System.Drawing.Size(1019, 560);
            this.Controls.Add(this.panel_xia);
            this.Controls.Add(this.panel_zhong);
            this.Controls.Add(this.panel_shang);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AFMainForm";
            this.panel_shang.ResumeLayout(false);
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
        private Panel panel_shang;
        private Panel panel_zhong;
        private Panel panel_xia;
        private Button bt_Close;
        public const int HTCAPTION = 0x0002;
        #endregion

        private void AFMainForm_MouseDown(object sender, MouseEventArgs e)  //按住移动窗口
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }


        private void AFMainForm_DBClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
