using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AuthSystem.AuthModel;

namespace AuthSystem.AuthDao
{
    /// <summary>
    /// 权限系统数据的数据库操作类
    /// </summary>
    public class ADAuthOpera:ADDbBase
    {

        #region 0-------初始化与公共变量数据
        public ADAuthOpera()
        {
            //Init
        }

        //设置数据库的配置对象
        private static AMSqlConf amsc=GetSqlConf();

        #endregion

        
        #region 1-------从数据库取用户数据
        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库取单个用户的数据
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>AMUser</returns>
        public static AMUser GetAuthUser(string UserName)
        {
            try
            {
                AMUser tmpAmu = new AMUser();
                string sql = @"select * from AuthUsers where User_Name='" + UserName + "'";
                SqlDataReader tmpSDR = GetDataReader(sql);
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
        /// 取所有用户数据
        /// </summary>
        /// <returns></returns>
        public static List<AMUser> GetAuthUsers()
        {
            try
            {
                List<AMUser> tmpAmus = new List<AMUser>();
                string sql = @"select * from AuthUsers";
                SqlDataReader tmpSDR = GetDataReader(sql);
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
                return tmpAmus;
            }
            catch (Exception e)
            {
                throw e;
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
                if (ADSqlOpera.ExcSqlCommand(sql) == -1)
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
            try
            {
                AMGroup tmpAmg = new AMGroup();
                string tmpGroupID = amu.User_Group;
                string sql = @"select * from AuthGroups where Group_ID='" + tmpGroupID + "'";
                SqlDataReader SDR = GetDataReader(sql);
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
        public static List<AMGroup> GetAuthGroups()
        {
            try
            {
                List<AMGroup> tmpAmgs = new List<AMGroup>();
                string sql = @"select * from AuthGroups";
                SqlDataReader tmpSDR = GetDataReader(sql);
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
                return tmpAmgs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 根据角色ID取角色数据
        /// </summary>
        /// <param name="GroupID">角色的ID</param>
        /// <returns>返回AMGroup对象</returns>
        public static AMGroup GetAuthGroup(string GroupID)
        {
            try
            {
                AMGroup tmpAmg = new AMGroup();
                string sql = @"select * from AuthGroups where Group_ID='" + GroupID + "'";
                SqlDataReader SDR = GetDataReader(sql);
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

        #endregion

        #region 3-------从数据库取用户的菜单数据
        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 取所有的菜单项
        /// </summary>
        /// <returns>AMMenus</returns>
        public static List<AMMenu> GetAuthMenus()
        {
            try
            {
                AMMenu amm = new AMMenu();
                List<AMMenu> amms = new List<AMMenu>();
                string sql = @"select * from AuthMenus";
                SqlDataReader tmpSDR = GetDataReader(sql);
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
        public static List<string> GetAuthGroup_Menus(AMGroup amg)
        {
            try
            {
                List<string> tmpMenus = new List<string>();
                string tmpGroupID=amg.Group_ID;
                string sql = @"select * from AuthGroupsMenus where Group_ID='" + tmpGroupID + "'";
                SqlDataReader tmpSDR = GetDataReader(sql);
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
        /// 获取角色的所有规则的ID的列表
        /// </summary>
        /// <param name="amg">角色对象</param>
        /// <returns>List.string</returns>
        public static List<string> GetAuthRules_ID(AMGroup amg)
        {
            try
            {
                List<string> tmpList = new List<string>();
                string tmpGroupID = amg.Group_ID;
                string sql = @"select * from AuthGroupsRules where Groups_ID='" + tmpGroupID + "'";
                SqlDataReader tmpSDR = GetDataReader(sql);
                while (tmpSDR.Read())
                {
                    tmpList.Add(tmpSDR["Rule_ID"].ToString());
                }
                tmpSDR.Close();
                return tmpList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 获取角色的所有规则
        /// </summary>
        /// <param name="amg">角色对象</param>
        /// <returns>List.AMRule</returns>
        public static List<AMRule> GetAuthRules(AMGroup amg)
        {
            try
            {
                List<AMRule> tmpAMRules = new List<AMRule>();
                string tmpGroupID = amg.Group_ID;
                string sql = @"select * from AuthGroupsRules where Group_ID='" + tmpGroupID + "'";
                SqlDataReader tmpSDR = GetDataReader(sql);
                while (tmpSDR.Read())
                {
                    AMRule tmpAMRule = new AMRule();
                    tmpAMRule.Rule_ID = tmpSDR["Rule_ID"].ToString();
                    tmpAMRule.Rule_Name = tmpSDR["Rule_Name"].ToString();
                    tmpAMRule.Rule_Item_ID = tmpSDR["Rule_Item_ID"].ToString();
                    tmpAMRule.Rule_Up_RuleID = tmpSDR["Rule_Up_RuleID"].ToString();
                    tmpAMRule.Rule_BeiZhu = tmpSDR["Rule_BeiZhu"].ToString();
                    tmpAMRules.Add(tmpAMRule);
                }
                tmpSDR.Close();
                return tmpAMRules;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 获取所有的规则
        /// </summary>
        /// <returns>返回AMRules对象</returns>
        public static List<AMRule> GetAuthRules()
        {
            try
            {
                List<AMRule> tmpRules = new List<AMRule>();
                string sql = @"select * from AuthRules";
                SqlDataReader tmpSDR = GetDataReader(sql);
                while (tmpSDR.Read())
                {
                    AMRule tmpAMRule = new AMRule();
                    tmpAMRule.Rule_ID = tmpSDR["Rule_ID"].ToString();
                    tmpAMRule.Rule_Name = tmpSDR["Rule_Name"].ToString();
                    tmpAMRule.Rule_Item_ID = tmpSDR["Rule_Item_ID"].ToString();
                    tmpAMRule.Rule_Up_RuleID = tmpSDR["Rule_Up_RuleID"].ToString();
                    tmpAMRule.Rule_BeiZhu = tmpSDR["Rule_BeiZhu"].ToString();
                    tmpRules.Add(tmpAMRule);
                }
                tmpSDR.Close();
                return tmpRules;
            }
            catch(Exception)
            {
                throw;
            }
        }


        #endregion

        #region 4to5----规则与对象对应表
        /// <summary>
        /// 获取指定Rule_Item_ID的ItemIDs
        /// </summary>
        /// <param name="amr">AMRule</param>
        /// <returns>List.string</returns>
        public static List<string> GetRu2It_ItemID(AMRule amr)
        {
            try
            {
                List<string> tmpRu2It = new List<string>();
                string AMRuleID = amr.Rule_ID;
                string sql = @"select * from AuthRu2It where Rule_Item_ID='" + amr.Rule_ID + "'";
                SqlDataReader tmpSDR = GetDataReader(sql);
                while (tmpSDR.Read())
                {
                    tmpRu2It.Add(tmpSDR["Item_ID"].ToString());
                }
                tmpSDR.Close();
                return tmpRu2It;
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
        /// 获取指定规则的Items
        /// </summary>
        /// <param name="amr">规则对象</param>
        /// <returns>返回List AMItem列表</returns>
        public static List<AMItem> GetAuthItems(AMRule amr)
        {
            try
            {
                List<AMItem> tmpAMItems = new List<AMItem>();
                string tmpRuleID = amr.Rule_ID;
                string sql = @"select * from AuthRulesItems where Rule_ID='" + tmpRuleID + "'";
                SqlDataReader tmpSDR = GetDataReader(sql);
                while (tmpSDR.Read())
                {
                    AMItem tmpAMI = new AMItem();
                    tmpAMI.Item_ID = tmpSDR["Item_ID"].ToString();
                    tmpAMI.Item_Name = tmpSDR["Item_Name"].ToString();
                    tmpAMI.Item_NameSpace = tmpSDR["Item_NameSpace"].ToString();
                    tmpAMI.Item_BeiZhu = tmpSDR["Item_BeiZhu"].ToString();
                    tmpAMItems.Add(tmpAMI);
                }
                tmpSDR.Close();
                return tmpAMItems;

            }
            catch (Exception)
            {
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 获取不用做权限处理的Items的列表
        /// </summary>
        /// <returns>List AMItem</returns>
        public static List<AMItem> GetAuthItemsNo()
        {
            try
            {
                List<AMItem> tmpItemsNo = new List<AMItem>();
                string sql = @"select * from AuthItemsNo";
                SqlDataReader tmpSDR = GetDataReader(sql);
                while (tmpSDR.Read())
                {
                    AMItem tmpAMItem = new AMItem();
                    tmpAMItem.Item_ID = tmpSDR["Item_ID"].ToString();
                    tmpAMItem.Item_Name = tmpSDR["Item_Name"].ToString();
                    tmpAMItem.Item_NameSpace = tmpSDR["Item_NameSpace"].ToString();
                    tmpAMItem.Item_BeiZhu = tmpSDR["Item_BeiZhu"].ToString();
                    tmpItemsNo.Add(tmpAMItem);
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
        /// 获取所有的Items对象
        /// </summary>
        /// <returns>返回AMItems</returns>
        public static List<AMItem> GetAuthItems()
        {
            try
            {
                List<AMItem> amis = new List<AMItem>();
                //string sql = @"select * from AuthGroupsItems";
                string sql = @"select * from AuthItems";
                SqlDataReader tmpSDR = GetDataReader(sql);
                while (tmpSDR.Read())
                {
                    AMItem ami = new AMItem();
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
        /// 获取指定角色的所有Items
        /// </summary>
        /// <param name="amg">角色对象</param>
        /// <returns>List AMItem</returns>
        public static List<AMItem> GetAuthItems(AMGroup amg)
        {
            try
            {
                List<AMItem> tmpAMItems = new List<AMItem>();
                string tmpAMGroupID = amg.Group_ID;
                string sql = @"select * from AuthGroupsItems where Group_ID='" + tmpAMGroupID + "'";
                SqlDataReader tmpSDR = GetDataReader(sql);
                while (tmpSDR.Read())
                {
                    AMItem tmpAMItem = new AMItem();
                    tmpAMItem.Item_ID = tmpSDR["Item_ID"].ToString();
                    tmpAMItem.Item_Name = tmpSDR["Item_Name"].ToString();
                    tmpAMItem.Item_NameSpace = tmpSDR["Item_NameSpace"].ToString();
                    tmpAMItem.Item_BeiZhu = tmpSDR["Item_BeiZhu"].ToString();
                    tmpAMItems.Add(tmpAMItem);
                }
                tmpSDR.Close();
                return tmpAMItems;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        
        #endregion

        #region 5-1-------保存对象到数据库（Item）
        /// <summary>
        /// 保存所有的Items
        /// </summary>
        /// <param name="amis"></param>
        public static bool SaveAuthItems(List<AMItem> amis)
        {
            try
            {
                
                AMItem tmpAMItem = new AMItem();  //临时的一个AMItem
                List<AMItem> dbItems = GetAuthItems(); //数据库中的所有items
                List<AMItem> gongItems = new List<AMItem>();//共有的数据
                List<AMItem> tmpSvItems = new List<AMItem>();
                tmpSvItems = amis;

                foreach (AMItem x in dbItems) //保存共有数据
                {
                    foreach (AMItem y in amis)
                    {
                        if (AuthItemIsSame(x, y))
                        {
                            gongItems.Add(x);
                        }
                    }
                }
                foreach (AMItem x in dbItems) //从数据库删除不是共有的数据
                {
                    if (!gongItems.Contains(x))
                    {
                        DelAuthItem(x);
                    }
                }

                foreach (AMItem x in tmpSvItems)//循环剩下的数据，添加保存到数据库
                {
                    bool isAdd = true;
                    foreach (AMItem y in gongItems)
                    {
                        if (AuthItemIsSame(x, y))
                        {
                            isAdd = false;
                        }
                    }
                    if (isAdd)
                    {
                        AddAuthItem(x);
                    }
                }
                //到这里，所有的数据就已经保存完成了！
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static bool SaveAuthRu2It(List<AMItem> amis, AMRule amr)
        {
            try
            {
                string AMRuleID = amr.Rule_Item_ID;

                //当前规则的items的ID的列表
                List<string> tmpItemsID = GetRu2It_ItemID(amr);
                //删除以前的
                string tmpSql = @"delete from AuthRu2It where Rule_Item_ID='" + AMRuleID + "'";
                ADSqlOpera.ExcSqlCommand(tmpSql);
                foreach (AMItem x in amis)
                {
                    //添加现在的
                    string tmpSql1 = @"insert into AuthRu2It values('" + AMRuleID + "','" + x.Item_ID + "')";
                    ADSqlOpera.ExcSqlCommand(tmpSql1);
                }

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 从数据库删除一个Item
        /// </summary>
        /// <param name="ami">要删除的Item对象</param>
        /// <returns>返回影响的行数!</returns>
        public static int DelAuthItem(AMItem ami)
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                string tmpID = ami.Item_ID;
                string sql = @"delete from AuthItems where Item_ID='" + tmpID + "'";
                int x=ADSqlOpera.ExcSqlCommand(sql);
                return x;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 添加一个Item到数据库
        /// </summary>
        /// <param name="ami">要添加的Item</param>
        /// <returns>返回影响的行数</returns>
        public static int AddAuthItem(AMItem ami)
        {
            if (amsc == null)
            {
                throw new Exception("在操作之前，必需先加载AMSqlConf！");
            }
            try
            {
                string tmpID=ami.Item_ID;
                string tmpName=ami.Item_Name;
                string tmpNP=ami.Item_NameSpace;
                string tmpBZ=ami.Item_BeiZhu;
                string tmpValue="'"+tmpID+"','"+tmpName+"','"+tmpNP+"','"+tmpBZ+"'";
                string sql = @"insert into AuthItems values(" + tmpValue + ")";
                int x = ADSqlOpera.ExcSqlCommand(sql);
                return x;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 比较两个AMItem对象，是否相等
        /// </summary>
        /// <param name="ami1"></param>
        /// <param name="ami2"></param>
        /// <returns></returns>
        public static bool AuthItemIsSame(AMItem ami1, AMItem ami2)
        {
            if ((ami1.Item_ID == ami2.Item_ID) && (ami1.Item_Name == ami2.Item_Name) && (ami1.Item_NameSpace == ami2.Item_NameSpace) && (ami1.Item_BeiZhu == ami2.Item_BeiZhu))
            {
                return true;
            }
            else
            {
                return false;
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
            /*
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
            }*/
            #endregion

            #region 2-------控件处理
            //取用户的角色的权限的对象列表-
            List<AMItem> tmpAMItems = GetAuthItems(amg);
            List<string> tmpGroupItems = GetAMItemsValue(AMItemValueType.Item_Name,GetAuthItems(amg));

            //取不用做权限处理的控件列表
            List<string> tmpGroupItemsNo = GetAMItemsValue(AMItemValueType.Item_Name, GetAuthItemsNo());

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
