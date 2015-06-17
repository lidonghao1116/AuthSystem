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
        #region 0-------定义公共变量
        #endregion
        #region 1-------初始化------
        public AFMainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitializeComponent() 
        {
        }
        #endregion

        #region 1-------检查本窗口所有对象权限
        public void ChechAuth(AuthModel.AMUser amu,out string MSG)
        {
            string tmpMSG = "";//返回的信息
            

            MSG = tmpMSG;
            
        }

        #endregion

        #region 2-------实现按权限加载菜单
        //-----------------------------------------------------------------------------
        /// <summary>
        /// 加载自动根据用户权限显示的菜单
        /// </summary>
        /// <param name="AML">用户AMLogin数据对象</param>
        /// <param name="MS">全部的菜单MenuStrip对象</param>
        /// 不完善，还要一个数据库连接对象
        /// <returns></returns>
        public bool AuthMenuShow(AuthModel.AMLogin AML, MenuStrip MS)
        {
            if (MS.Name != "MainMenu")  //检测主菜单名字
            {
                //return false;
                throw new Exception("权限菜单名必须为“MainMenu”");
            }
            else
            {
                this.Controls.RemoveByKey("MainMenu");
                this.Controls.Add(MS);
                foreach (ToolStripItem x in MS.Items) //所有菜单隐藏
                {
                    x.Visible = false;
                    if (x.GetType().Name == "ToolStripMenuItem")
                    {
                        ToolStripMenuItem tsmi = x as ToolStripMenuItem;
                        foreach (ToolStripItem y in tsmi.DropDownItems)
                        {
                            y.Visible = false;
                        }
                    }
                    else if (x.GetType().Name=="ToolStripComboBox")
                    {
                        ToolStripComboBox tscb = x as ToolStripComboBox;
                        tscb.Items.Clear();
                    }
                    else if (x.GetType().Name == "ToolStripTextBox")
                    {
                        
                    }
                }
                //根据AML显示有权限的菜单
                return true;
            }
        }
        #endregion
    }
}
