using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AuthSystem.AuthModel;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 权限数据的数据库操作类
    /// </summary>
    public class ADAuthOpera:ADSqlOpera
    {
        #region 0-------初始化与公共变量数据
        public ADAuthOpera()
        {
            //Init
        }
        private static AMSqlConf amsc=null;
        public static AMSqlConf AMSqlConfig
        {
            get { return amsc; }
            set { amsc = value; }
        }
        #endregion

        #region 1-------从数据库取用户数据
        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取所有用户数据
        /// </summary>
        /// <returns></returns>
        public static AMUsers GetAuthUsers()
        {
            if(amsc==null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMUsers AllAmus = new AMUsers();
                
                List<AMUser> tmpAmus = new List<AMUser>();
                //tmpAmus.ListAMUsers.Clear();
                string sql = @"select * from AuthUsers";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    AMUser tmpAmu = new AMUser();
                    //再赋值
                    tmpAmu.User_ID = tmpSDR["User_ID"].ToString();
                    tmpAmu.User_Name = tmpSDR["User_Name"].ToString();
                    tmpAmu.User_Text = tmpSDR["User_Text"].ToString();
                    tmpAmu.User_Pass = tmpSDR["User_Pass"].ToString();
                    tmpAmu.User_Tel = tmpSDR["User_Tel"].ToString();
                    tmpAmu.User_QQ = tmpSDR["User_QQ"].ToString();
                    tmpAmu.User_Email = tmpSDR["User_Email"].ToString();
                    tmpAmu.User_Status = (bool)tmpSDR["User_Status"];
                    tmpAmu.User_Group = tmpSDR["User_Group"].ToString();
                    tmpAmu.User_CangKu = tmpSDR["User_CangKu"].ToString();
                    tmpAmu.User_BeiZhu = tmpSDR["User_BeiZhu"].ToString();
                    //添加到列表
                    tmpAmus.Add(tmpAmu);
                }
                tmpSDR.Close();
                AllAmus.ListAMUsers = tmpAmus;
                return AllAmus;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取单个用户的数据
        /// </summary>
        /// <param name="UserName">要取的用户的登陆名字</param>
        /// <returns>返回一个AMUser对象</returns>
        public static AMUser GetAuthUser(string UserName)
        {
            if (amsc == null) //判断配置对象是否为空
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMUser tmpAmu = new AMUser();
                string sql = @"select * from AuthUsers where User_Name='" + UserName + "'";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    if (tmpSDR["User_Name"].ToString() == UserName)
                    {
                        tmpAmu.User_ID = tmpSDR["User_ID"].ToString();
                        tmpAmu.User_Name = tmpSDR["User_Name"].ToString();
                        tmpAmu.User_Text = tmpSDR["User_Text"].ToString();
                        tmpAmu.User_Pass = tmpSDR["User_Pass"].ToString();
                        tmpAmu.User_Tel = tmpSDR["User_Tel"].ToString();
                        tmpAmu.User_QQ = tmpSDR["User_QQ"].ToString();
                        tmpAmu.User_Email = tmpSDR["User_Email"].ToString();
                        tmpAmu.User_Status = (bool)tmpSDR["User_Status"];
                        tmpAmu.User_Group = tmpSDR["User_Group"].ToString();
                        tmpAmu.User_CangKu = tmpSDR["User_CangKu"].ToString();
                        tmpAmu.User_BeiZhu = tmpSDR["User_BeiZhu"].ToString();
                    }
                }
                tmpSDR.Close();
                return tmpAmu;
                
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取用户的角色名
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public static string GetAuthUser_GroupName(AMUser amu)
        {
            if (amsc == null) //判断配置对象是否为空
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                string UserName = amu.User_Name;
                string tmpGroupName = "";
                string sql = @"select User_ID,User_Name,Group_Name from AuthUsers,AuthGroups where AuthUsers.Group_ID=AuthGroups.Group_ID and User_Name='" + UserName + "'";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    tmpGroupName = tmpSDR["Group_Name"].ToString();
                }
                tmpSDR.Close();
                return tmpGroupName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取用名的角色ID
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public static string GetAuthUser_GroupID(AMUser amu)
        {
            if (amsc == null) //判断配置对象是否为空
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                string UserName = amu.User_Name;
                string tmpGroupID = "";
                string sql = @"select User_ID,User_Name,Group_ID,Group_Name from AuthUsers,AuthGroups where AuthUsers.Group_ID=AuthGroups.Group_ID and User_Name='" + UserName + "'";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    tmpGroupID = tmpSDR["Group_ID"].ToString();
                }
                tmpSDR.Close();
                return tmpGroupID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region 1-1------添加用户数据到数据库
        //---------------------------------------------------------------------------------------------------------
        public static bool AddAuthUser(AMUser amu)
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                string DataStr = amu.User_ID + ",'" + amu.User_Name + "','" + amu.User_Text + "','" + amu.User_Pass + "','" + amu.User_Tel + "','" + amu.User_QQ + "','" +
                    amu.User_Email + "'," + Bool2Int(amu.User_Status)+ ",'" + amu.User_Group + "','" + amu.User_CangKu + "','" + amu.User_BeiZhu+"'";
                string sql = @"insert into AuthUsers values("+DataStr+")";
                //string sql = @"insert into AuthUsers values(1,abcd)";
                if (ExcSqlCommand(sql, amsc) == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion

        #region 2-------从数据库取用户的角色(组)数据
        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 根据用户数据，取用户的角色对象
        /// </summary>
        /// <param name="amu">用户数据对象</param>
        /// <returns>返回AMGroup对象</returns>
        public static AMGroup GetAuthGroup(AMUser amu)
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMGroup tmpAmg = new AMGroup();
                string tmpGroupID = amu.User_Group;
                string sql = @"select * from AuthGroups where Group_ID='" + tmpGroupID + "'";
                SqlDataReader SDR = GetDataReader(sql, amsc);
                while (SDR.Read())
                {
                    tmpAmg.Group_ID = SDR["Group_ID"].ToString();
                    tmpAmg.Group_Name = SDR["Group_Name"].ToString();
                    tmpAmg.Group_Status = (bool)SDR["Group_Status"];
                    tmpAmg.Group_BeiZhu = SDR["Group_BeiZhu"].ToString();
                    tmpAmg.Group_Rule_ID = SDR["Group_Rule_ID"].ToString();
                    tmpAmg.Group_CangKu_ID = SDR["Group_CangKu_ID"].ToString();
                    tmpAmg.Group_Menu_ID = SDR["Group_Menu_ID"].ToString();
                }
                SDR.Close();
                return tmpAmg;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取所有的角色组
        /// </summary>
        /// <returns>返回AMGroups对象</returns>
        public static AMGroups GetAuthGroups()
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                
                AMGroups tmpAllAmgs = new AMGroups();
                List<AMGroup> tmpAmgs = new List<AMGroup>();
                string sql = @"select * from AuthGroups";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    AMGroup tmpAmg = new AMGroup();
                    tmpAmg.Group_ID = tmpSDR["Group_ID"].ToString();
                    tmpAmg.Group_Name = tmpSDR["Group_Name"].ToString();
                    tmpAmg.Group_Status = (bool)tmpSDR["Group_Status"];
                    tmpAmg.Group_BeiZhu = tmpSDR["Group_BeiZhu"].ToString();
                    tmpAmg.Group_Rule_ID = tmpSDR["Group_Rule_ID"].ToString();
                    tmpAmg.Group_CangKu_ID = tmpSDR["Group_CangKu_ID"].ToString();
                    tmpAmg.Group_Menu_ID = tmpSDR["Group_Menu_ID"].ToString();
                    tmpAmgs.Add(tmpAmg);
                }
                tmpSDR.Close();
                tmpAllAmgs.AllGroups = tmpAmgs;
                return tmpAllAmgs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region 3-------从数据库取用户的菜单数据
        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取所有的菜单项
        /// </summary>
        /// <returns>AMMenus</returns>
        public static AMMenus GetAuthMenus()
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMMenu amm = new AMMenu();
                AMMenus amms = new AMMenus();
                string sql = @"select * from AuthMenus";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    amm.Menu_ID = "";
                    amm.Menu_Name = "";
                    amm.Menu_UpItemID = "";
                    amm.Menu_BeiZhu = "";
                    amm.Menu_ID = tmpSDR["Menu_ID"].ToString();
                    amm.Menu_Name = tmpSDR["Menu_Name"].ToString();
                    amm.Menu_UpItemID = tmpSDR["Menu_UpItemID"].ToString();
                    amm.Menu_BeiZhu = tmpSDR["Menu_BeiZhu"].ToString();
                    amms.Add(amm);
                }
                tmpSDR.Close();
                return amms;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 返回指定角色的菜单项
        /// </summary>
        /// <param name="amg">角色对象</param>
        /// <returns>返回List String对象</returns>
        public static List<string> GetAuthGroupMenusByList(AMGroup amg)
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                List<string> tmpMenus = new List<string>();
                string tmpGroupID=amg.Group_ID;
                string sql = @"select * from AuthGroupsMenus where Group_ID='" + tmpGroupID + "'";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    tmpMenus.Add(tmpSDR["Menu_Name"].ToString());
                }
                tmpSDR.Close();
                return tmpMenus;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion

        #region 4-------从数据库取规则
        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 返回角色的权限ID列表
        /// </summary>
        /// <param name="amg">角色对象</param>
        /// <returns></returns>
        public static AMRulesID_ForList GetAuthRules_ByGroup(AMGroup amg)
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMRulesID_ForList amgrs = new AMRulesID_ForList();
                string tmpGroupID = amg.Group_ID;
                string sql = @"select * from AuthGroupsRule where GroupsRule_ID='" + tmpGroupID + "'";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    amgrs.Add(tmpSDR["Rule_ID"].ToString());
                }
                tmpSDR.Close();
                return amgrs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取所有的规则Rules
        /// </summary>
        /// <returns>返回AMRules对象</returns>
        public static AMRules GetAuthRules()
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMRules AllAMRules = new AMRules();
                List<AMRule> tmpRules = new List<AMRule>();
                string sql = @"select * from AuthRules";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    AMRule tmpAMRule = new AMRule();
                    tmpAMRule.Rule_ID = tmpSDR["Rule_ID"].ToString();
                    tmpAMRule.Rule_Name = tmpSDR["Rule_Name"].ToString();
                    tmpAMRule.Rule_Item_ID = tmpSDR["Rule_Item_ID"].ToString();
                    tmpAMRule.Rule_BeiZhu = tmpSDR["Rule_BeiZhu"].ToString();
                    tmpRules.Add(tmpAMRule);
                }
                tmpSDR.Close();
                AllAMRules.AllAMRules = tmpRules;
                return AllAMRules;
            }
            catch(Exception)
            {
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取指定组（角色）的权限规则
        /// </summary>
        /// <param name="amg">组（角色）</param>
        /// <returns>返回AMRules对象</returns>
        public static AMRules GetAuthRule_ByGroup(AMGroup amg)
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMRules GroupAMRules = new AMRules();
                List<AMRule> tmpGroupAMRules = new List<AMRule>();
                string strGroupID = amg.Group_ID;
                string sql = @"select * from AuthGroupsRules where Group_ID='" + strGroupID + "'";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    AMRule tmpAMRule = new AMRule();
                    tmpAMRule.Rule_ID = tmpSDR["Rule_ID"].ToString();
                    tmpAMRule.Rule_Name = tmpSDR["Rule_Name"].ToString();
                    tmpAMRule.Rule_Item_ID = tmpSDR["Rule_Item_ID"].ToString();
                    tmpAMRule.Rule_BeiZhu = tmpSDR["Rule_BeiZhu"].ToString();
                    tmpGroupAMRules.Add(tmpAMRule);
                }
                tmpSDR.Close();
                GroupAMRules.AllAMRules = tmpGroupAMRules;
                return GroupAMRules;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion

        #region 5-------从数据库取对象（Item)
        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取不用做权限处理的Items的名字
        /// </summary>
        /// <returns>返回List String列表</returns>
        public static List<string> GetAuthNoItems_Name_ForList()
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                List<string> tmpItemsNo = new List<string>();
                string sql = @"select * from AuthItemsNo";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    tmpItemsNo.Add(tmpSDR["Item_Name"].ToString());
                }
                tmpSDR.Close();
                return tmpItemsNo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取所有的Items对象
        /// </summary>
        /// <returns>返回AMItems</returns>
        public static AMItems GetAuthItems()
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                AMItems amis = new AMItems();
                AMItem ami = new AMItem();
                string sql = @"select * from AuthGroupsItems";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    ami.Item_ID = "";
                    ami.Item_Name = "";
                    ami.Item_NameSpace = "";
                    ami.Item_BeiZhu = "";
                    ami.Item_ID = tmpSDR["Item_ID"].ToString();
                    ami.Item_Name = tmpSDR["Item_Name"].ToString();
                    ami.Item_NameSpace = tmpSDR["Item_NameSpace"].ToString();
                    ami.Item_BeiZhu = tmpSDR["Item_BeiZhu"].ToString();
                    amis.Add(ami);
                }
                tmpSDR.Close();
                return amis;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取指定角色的所有ItemName的列表
        /// </summary>
        /// <param name="amg">角色对象AMGroup</param>
        /// <returns>List(string)</returns>
        public static List<string> GetAuthItems_Name_ForList(AMGroup amg)
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                List<string> tmpItems = new List<string>();
                string tmpGroupID = amg.Group_ID;
                string sql = @"select * from AuthGroupsItems where Group_ID='" + tmpGroupID + "'";
                SqlDataReader tmpSDR = GetDataReader(sql, amsc);
                while (tmpSDR.Read())
                {
                    tmpItems.Add(tmpSDR["Item_Name"].ToString());
                }
                tmpSDR.Close();

                return tmpItems;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 9-------窗口所有对象权限管理
        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 返回当前用户的窗口的所有控件对象，只遍历三层对象容器
        /// </summary>
        /// <param name="con">当前窗口的controls</param>
        /// <returns>返回object对象list</returns>
        public static List<object> GetWindowsContrul(System.Windows.Forms.Control.ControlCollection con)
        {
            try
            {
                List<object> tmpObject = new List<object>();
                for (int x = 0; x < con.Count; x++)
                {
                    if (con[x].GetType()==typeof(System.Windows.Forms.MenuStrip))  //去掉菜单获取
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
            catch(Exception)
            {
                throw;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 返回当前窗口的所有菜单项，只遍历三层菜单！
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
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
                    if (((System.Windows.Forms.ToolStripMenuItem)tmpMenu.Items[x]).DropDownItems.Count>0)
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

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 根据用户的权限，设置窗口内菜单与控件
        /// </summary>
        /// <param name="amu">用户对象</param>
        /// <param name="con">窗口的所有控件</param>
        /// <returns>True False</returns>
        public static bool SetWindowsAuth(AMUser amu, System.Windows.Forms.Control.ControlCollection con)
        {
            //取用户的角色对象---------------------------------------------------------------------------------
            AMGroup amg = GetAuthGroup(amu);
            #region 1-------菜单处理
            //取用户的角色的权限的菜单列表---------------------------------------------------------------------------------
            List<string> tmpGroupMenus = GetAuthGroupMenusByList(amg);

            //取当前窗口的所有菜单列表
            List<object> tmpWinMenus = GetWindowsMenu(con);
            //有权限的菜单enable为TRUE，没权限的为False；
            //System.Windows.Forms.MessageBox.Show(tmpGroupMenus.Count.ToString() + "|||" + tmpWinMenus.Count().ToString());
            foreach (object x in tmpWinMenus)
            {
                if (tmpGroupMenus.Contains(((System.Windows.Forms.ToolStripMenuItem)x).Name))
                {
                    ((System.Windows.Forms.ToolStripMenuItem)x).Visible = true;
                    ((System.Windows.Forms.ToolStripMenuItem)x).Enabled = true;
                }
                else
                {
                    ((System.Windows.Forms.ToolStripMenuItem)x).Enabled = false;
                    ((System.Windows.Forms.ToolStripMenuItem)x).Visible = false;
                }
            }
            #endregion

            #region 2-------控件处理
            //取用户的角色的权限的对象列表-
            List<string> tmpGroupItems = GetAuthItems_Name_ForList(amg);

            //取不用做权限处理的控件列表
            List<string> tmpGroupItemsNo = GetAuthNoItems_Name_ForList();

            //取当前窗口的所有对象列表
            List<object> tmpWinItems = GetWindowsContrul(con);
            //把有权限的对象enable属性设置为true;其它对象设置为False；（对比一个表，不关权限的Item表）
            foreach (object x in tmpWinItems)
            {
                if (!tmpGroupItemsNo.Contains(((System.Windows.Forms.Control)x).Name))
                {
                    if (tmpGroupItems.Contains(((System.Windows.Forms.Control)x).Name))
                    {
                        ((System.Windows.Forms.Control)x).Enabled = true;
                    }
                    else
                    {
                        ((System.Windows.Forms.Control)x).Enabled = false;
                    }
                }
            }
            #endregion

            return true;
        }
        #endregion


    }
}
