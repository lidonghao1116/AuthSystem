﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AuthSystem.AuthForm
{
    public partial class AFAuthSet : AFBase
    {
        #region 公共变量
        private AuthModel.AMUser seleAMUser; //当前选择的用户
        private AuthModel.AMGroup seleAMGroup;//当前选择的角色
        private bool canLoad = false; //是否可以进行选择切换的处理进程
        private BindingSource tmpBSgroups = new BindingSource(); //角色的绑定对象
        private BindingSource tmpBSusers = new BindingSource();  //用户的绑定对象
        private TreeNode tnMenu = new TreeNode("菜单");   //规则的根节点
        private TreeNode tnRules = new TreeNode("其它");  //规则的根节点
        private TreeNode tnCangKu = new TreeNode("仓库"); //规则的根节点
        #endregion
        public AFAuthSet()
        {

            InitializeComponent();
            InitMenu();
            InitData();
            //下面一行进行权限管理
            //AuthSystem.AuthDao.ADAuthOpera.SetWindowsAuth(AuthSystem.AuthGlobal.GlobalAmu, this.Controls);
        }

        #region 初始化------------------------------------------------------------------------------------------------------
        private Panel panel_Left;
        private Panel panel_Right_Down;
        private Panel panel_Right_Up;
        private DataGridView dgv_Allusers;
        private TreeView tv_Rules;
        private IContainer components;
        private DataGridView dgv_AllGroups;
        private Panel panel_Right;
        #region 1-------界面初始化
        /// <summary>
        /// 界面初始化，程序自动生成
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Left = new System.Windows.Forms.Panel();
            this.dgv_Allusers = new System.Windows.Forms.DataGridView();
            this.panel_Right = new System.Windows.Forms.Panel();
            this.panel_Right_Down = new System.Windows.Forms.Panel();
            this.tv_Rules = new System.Windows.Forms.TreeView();
            this.panel_Right_Up = new System.Windows.Forms.Panel();
            this.dgv_AllGroups = new System.Windows.Forms.DataGridView();
            this.panel_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Allusers)).BeginInit();
            this.panel_Right.SuspendLayout();
            this.panel_Right_Down.SuspendLayout();
            this.panel_Right_Up.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AllGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Left
            // 
            this.panel_Left.BackColor = System.Drawing.SystemColors.Control;
            this.panel_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Left.Controls.Add(this.dgv_Allusers);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 0);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(522, 562);
            this.panel_Left.TabIndex = 0;
            // 
            // dgv_Allusers
            // 
            this.dgv_Allusers.AllowUserToResizeRows = false;
            this.dgv_Allusers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv_Allusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Allusers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Allusers.Location = new System.Drawing.Point(0, 0);
            this.dgv_Allusers.MultiSelect = false;
            this.dgv_Allusers.Name = "dgv_Allusers";
            this.dgv_Allusers.ReadOnly = true;
            this.dgv_Allusers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Allusers.RowHeadersVisible = false;
            this.dgv_Allusers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Allusers.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Allusers.RowTemplate.Height = 23;
            this.dgv_Allusers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Allusers.Size = new System.Drawing.Size(520, 560);
            this.dgv_Allusers.TabIndex = 0;
            this.dgv_Allusers.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_Alluser_RowStateChanged);
            // 
            // panel_Right
            // 
            this.panel_Right.Controls.Add(this.panel_Right_Down);
            this.panel_Right.Controls.Add(this.panel_Right_Up);
            this.panel_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Right.Location = new System.Drawing.Point(522, 0);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(362, 562);
            this.panel_Right.TabIndex = 1;
            // 
            // panel_Right_Down
            // 
            this.panel_Right_Down.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Right_Down.Controls.Add(this.tv_Rules);
            this.panel_Right_Down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Right_Down.Location = new System.Drawing.Point(0, 261);
            this.panel_Right_Down.Name = "panel_Right_Down";
            this.panel_Right_Down.Size = new System.Drawing.Size(362, 301);
            this.panel_Right_Down.TabIndex = 1;
            // 
            // tv_Rules
            // 
            this.tv_Rules.CheckBoxes = true;
            this.tv_Rules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Rules.Location = new System.Drawing.Point(0, 0);
            this.tv_Rules.Name = "tv_Rules";
            this.tv_Rules.Size = new System.Drawing.Size(360, 299);
            this.tv_Rules.TabIndex = 0;
            // 
            // panel_Right_Up
            // 
            this.panel_Right_Up.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Right_Up.Controls.Add(this.dgv_AllGroups);
            this.panel_Right_Up.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Right_Up.Location = new System.Drawing.Point(0, 0);
            this.panel_Right_Up.Name = "panel_Right_Up";
            this.panel_Right_Up.Size = new System.Drawing.Size(362, 261);
            this.panel_Right_Up.TabIndex = 0;
            // 
            // dgv_AllGroups
            // 
            this.dgv_AllGroups.AllowUserToResizeRows = false;
            this.dgv_AllGroups.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv_AllGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AllGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_AllGroups.Location = new System.Drawing.Point(0, 0);
            this.dgv_AllGroups.MultiSelect = false;
            this.dgv_AllGroups.Name = "dgv_AllGroups";
            this.dgv_AllGroups.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_AllGroups.RowHeadersVisible = false;
            this.dgv_AllGroups.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_AllGroups.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_AllGroups.RowTemplate.Height = 23;
            this.dgv_AllGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_AllGroups.Size = new System.Drawing.Size(360, 259);
            this.dgv_AllGroups.TabIndex = 0;
            this.dgv_AllGroups.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_AllGroups_RowStateChanged);
            // 
            // AFAuthSet
            // 
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.panel_Right);
            this.Controls.Add(this.panel_Left);
            this.Name = "AFAuthSet";
            this.Text = "权限管理";
            this.Load += new System.EventHandler(this.AFAuthSet_Load);
            this.panel_Left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Allusers)).EndInit();
            this.panel_Right.ResumeLayout(false);
            this.panel_Right_Down.ResumeLayout(false);
            this.panel_Right_Up.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AllGroups)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region 2-------菜单初始化
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 初始化菜单按钮
        /// </summary>
        private void InitMenu()
        {
            //用户菜单：panel_Left菜单
            ToolStrip tsLe = new ToolStrip();
            ToolStripButton tsb1 = new ToolStripButton("添加用户", null, new EventHandler(this.tsb1_Click));
            ToolStripButton tsb2 = new ToolStripButton("修改用户");
            ToolStripButton tsb3 = new ToolStripButton("删除用户");
            tsLe.Items.Add(tsb1);
            tsLe.Items.Add(tsb2);
            tsLe.Items.Add(tsb3);
            panel_Left.Controls.Add(tsLe);



            //角色菜单：panel_Right_Up菜单
            ToolStrip tsRU = new ToolStrip();
            ToolStripButton tsb10 = new ToolStripButton("添加角色");
            ToolStripButton tsb11 = new ToolStripButton("修改角色");
            ToolStripButton tsb12 = new ToolStripButton("删除角色");
            tsRU.Items.Add(tsb10);
            tsRU.Items.Add(tsb11);
            tsRU.Items.Add(tsb12);
            panel_Right_Up.Controls.Add(tsRU);
            //权限菜单:panel_Right_Down菜单
            //ToolStrip tsRD = new ToolStrip();
            //ToolStripSeparator tss20 = new ToolStripSeparator();
            //tsRD.Items.Add(tss20);
            //panel_Right_Down.Controls.Add(tsRD);
        }
        private void tsb1_Click(object sender, EventArgs e) //添加用户处理
        {
            AuthModel.AMUser amu = new AuthModel.AMUser();
            amu.User_ID = "8";
            amu.User_Name = "acuser";
            amu.User_Text = "sy";
            amu.User_Status = true;
            amu.User_Pass = "ab1321";
            MessageBox.Show(AuthSystem.AuthDao.ADAuthOpera.AddAuthUser(amu).ToString());
        }
        #endregion

        #region 3-------数据库初始化
        private void InitData()
        {
            #region 1--//加载所有用户数据
            AuthModel.AMUsers amus = AuthDao.ADAuthOpera.GetAuthUsers();
            tmpBSusers.DataSource = typeof(AuthSystem.AuthModel.AMUser);
            tmpBSusers.DataSource = amus.ListAMUsers;
            dgv_Allusers.DataSource = tmpBSusers; //绑定数据源
            dgv_Allusers.Columns[0].HeaderText = "ID";
            dgv_Allusers.Columns[0].Width = 30;
            dgv_Allusers.Columns[1].HeaderText = "登陆名";
            dgv_Allusers.Columns[1].Width = 80;
            dgv_Allusers.Columns[2].HeaderText = "用户名";
            dgv_Allusers.Columns[2].Width = 80;
            dgv_Allusers.Columns[3].Visible = false;//隐藏密码
            dgv_Allusers.Columns[4].HeaderText = "电话";
            dgv_Allusers.Columns[4].Width = 100;
            dgv_Allusers.Columns[5].HeaderText = "QQ";
            dgv_Allusers.Columns[5].Width = 80;
            dgv_Allusers.Columns[6].HeaderText = "E-mail";
            dgv_Allusers.Columns[6].Width = 100;
            dgv_Allusers.Columns[7].HeaderText = "启用";
            dgv_Allusers.Columns[7].Width = 50;
            dgv_Allusers.Columns[8].Visible = false;//隐藏角色ID
            dgv_Allusers.Columns[9].HeaderText = "默认仓库";
            dgv_Allusers.Columns[9].Width = 100;
            dgv_Allusers.Columns[10].HeaderText = "备注";
            dgv_Allusers.Columns[10].Width = 120;
            #endregion

            #region 2--//加载所有角色数据
            AuthModel.AMGroups amgs = AuthDao.ADAuthOpera.GetAuthGroups();
            tmpBSgroups.DataSource = typeof(AuthModel.AMGroup);
            tmpBSgroups.DataSource = amgs.AllGroups;
            DataGridViewCheckBoxColumn dgvcbc = new DataGridViewCheckBoxColumn(false);
            dgvcbc.HeaderText = "选择";
            dgvcbc.Width = 30;
            dgvcbc.ReadOnly = false;
            dgv_AllGroups.Columns.Add(dgvcbc);
            dgv_AllGroups.DataSource = typeof(AuthModel.AMGroup);
            dgv_AllGroups.DataSource = tmpBSgroups;
            dgv_AllGroups.Columns[1].HeaderText = "ID";
            dgv_AllGroups.Columns[1].Width = 30;
            dgv_AllGroups.Columns[1].ReadOnly = true;
            dgv_AllGroups.Columns[2].HeaderText = "角色名";
            dgv_AllGroups.Columns[2].Width = 160;
            dgv_AllGroups.Columns[2].ReadOnly = true;
            dgv_AllGroups.Columns[3].HeaderText = "启用";
            dgv_AllGroups.Columns[3].Width = 50;
            dgv_AllGroups.Columns[4].Visible = false;//
            dgv_AllGroups.Columns[5].Visible = false;
            dgv_AllGroups.Columns[6].Visible = false;
            dgv_AllGroups.Columns[7].HeaderText = "备注";
            dgv_AllGroups.Columns[7].Width = 120;
            dgv_AllGroups.Columns[7].ReadOnly = true;
            #endregion

            #region 3--//加载所有权限数据
            //加载菜单-------------------------------------------------
            tv_Rules.Nodes.Add(tnMenu);

            //加载对象权限-------------------------------------------------
            tv_Rules.Nodes.Add(tnRules);
            AuthModel.AMRules tnRules_Rules = new AuthModel.AMRules();
            tnRules_Rules = AuthDao.ADAuthOpera.GetAuthRules();
            for (int i = 0; i < tnRules_Rules.AllAMRules.Count; i++)
            {
                tnRules.Nodes.Add(tnRules_Rules.AllAMRules[i].Rule_Name);
                tnRules.Nodes[i].Checked = false;
            }

            //加载仓库列表-------------------------------------------------
            tv_Rules.Nodes.Add(tnCangKu);
            #endregion

        }

        #endregion

        private void AFAuthSet_Load(object sender, EventArgs e)
        {
            seleAMUser = AuthDao.ADAuthOpera.GetAuthUser(dgv_Allusers.SelectedRows[0].Cells["User_Name"].Value.ToString());  //设置当前选择的用户
            for (int i = 0; i < dgv_AllGroups.Rows.Count; i++)
            {
                //MessageBox.Show(seleAMUser.User_Group + "|" + dgv_AllGroups.Rows[i].Cells["Group_ID"].Value.ToString());
                if (seleAMUser.User_Group == dgv_AllGroups.Rows[i].Cells["Group_ID"].Value.ToString())
                {
                    dgv_AllGroups.Rows[i].Selected = true;
                    dgv_AllGroups.Rows[i].Cells[0].Value = true;
                    //seleAMGroup = AuthDao.ADAuthOpera.GetAuthGroup(dgv_AllGroups.Rows[i].Cells["Group_ID"].Value.ToString());
                    break;
                }
            }
            canLoad = true;
        }

        #endregion

        private void dgv_Alluser_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (canLoad)
            {
                if (e.Row.Cells["User_Name"].Value != null)
                {
                    if (!String.IsNullOrEmpty(seleAMUser.User_Group))
                    {
                        seleAMUser = AuthDao.ADAuthOpera.GetAuthUser(e.Row.Cells["User_Name"].Value.ToString());  //设置当前选择的用户
                        for (int i = 0; i < dgv_AllGroups.Rows.Count - 1; i++)
                        {
                            if (seleAMUser.User_Group == dgv_AllGroups.Rows[i].Cells["Group_ID"].Value.ToString())
                            {
                                dgv_AllGroups.Rows[i].Selected = true;
                                dgv_AllGroups.Rows[i].Cells[0].Value = true;
                            }
                            else
                            {
                                dgv_AllGroups.Rows[i].Cells[0].Value = false;
                            }
                        }
                    }
                }
            }
        }

        private void dgv_AllGroups_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (canLoad)
            {
                if (e.Row.Cells["Group_Name"].Value != null)
                {
                    seleAMGroup = AuthDao.ADAuthOpera.GetAuthGroup(e.Row.Cells["Group_ID"].Value.ToString());
                    //取角色的规则
                    AuthModel.AMRules tmpAMR = AuthDao.ADAuthOpera.GetAuthRules_ByGroup_ForAMRules(seleAMGroup);
                    for (int i = 0; i < tnRules.Nodes.Count; i++)
                    {
                        tnRules.Nodes[i].Checked = false;
                        for (int j = 0; j < tmpAMR.AllAMRules.Count; j++)
                        {
                            string tmpStr = tmpAMR.AllAMRules[j].Rule_Name;
                            //MessageBox.Show(tnRules.Nodes[i].Text);
                            if (tnRules.Nodes[i].Text == tmpStr)
                            {
                                tnRules.Nodes[i].Checked = true;
                            }
                        }
                    }
                    
                    tv_Rules.Refresh(); //刷新显示界面
                }
            }
        }
    }
}
