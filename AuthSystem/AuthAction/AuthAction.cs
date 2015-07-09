using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace AuthSystem
{
    /// <summary>
    /// 界面的权限设置类
    /// (一定要保证Items的正确)
    /// </summary>
    public class AuthAction
    {
        public AuthAction()
        {
            //Init
        }
        #region 0---取窗口数据
        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 返回当前用户的窗口的所有控件对象;
        /// 
        /// (只遍历三层对象容器)
        /// (不会处理菜单项，菜单用另一个方法进行处理)
        /// </summary>
        /// <param name="con">当前窗口的controls</param>
        /// <returns>List.Object</returns>
        public static List<object> GetWindowsContrul(System.Windows.Forms.Control.ControlCollection con)
        {
            try
            {
                List<object> tmpObject = new List<object>();
                for (int x = 0; x < con.Count; x++)
                {
                    if (con[x].GetType() == typeof(System.Windows.Forms.MenuStrip))  //去掉菜单获取
                    {
                        continue;
                    }
                    if (con[x].Controls.Count > 0)
                    {
                        tmpObject.Add(con[x]);
                        for (int y = 0; y < con[x].Controls.Count; y++)
                        {
                            if (con[x].Controls[y].Controls.Count > 0)
                            {
                                tmpObject.Add(con[x].Controls[y]);
                                for (int z = 0; z < con[x].Controls[y].Controls.Count; z++)
                                {
                                    tmpObject.Add(con[x].Controls[y].Controls[z]);
                                }
                            }
                            else
                            {
                                tmpObject.Add(con[x].Controls[y]);
                            }
                        }
                    }
                    else
                    {
                        tmpObject.Add(con[x]);
                    }
                }
                return tmpObject;
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
        public static List<object> GetWindowsMenu(System.Windows.Forms.Control.ControlCollection con)
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

        #endregion

        #region 9---窗口的权限处理
        public static string RunAuthAction(System.Windows.Forms.Control.ControlCollection con)
        {

                #region 0---公共变量
                string tmpStr = null;//定义方法要返回的数据
                DataTable tmpGroupItems;//定义当前角色的所有对象表
                System.Windows.Forms.MessageBox.Show("a");
                //1-取当前con所在的窗口的namespace + "." + FormClassName;
                string[] tmpGroupIDs = AuthPool.APPoolGlobal.GlobalAMUser.User_Group.Split(','); //当前用户的角色
                string tmpNameSpace = con.Owner.GetType().FullName;
                tmpGroupItems = AuthPool2Soft.AP2SOpera.GetGroupItems(tmpGroupIDs, tmpNameSpace);
                System.Windows.Forms.MessageBox.Show(tmpGroupItems.Rows.Count.ToString()+",");

                #endregion

                #region 2---菜单权限处理
                #endregion

                #region 3---控件权限处理
                //1-当前用户对应的所有Items
                

                //2-不用做权限处理的所有Items

                #endregion
                return tmpStr;

            
        }
        #endregion
    }
}
