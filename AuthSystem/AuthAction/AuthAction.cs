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
        private List<object> tmpAllObj = new List<object>(); //1级的所有Controls
        private List<object> tmpMenuStripObj = new List<object>(); //菜单项，不包含主名称
        private List<object> tmpStatusStripObj = new List<object>();//状态栏项
        private List<object> tmpToolStripObj = new List<object>();//工具栏

        /// <summary>
        /// 取窗体所有控件，不包含有子控件
        /// </summary>
        /// <param name="Ctl"></param>
        private void TraverControl(Control Ctl)
        {
            foreach (Control c in Ctl.Controls)
            {
                tmpAllObj.Add(c);
                if (c.Controls.Count == 0)
                {
                    continue;
                }
                else
                {
                    Control C = c;

                    TraverControl(C); //递归调用
                }
            }
        }
        /// <summary>
        /// 根据取到的所有控件，遍历包含的子控件
        /// </summary>
        /// <param name="ctl"></param>
        public void GetAllObj(Control ctl)
        {
            foreach (var x in tmpAllObj)
            {
                if (x.GetType() == typeof(MenuStrip))
                {
                    GetMenuStripObj(((MenuStrip)x).Items);
                }
                else if (x.GetType() == typeof(StatusStrip))
                {
                    GetStatusStripObj(((StatusStrip)x).Items);
                }
                else if (x.GetType() == typeof(ToolStrip))
                {
                    GetToolStripObj(((ToolStrip)x).Items);
                }
                else
                {
                    continue;
                }
            }

        }

        /// <summary>
        /// 取菜单的子控件
        /// </summary>
        /// <param name="ms"></param>
        private void GetMenuStripObj(ToolStripItemCollection tsic)
        {
            foreach (ToolStripItem x in tsic)
            {
                tmpMenuStripObj.Add(x);
                if (!x.IsOnDropDown)
                {
                    continue;
                }
                else
                {
                    GetMenuStripObj(((ToolStripMenuItem)x).DropDownItems);
                }
            }
        }
        private void GetStatusStripObj(ToolStripItemCollection tsic)
        {
            foreach (ToolStripItem x in tsic)
            {
                tmpStatusStripObj.Add(x);
                if (!x.IsOnDropDown)
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("error:Status");
                }
            }
        }
        private void GetToolStripObj(ToolStripItemCollection tsic)
        {
            foreach (ToolStripItem x in tsic)
            {
                tmpToolStripObj.Add(x);
                if (!x.IsOnDropDown)
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("error:Tool");
                }
            }
        }
        /// <summary>
        /// 遍历指定窗口的所有控件
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public List<object> MainGetObj(Control control)
        {
            List<object> tmpObj = new List<object>();
            tmpAllObj.Clear();
            TraverControl(control);
            GetAllObj(control);
            tmpObj.AddRange(tmpAllObj);
            tmpObj.AddRange(tmpMenuStripObj);
            tmpObj.AddRange(tmpStatusStripObj);
            tmpObj.AddRange(tmpToolStripObj);
            return tmpObj;
        }
        #endregion

        #region 9---窗口的权限处理
        public string RunAuthAction(Control con,string User_ID)
        {
            
            #region 0---公共变量
            string tmpStr="";//定义方法要返回的数据
            string tmpNameSpace = con.Controls.Owner.GetType().FullName; //当前con的路径
            DataTable tmpUserItems = ADAct.ReadUserItems(tmpNameSpace, User_ID);//本用户有权限的对象
            DataTable tmpUserItemsNo = ADAct.ReadUserItemsNo(tmpNameSpace);//不做权限管理的对象
            if (tmpUserItems.Rows.Count == 0)
            {
                tmpStr= "没有任何权限，无法打开窗口!";
                return tmpStr;
            }
            #endregion

            #region 2---控件权限处理
            List<object> tmpControls = MainGetObj(con);//窗口所有控件，不包括菜单
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
                if (LsItemsName.Contains(x.GetType().GetProperty("Name").GetValue(x,null).ToString()))
                {
                    x.GetType().GetProperty("Enabled").SetValue(x, true, null);
                }
                else
                {
                    x.GetType().GetProperty("Enabled").SetValue(x, false, null);
                }
            }
            foreach (var x in tmpControls)
            {
                if (LsItemsNoName.Contains(x.GetType().GetProperty("Name").GetValue(x, null).ToString()))
                {
                    x.GetType().GetProperty("Enabled").SetValue(x, true, null);
                }
            }

            //2-不用做权限处理的所有Items

            #endregion
            tmpStr = "true";
            return tmpStr;
        }
        #endregion
    }
}
