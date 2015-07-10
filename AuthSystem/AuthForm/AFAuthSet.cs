using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using AuthSystem.AuthForm;
using AuthSystem.AuthData;
using AuthSystem.AuthPool;

namespace AuthSystem.AuthForm
{
    /// <summary>
    /// 用户与角色权限管理模块
    /// </summary>
    public class AFAuthSet:AFBase
    {
        #region 0-------清理资源
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region 0-----公共变量
        private DataTable Users_DataTable; //用户DataTable
        private DataTable Groups_DataTable;//角色DataTable
        private DataTable Rules_DataTable;//规则DataTable
        private DataTable Ru2It_DataTable;
        private DataTable Us2Gr_DataTable;//用户对应角色DataTable
        private DataTable Gr2Ru_DataTable;//角色对应规则DataTable
        private DataRow tmpUsersAddRow; //缓存要添加的用户表行
        private DataRow tmpGroupsAddRow;//缓存要添加的角色表行
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolSaveGroupRule;
        private bool LoadOver = false; //是否初始化完成
        private ADAction ADAct = new ADAction();
        #endregion

        #region 1-----初始化
        /// <summary>
        /// 构造函数
        /// </summary>
        public AFAuthSet()
        {
            ADAct.ConnString = APPoolGlobal.GlobalAMSystemConfig.ConnectionString; //设置连接字符串
            InitializeComponent();  //界面初始化
            InitData_Users();       //用户初始化
            InitData_Us2Gr();
            InitData_Groups();      //角色初始化
            InitData_Gr2Ru();
            InitData_Rules();       //规则初始化
        }
        
