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
            this.SuspendLayout();
            // 
            // AFMainForm
            // 
            this.ClientSize = new System.Drawing.Size(1019, 560);
            this.DoubleBuffered = true;
            this.Name = "AFMainForm";
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
