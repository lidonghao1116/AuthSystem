using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Windows.Forms;
using AuthSystem.AuthData;

namespace AuthSystem
{
    /// <summary>
    /// 界面的权限设置类
    /// (一定要保证Items的正确)
    /// </summary>
    public class AuthAction
    {
        #region 0---定义公共变量
        private ADAction ADAct = new ADAction();
        #endregion
        public AuthAction()
        {
            ADAct.ConnString = AuthPool.APPoolGlobal.GlobalAMSystemConfig.ConnectionString;
            ADAct.ReadToPool(AuthPool.PoolType.ItemsNo);
        }
        #region 0---取窗口数据
        private List<object> tmpObj = new List<object>();
        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 返回当前用户的窗口的所有控件对象;
        /// 
        /// (只遍历三层对象容器)
        /// (不会处理菜单项，菜单用另一个方法进行处理)
        /// </summary>
        /// <param name="con">当前窗口的controls</param>
        /// <returns>List.Object</returns>
        public List<object> GetWindowsControl(System.Windows.Forms.Control.ControlCollection con)
        {
            try
            {
                tmpObj.Clear();
                TraverControl(con);
                return tmpObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 返回当前窗口的所有菜单项;
        /// (只遍历三层菜单！)
        /// </summary>
        /// <param name="con">当前窗口的controls</param>
        /// <returns>List.Object</returns>
        public List<object> GetWindowsMenu(Control.ControlCollection con)
        {
            try
            {
                List<object> tmpLobj = new List<object>();
                System.Windows.Forms.MenuStrip tmpMenu = new System.Windows.Forms.MenuStrip();
                foreach (object x in con) //取MenuStrip对象
                {
                    if (x.GetType() == typeof(System.Windows.Forms.MenuStrip))
                    {
                        tmpMenu = (System.Windows.Forms.MenuStrip)x;
                        break;
                    }
                }
                for (int x = 0; x < tmpMenu.Items.Count; x++)
                {
                    tmpLobj.Add(tmpMenu.Items[x]);
                    if (((System.Windows.Forms.ToolStripMenuItem)tmpMenu.Items[x]).DropDownItems.Count > 0)
                    {
                        for (int y = 0; y < ((System.Windows.Forms.ToolStripMenuItem)tmpMenu.Items[x]).DropDownItems.Count; y++)
                        {
                            tmpLobj.Add(((System.Windows.Forms.ToolStripMenuItem)tmpMenu.Items[x]).DropDownItems[y]);
                            if (((System.Windows.Forms.ToolStripMenuItem)(((System.Windows.Forms.ToolStripMenuItem)tmpMenu.Items[x]).DropDownItems[y])).DropDownItems.Count > 0)
                            {
                                for (int z = 0; z < ((System.Windows.Forms.ToolStripMenuItem)(((System.Windows.Forms.ToolStripMenuItem)tmpMenu.Items[x]).DropDownItems[y])).DropDownItems.Count; z++)
                                {
                                    tmpLobj.Add(((System.Windows.Forms.ToolStripMenuItem)(((System.Windows.Forms.ToolStripMenuItem)tmpMenu.Items[x]).DropDownItems[y])).DropDownItems[z]);
                                }
                            }
                        }
                    }
                }
                return tmpLobj;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void GetFormObject(Control.ControlCollection con,out List<object> FormControls,out List<object> FormMenus)
        {
            try
            {
                List<object> tmpCons = new List<object>();
                List<object> tmpMenus = new List<object>();
                FormControls = tmpCons;
                FormMenus = tmpMenus;
                Assembly ass = con.GetType().Assembly;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void TraverControl(Control.ControlCollection Con)
        {
            foreach (Control c in Con)
            {

                tmpObj.Add("\n" + "  " + c.Name + "  " + "\n");
                //用于显示窗体中包含的所有的控件名，首先显示的是最外层的控件

                if (c.Controls.Count == 0)
                {
                    continue;
                }
                else
                {
                    Control.ControlCollection C = c.Controls;

                    TraverControl(C); //递归调用
                }
            }
        }
        #endregion

        #region 9---窗口的权限处理
        public string RunAuthAction(Control.ControlCollection con,string User_ID)
        {
            
            #region 0---公共变量
            string tmpStr="";//定义方法要返回的数据
            string tmpNameSpace = con.Owner.GetType().FullName; //当前con的路径
            DataTable tmpUserItems = ADAct.ReadUserItems(tmpNameSpace, User_ID);//本用户有权限的对象
            DataTable tmpUserItemsNo = ADAct.ReadUserItemsNo(tmpNameSpace);//不做权限管理的对象
            if (tmpUserItems.Rows.Count == 0)
            {
                tmpStr= "没有任何权限，无法打开窗口!";
                return tmpStr;
            }
            #endregion

            #region 2---控件权限处理
            List<object> tmpControls = GetWindowsControl(con);//窗口所有控件，不包括菜单
            //取ItemsName列表
            List<string> LsItemsName = new List<string>();
            foreach (DataRow x in tmpUserItems.AsEnumerable())
            {
                LsItemsName.Add(x["Item_Name"].ToString());
            }

            List<string> LsItemsNoName=new List<string>();
            foreach (DataRow x in tmpUserItemsNo.AsEnumerable())
            {
                LsItemsNoName.Add(x["Item_Name"].ToString());
            }
            foreach (var x in tmpControls)
            {
                if (LsItemsName.Contains(((System.Windows.Forms.Control)x).Name))
                {
                    ((System.Windows.Forms.Control)x).Enabled = true;
                }
                else
                {
                    ((System.Windows.Forms.Control)x).Enabled = false;
                }
            }
            foreach (var x in tmpControls)
            {
                if (LsItemsNoName.Contains(((System.Windows.Forms.Control)x).Name))
                {
                    ((System.Windows.Forms.Control)x).Enabled = true;
                }
            }

            //2-不用做权限处理的所有Items

            #endregion

            #region 2---菜单权限处理
            #endregion
            return tmpStr;
        }
        #endregion
    }
}