        #region 0--界面初始化
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Panel panelGroups;
        private System.Windows.Forms.Panel panelRules;
        private System.Windows.Forms.ToolStrip toolUsers;
        private System.Windows.Forms.ToolStrip toolGroups;
        private System.Windows.Forms.DataGridView dgv_Users;
        private System.Windows.Forms.DataGridView dgv_Groups;
        private System.Windows.Forms.TreeView treeRules;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menu_1;
        private System.Windows.Forms.ToolStripMenuItem menu_1_1;
        private System.Windows.Forms.ToolStripMenuItem menu_1_2;
        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.ToolStripButton toolUsersAdd;
        private System.Windows.Forms.ToolStripButton toolUsersDel;
        private System.Windows.Forms.ToolStripButton toolUsersSave;
        private ToolStripButton toolGroupsAdd;
        private ToolStripButton toolGroupsDel;
        private ToolStripButton toolGroupsSave;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFAuthSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.dgv_Users = new System.Windows.Forms.DataGridView();
            this.toolUsers = new System.Windows.Forms.ToolStrip();
            this.toolUsersAdd = new System.Windows.Forms.ToolStripButton();
            this.toolUsersDel = new System.Windows.Forms.ToolStripButton();
            this.toolUsersSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panelGroups = new System.Windows.Forms.Panel();
            this.dgv_Groups = new System.Windows.Forms.DataGridView();
            this.toolGroups = new System.Windows.Forms.ToolStrip();
            this.toolGroupsAdd = new System.Windows.Forms.ToolStripButton();
            this.toolGroupsDel = new System.Windows.Forms.ToolStripButton();
            this.toolGroupsSave = new System.Windows.Forms.ToolStripButton();
            this.toolSaveGroupRule = new System.Windows.Forms.ToolStripButton();
            this.panelRules = new System.Windows.Forms.Panel();
            this.treeRules = new System.Windows.Forms.TreeView();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menu_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_1_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_1_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutMain.SuspendLayout();
            this.panelUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Users)).BeginInit();
            this.toolUsers.SuspendLayout();
            this.panelGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Groups)).BeginInit();
            this.toolGroups.SuspendLayout();
            this.panelRules.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.layoutMain.ColumnCount = 2;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.24712F));
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.75288F));
            this.layoutMain.Controls.Add(this.panelUsers, 0, 0);
            this.layoutMain.Controls.Add(this.panelGroups, 1, 0);
            this.layoutMain.Controls.Add(this.panelRules, 1, 1);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 25);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 2;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutMain.Size = new System.Drawing.Size(1154, 668);
            this.layoutMain.TabIndex = 0;
            // 
            // panelUsers
            // 
            this.panelUsers.Controls.Add(this.dgv_Users);
            this.panelUsers.Controls.Add(this.toolUsers);
            this.panelUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUsers.Location = new System.Drawing.Point(4, 4);
            this.panelUsers.Name = "panelUsers";
            this.layoutMain.SetRowSpan(this.panelUsers, 2);
            this.panelUsers.Size = new System.Drawing.Size(560, 660);
            this.panelUsers.TabIndex = 0;
            // 
            // dgv_Users
            // 
            this.dgv_Users.AllowUserToAddRows = false;
            this.dgv_Users.AllowUserToDeleteRows = false;
            this.dgv_Users.AllowUserToOrderColumns = true;
            this.dgv_Users.AllowUserToResizeRows = false;
            this.dgv_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Users.Location = new System.Drawing.Point(0, 25);
            this.dgv_Users.MultiSelect = false;
            this.dgv_Users.Name = "dgv_Users";
            this.dgv_Users.RowHeadersVisible = false;
            this.dgv_Users.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Users.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Users.RowTemplate.Height = 23;
            this.dgv_Users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Users.Size = new System.Drawing.Size(560, 635);
            this.dgv_Users.TabIndex = 1;
            this.dgv_Users.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_Users_CellStateChange);
            this.dgv_Users.SelectionChanged += new System.EventHandler(this.dgv_Users_SeleChanged);
            // 
            // toolUsers
            // 
            this.toolUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolUsersAdd,
            this.toolUsersDel,
            this.toolUsersSave,
            this.toolStripSeparator1});
            this.toolUsers.Location = new System.Drawing.Point(0, 0);
            this.toolUsers.Name = "toolUsers";
            this.toolUsers.Size = new System.Drawing.Size(560, 25);
            this.toolUsers.TabIndex = 0;
            this.toolUsers.Text = "toolStrip1";
            // 
            // toolUsersAdd
            // 
            this.toolUsersAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolUsersAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolUsersAdd.Image")));
            this.toolUsersAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUsersAdd.Name = "toolUsersAdd";
            this.toolUsersAdd.Size = new System.Drawing.Size(60, 22);
            this.toolUsersAdd.Text = "添加用户";
            this.toolUsersAdd.Click += new System.EventHandler(this.toolUsersAdd_Click);
            // 
            // toolUsersDel
            // 
            this.toolUsersDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolUsersDel.Image = ((System.Drawing.Image)(resources.GetObject("toolUsersDel.Image")));
            this.toolUsersDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUsersDel.Name = "toolUsersDel";
            this.toolUsersDel.Size = new System.Drawing.Size(60, 22);
            this.toolUsersDel.Text = "删除用户";
            this.toolUsersDel.Click += new System.EventHandler(this.toolUsersDel_Click);
            // 
            // toolUsersSave
            // 
            this.toolUsersSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolUsersSave.Image = ((System.Drawing.Image)(resources.GetObject("toolUsersSave.Image")));
            this.toolUsersSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUsersSave.Name = "toolUsersSave";
            this.toolUsersSave.Size = new System.Drawing.Size(60, 22);
            this.toolUsersSave.Text = "保存更改";
            this.toolUsersSave.Click += new System.EventHandler(this.toolUsersSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // panelGroups
            // 
            this.panelGroups.Controls.Add(this.dgv_Groups);
            this.panelGroups.Controls.Add(this.toolGroups);
            this.panelGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGroups.Location = new System.Drawing.Point(571, 4);
            this.panelGroups.Name = "panelGroups";
            this.panelGroups.Size = new System.Drawing.Size(579, 326);
            this.panelGroups.TabIndex = 1;
            // 
            // dgv_Groups
            // 
            this.dgv_Groups.AllowUserToAddRows = false;
            this.dgv_Groups.AllowUserToDeleteRows = false;
            this.dgv_Groups.AllowUserToResizeRows = false;
            this.dgv_Groups.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv_Groups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Groups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Groups.Location = new System.Drawing.Point(0, 25);
            this.dgv_Groups.MultiSelect = false;
            this.dgv_Groups.Name = "dgv_Groups";
            this.dgv_Groups.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Groups.RowHeadersVisible = false;
            this.dgv_Groups.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Groups.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Groups.RowTemplate.Height = 23;
            this.dgv_Groups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Groups.Size = new System.Drawing.Size(579, 301);
            this.dgv_Groups.TabIndex = 1;
            this.dgv_Groups.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Groups_CellMouseUp);
            this.dgv_Groups.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_Groups_CellStateChange);
            this.dgv_Groups.SelectionChanged += new System.EventHandler(this.dgv_Groups_SeleChanged);
            // 
            // toolGroups
            // 
            this.toolGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolGroupsAdd,
            this.toolGroupsDel,
            this.toolGroupsSave,
            this.toolSaveGroupRule});
            this.toolGroups.Location = new System.Drawing.Point(0, 0);
            this.toolGroups.Name = "toolGroups";
            this.toolGroups.Size = new System.Drawing.Size(579, 25);
            this.toolGroups.TabIndex = 0;
            this.toolGroups.Text = "toolStrip2";
            // 
            // toolGroupsAdd
            // 
            this.toolGroupsAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolGroupsAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolGroupsAdd.Image")));
            this.toolGroupsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGroupsAdd.Name = "toolGroupsAdd";
            this.toolGroupsAdd.Size = new System.Drawing.Size(60, 22);
            this.toolGroupsAdd.Text = "添加角色";
            this.toolGroupsAdd.Click += new System.EventHandler(this.toolGroupsAdd_Click);
            // 
            // toolGroupsDel
            // 
            this.toolGroupsDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolGroupsDel.Image = ((System.Drawing.Image)(resources.GetObject("toolGroupsDel.Image")));
            this.toolGroupsDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGroupsDel.Name = "toolGroupsDel";
            this.toolGroupsDel.Size = new System.Drawing.Size(60, 22);
            this.toolGroupsDel.Text = "删除角色";
            this.toolGroupsDel.Click += new System.EventHandler(this.toolGroupsDel_Click);
            // 
            // toolGroupsSave
            // 
            this.toolGroupsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolGroupsSave.Image = ((System.Drawing.Image)(resources.GetObject("toolGroupsSave.Image")));
            this.toolGroupsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGroupsSave.Name = "toolGroupsSave";
            this.toolGroupsSave.Size = new System.Drawing.Size(60, 22);
            this.toolGroupsSave.Text = "保存角色";
            this.toolGroupsSave.Click += new System.EventHandler(this.toolGroupsSave_Click);
            // 
            // toolSaveGroupRule
            // 
            this.toolSaveGroupRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSaveGroupRule.Image = ((System.Drawing.Image)(resources.GetObject("toolSaveGroupRule.Image")));
            this.toolSaveGroupRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveGroupRule.Name = "toolSaveGroupRule";
            this.toolSaveGroupRule.Size = new System.Drawing.Size(84, 22);
            this.toolSaveGroupRule.Text = "保存角色规则";
            this.toolSaveGroupRule.Click += new System.EventHandler(this.toolSaveGroupRule_Click);
            // 
            // panelRules
            // 
            this.panelRules.Controls.Add(this.treeRules);
            this.panelRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRules.Location = new System.Drawing.Point(571, 337);
            this.panelRules.Name = "panelRules";
            this.panelRules.Size = new System.Drawing.Size(579, 327);
            this.panelRules.TabIndex = 2;
            // 
            // treeRules
            // 
            this.treeRules.CheckBoxes = true;
            this.treeRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRules.Location = new System.Drawing.Point(0, 0);
            this.treeRules.Name = "treeRules";
            this.treeRules.Size = new System.Drawing.Size(579, 327);
            this.treeRules.TabIndex = 0;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_1});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1154, 25);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // menu_1
            // 
            this.menu_1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_1_1,
            this.menu_1_2});
            this.menu_1.Name = "menu_1";
            this.menu_1.Size = new System.Drawing.Size(68, 21);
            this.menu_1.Text = "高级设置";
            // 
            // menu_1_1
            // 
            this.menu_1_1.Name = "menu_1_1";
            this.menu_1_1.Size = new System.Drawing.Size(174, 22);
            this.menu_1_1.Text = "设置规则对象绑定";
            this.menu_1_1.Click += new System.EventHandler(this.menu_1_1_Click);
            // 
            // menu_1_2
            // 
            this.menu_1_2.Name = "menu_1_2";
            this.menu_1_2.Size = new System.Drawing.Size(174, 22);
            this.menu_1_2.Text = "设置ItemsNo对象";
            this.menu_1_2.Click += new System.EventHandler(this.menu_1_2_Click);
            // 
            // AFAuthSet
            // 
            this.ClientSize = new System.Drawing.Size(1154, 693);
            this.Controls.Add(this.layoutMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "AFAuthSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "权限管理";
            this.Shown += new System.EventHandler(this.AFAuthSet_Shown);
            this.layoutMain.ResumeLayout(false);
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Users)).EndInit();
            this.toolUsers.ResumeLayout(false);
            this.toolUsers.PerformLayout();
            this.panelGroups.ResumeLayout(false);
            this.panelGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Groups)).EndInit();
            this.toolGroups.ResumeLayout(false);
            this.toolGroups.PerformLayout();
            this.panelRules.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region 1--数据初始化
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InitData_Users()
        {
            ADAct.ReadToPool(PoolType.Users);
            Users_DataTable = ADAct.ReadPool(PoolType.Users);

            dgv_Users.DataSource = Users_DataTable;                             //显示DataTable
            //列重命名
            dgv_Users.Columns[0].HeaderText = "ID";
            dgv_Users.Columns[0].Width = 30;
            dgv_Users.Columns[1].HeaderText = "用户名";
            dgv_Users.Columns[1].Width = 80;
            dgv_Users.Columns[2].HeaderText = "名字";
            dgv_Users.Columns[2].Width = 80;
            dgv_Users.Columns[3].HeaderText = "密码";
            dgv_Users.Columns[3].Width = 80;
            dgv_Users.Columns[4].HeaderText = "状态";
            dgv_Users.Columns[4].Width = 40;
            dgv_Users.Columns[5].HeaderText = "电话";
            dgv_Users.Columns[5].Width = 80;
            dgv_Users.Columns[6].HeaderText = "QQ";
            dgv_Users.Columns[6].Width = 80;
            dgv_Users.Columns[7].HeaderText = "Email";
            dgv_Users.Columns[7].Width = 100;
            dgv_Users.Columns[8].HeaderText = "备注";
            dgv_Users.Columns[8].Width = 200;
        }
        /// <summary>
        /// 初始化角色数据
        /// </summary>
        private void InitData_Groups()
        {
            ADAct.ReadToPool(PoolType.Groups);
            Groups_DataTable = ADAct.ReadPool(PoolType.Groups);

            DataGridViewCheckBoxColumn dgvcbc = new DataGridViewCheckBoxColumn(false); //第一列为checkbox;
            dgv_Groups.Columns.Add(dgvcbc);
            dgv_Groups.DataSource = Groups_DataTable; //绑定数据

            dgv_Groups.Columns[0].HeaderText = "选择";
            dgv_Groups.Columns[0].Width = 40;
            dgv_Groups.Columns[1].HeaderText = "ID";
            dgv_Groups.Columns[1].Width = 30;
            dgv_Groups.Columns[2].HeaderText = "角色名";
            dgv_Groups.Columns[2].Width = 80;
            dgv_Groups.Columns[3].HeaderText = "状态";
            dgv_Groups.Columns[3].Width = 40;
            dgv_Groups.Columns[4].HeaderText = "Sup";
            dgv_Groups.Columns[4].Width = 40;
            dgv_Groups.Columns[5].HeaderText = "备注";
            dgv_Groups.Columns[5].Width = 150;
        }
        /// <summary>
        /// 初始化规则数据
        /// </summary>
        private void InitData_Rules()
        {
            ADAct.ReadToPool(PoolType.Rules);
            //Rules_DataTable = ADAct.ReadPool(PoolType.Rules);
            treeRules.Nodes.Clear();
            treeRules.Nodes.AddRange(ADAct.SetTreeViewData());
            /*treeRules.Nodes.Clear();
            treeRules.Nodes.AddRange(AP2SOpera.Rules2Tree()); //显示所有规则
            if (dgv_Groups.Rows.Count > 0)
            {
                AP2SOpera.SetTreeViewCheckBox(treeRules, dgv_Groups.Rows[0].Cells["Group_ID"].Value.ToString()); //勾选当前角色的规则
            }*/
            
        }
        private void InitData_Gr2Ru()
        {
            ADAct.ReadToPool(PoolType.Gr2Ru);
            Ru2It_DataTable = ADAct.ReadPool(PoolType.Gr2Ru);
        }
        private void InitData_Us2Gr()
        {
            ADAct.ReadToPool(PoolType.Us2Gr);
        }
        
        #endregion
        #endregion

        #region 3--用户工具按钮操作
        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 添加用户行
        /// </summary>
        private void toolUsersAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tmpUsersAddRow = Users_DataTable.NewRow();
                tmpUsersAddRow[0] = 0;
                tmpUsersAddRow[8] = true;
                Users_DataTable.Rows.Add(tmpUsersAddRow);
            }
            catch (Exception x) 
            {
                MessageBox.Show(x.Message);
            }
        }

        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 删除用户行
        /// </summary>
        private void toolUsersDel_Click(object sender, EventArgs e)
        {
            if (dgv_Users.SelectedRows.Count > 0)
            {
                dgv_Users.Rows.RemoveAt(dgv_Users.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("请选择要删除的用户！");
            }
        }

        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 保存用户表的更改
        /// </summary>
        private void toolUsersSave_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_Users.DataSource = null;
                ADAct.SavePool(PoolType.Users, Users_DataTable);
                ADAct.UpdatePool(PoolType.Users);
                InitData_Users();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                InitData_Users();
            }
        }
        #endregion

        #region 4--角色工具按钮操作
        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 添加角色
        /// </summary>
        private void toolGroupsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tmpGroupsAddRow = Groups_DataTable.NewRow();
                tmpGroupsAddRow[3] = true;
                Groups_DataTable.Rows.Add(tmpGroupsAddRow);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 删除角色
        /// </summary>
        private void toolGroupsDel_Click(object sender, EventArgs e)
        {
            if (dgv_Groups.SelectedRows.Count > 0)
            {
                dgv_Groups.Rows.RemoveAt(dgv_Groups.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("请选择要删除的行！");
            }
        }

        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 保存角色的所有修改
        /// </summary>
        private void toolGroupsSave_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_Groups.DataSource = null;
                dgv_Groups.Columns.Clear();
                ADAct.SavePool(PoolType.Groups, Groups_DataTable);
                ADAct.UpdatePool(PoolType.Groups);
                InitData_Groups();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                InitData_Groups();
            }
        }

        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 保存当前角色规则
        /// </summary>
        private void toolSaveGroupRule_Click(object sender, EventArgs e)
        {
            /*
            AP2SOpera.saveGr2Ru_TreeView(treeRules, "1");
            AuthPool2Db.AP2DOpera.UpdatePool(AuthPool.PoolType.AMGr2Ru);
            AuthPool2Db.AP2DOpera.GetPool(AuthPool.PoolType.AMGr2Ru);
            */
        }
        #endregion

        #region 5--选择用户，同步勾选角色
        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 选择用户，同步更改角色的勾选状态
        /// </summary>
        private void dgv_Users_SeleChanged(object sender, EventArgs e)
        {
            try
            {
                if (LoadOver)
                {
                    if (dgv_Users.SelectedRows.Count > 0)
                    {
                        string CurrUserID = dgv_Users.SelectedRows[0].Cells["User_ID"].Value.ToString();
                        //取User的对应数据
                        List<string> CurrGroupsID = ADAct.ReadPoolUs2Gr(CurrUserID);
                        for (int i = 0; i < dgv_Groups.Rows.Count; i++)
                        {
                            if (CurrGroupsID.Contains(dgv_Groups.Rows[i].Cells["Group_ID"].Value.ToString()))
                            {
                                dgv_Groups.Rows[i].Cells[0].Value = true;
                            }
                            else
                            {
                                dgv_Groups.Rows[i].Cells[0].Value = false;
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        #endregion

        #region 6--选择角色，同步勾选规则
        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 选择角色，同步更改规则的勾选状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Groups_SeleChanged(object sender, EventArgs e)
        {
            if (LoadOver)//加载完成，显示窗口后才处理事件
            {
                //当前角色的ID
                long tmpGroupID = (long)dgv_Groups.CurrentRow.Cells["Group_ID"].Value;
                //取当前角色对应的所有规则
                ADAct.SetTreeViewCheckBox(treeRules, tmpGroupID);
            }
        }
        #endregion

        #region 7--点击Groups的选择框进行的处理
        private void dgv_Groups_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 0://点击的是第一列，处理的方法
                        #region 点击的是第一列
                        if (dgv_Users.SelectedRows.Count > 0)//只有选择了用户，才进行处理
                        {
                            //取当前点击的Items的Cell
                            DataGridViewCell tmpCell = dgv_Groups.Rows[e.RowIndex].Cells[0];
                            int tmpUserID = Convert.ToInt32(dgv_Users.SelectedRows[0].Cells["User_ID"].Value);
                            int tmpGroupID = Convert.ToInt32(dgv_Groups.Rows[e.RowIndex].Cells["Group_ID"].Value);
                            //MessageBox.Show(tmpUserID.ToString() + ":" + tmpGroupID.ToString());
                            ADAct.ReadToPool(PoolType.Us2Gr);
                            DataTable tmpDt = ADAct.ReadPool(PoolType.Us2Gr);

                            if ((bool)tmpCell.Value)
                            {
                                //添加行
                                bool tmpIsAdd = true;
                                for (int i = 0; i < tmpDt.Rows.Count; i++)
                                {
                                    if (tmpDt.Rows[i]["User_ID"].ToString() == tmpUserID.ToString() && tmpDt.Rows[i]["Group_ID"].ToString() == tmpGroupID.ToString())
                                    {
                                        tmpIsAdd = false;
                                    }
                                }
                                if (tmpIsAdd)
                                {
                                    DataRow tmpRowAdd = tmpDt.NewRow();
                                    tmpRowAdd[0] = tmpUserID;
                                    tmpRowAdd[1] = tmpGroupID;
                                    tmpDt.Rows.Add(tmpRowAdd);
                                }
                            }
                            else
                            {
                                //删除行
                                int tmpIndex = 999999;
                                for (int i = 0; i < tmpDt.Rows.Count; i++)
                                {
                                    if (tmpDt.Rows[i]["User_ID"].ToString() == tmpUserID.ToString() && tmpDt.Rows[i]["Group_ID"].ToString() == tmpGroupID.ToString())
                                    {
                                        tmpIndex = i;
                                    }
                                }
                                if (!(tmpIndex == 999999))
                                {
                                    tmpDt.Rows[tmpIndex].Delete();
                                }
                            }
                            ADAct.SavePool(PoolType.Us2Gr, tmpDt);
                            ADAct.UpdatePool(PoolType.Us2Gr);
                            InitData_Us2Gr();
                        }
                        else
                        {
                            MessageBox.Show("没有选择用户，或者用户表为空,请先添加用户");
                        }
                        #endregion
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        #endregion

        #region 8--其它事件处理
        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 表示窗体第一次显示时进行处理
        /// </summary>
        private void AFAuthSet_Shown(object sender, EventArgs e)
        {
            LoadOver = true;//所有数据加载完成
        }

        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 用户单元格状态更改时处理提交表格数据
        /// </summary>
        private void dgv_Users_CellStateChange(object sender, EventArgs e)
        {
            if (this.dgv_Users.IsCurrentCellDirty)
            {
                this.dgv_Users.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 角色单元格状态更改时处理提交表格数据
        /// </summary>
        private void dgv_Groups_CellStateChange(object sender, EventArgs e)
        {
            if (this.dgv_Groups.IsCurrentCellDirty)
            {
                this.dgv_Groups.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            
        }
        #endregion

        #region 9--菜单操作

        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 显示规则与对象绑定设置窗口
        /// </summary>
        private void menu_1_1_Click(object sender, EventArgs e)
        {
            AFAuthRuleBinding tmpFm = new AFAuthRuleBinding();
            tmpFm.ShowDialog();
        }

        //-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 显示不做权限处理的对象设置窗口
        /// </summary>
        private void menu_1_2_Click(object sender, EventArgs e)
        {
            AFAuthSetItemNo tmpFm = new AFAuthSetItemNo();
            tmpFm.ShowDialog();
        }
        #endregion

    }
}
