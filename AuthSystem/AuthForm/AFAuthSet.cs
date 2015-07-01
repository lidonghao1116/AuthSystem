using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using AuthSystem.AuthPool2Soft;


namespace AuthSystem.AuthForm
{
    /// <summary>
    /// 用户与角色权限管理模块
    /// </summary>
    public class AFAuthSet:AFBase
    {
        #region 0-----公共变量
        private DataTable Users_DataTable;
        private DataTable Groups_DataTable;
        private DataTable Rules_DataTable;
        private DataTable Ru2It_DataTable;
        private DataRow tmpUsersAddRow;
        private DataRow tmpGroupsAddRow;
        #endregion

        #region 1-----初始化
        /// <summary>
        /// 构造函数
        /// </summary>
        public AFAuthSet()
        {
            InitializeComponent();  //界面初始化
            InitData_Users();       //用户初始化
            InitData_Groups();      //角色初始化
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
            this.panelGroups = new System.Windows.Forms.Panel();
            this.dgv_Groups = new System.Windows.Forms.DataGridView();
            this.toolGroups = new System.Windows.Forms.ToolStrip();
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
            // 
            // toolUsers
            // 
            this.toolUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolUsersAdd,
            this.toolUsersDel,
            this.toolUsersSave});
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
            // 
            // toolGroups
            // 
            this.toolGroups.Location = new System.Drawing.Point(0, 0);
            this.toolGroups.Name = "toolGroups";
            this.toolGroups.Size = new System.Drawing.Size(579, 25);
            this.toolGroups.TabIndex = 0;
            this.toolGroups.Text = "toolStrip2";
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
            this.layoutMain.ResumeLayout(false);
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Users)).EndInit();
            this.toolUsers.ResumeLayout(false);
            this.toolUsers.PerformLayout();
            this.panelGroups.ResumeLayout(false);
            this.panelGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Groups)).EndInit();
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
            AuthPool2Db.AP2DOpera.GetPool(AuthPool.APPoolType.AMUsers);
            Users_DataTable = AP2SOpera.ReadPool(AuthPool.APPoolType.AMUsers); //从pool取DataTable
            dgv_Users.DataSource = Users_DataTable;                             //显示DataTable
            tmpUsersAddRow = Users_DataTable.NewRow();
            //列重命名
            dgv_Users.Columns[0].Visible = false;
            dgv_Users.Columns[1].HeaderText = "ID";
            dgv_Users.Columns[1].Width = 30;
            dgv_Users.Columns[2].HeaderText = "登陆名";
            dgv_Users.Columns[2].Width = 80;
            dgv_Users.Columns[3].HeaderText = "名字";
            dgv_Users.Columns[3].Width = 80;
            dgv_Users.Columns[4].HeaderText = "密码";
            dgv_Users.Columns[4].Width = 80;
            dgv_Users.Columns[5].HeaderText = "电话";
            dgv_Users.Columns[5].Width = 80;
            dgv_Users.Columns[6].HeaderText = "QQ";
            dgv_Users.Columns[6].Width = 80;
            dgv_Users.Columns[7].HeaderText = "Email";
            dgv_Users.Columns[7].Width = 80;
            dgv_Users.Columns[8].HeaderText = "状态";
            dgv_Users.Columns[8].Width = 40;
            dgv_Users.Columns[8].ValueType = typeof(bool);
            dgv_Users.Columns[9].HeaderText = "角色";
            dgv_Users.Columns[9].Width = 60;
            dgv_Users.Columns[10].HeaderText = "仓库";
            dgv_Users.Columns[10].Width = 80;
            dgv_Users.Columns[11].HeaderText = "备注";
            dgv_Users.Columns[11].Width = 100;
            
        }
        /// <summary>
        /// 初始化角色数据
        /// </summary>
        private void InitData_Groups()
        {
            AuthPool2Db.AP2DOpera.GetPool(AuthPool.APPoolType.AMGroups);
            Groups_DataTable = AP2SOpera.ReadPool(AuthPool.APPoolType.AMGroups);
            dgv_Groups.DataSource = Groups_DataTable;
            tmpGroupsAddRow = Groups_DataTable.NewRow();
            dgv_Groups.Columns[0].Visible = false;
            dgv_Groups.Columns[1].HeaderText = "ID";
            dgv_Groups.Columns[1].Width = 30;
            dgv_Groups.Columns[2].HeaderText = "角色名";
            dgv_Groups.Columns[2].Width = 80;
            dgv_Groups.Columns[3].HeaderText = "状态";
            dgv_Groups.Columns[3].Width = 40;
            dgv_Groups.Columns[4].HeaderText = "规则ID";
            dgv_Groups.Columns[4].Width = 80;
            dgv_Groups.Columns[5].HeaderText = "仓库ID";
            dgv_Groups.Columns[5].Width = 80;
            dgv_Groups.Columns[6].HeaderText = "菜单ID";
            dgv_Groups.Columns[6].Width = 80;
            dgv_Groups.Columns[7].HeaderText = "备注";
            dgv_Groups.Columns[7].Width = 150;
        }
        /// <summary>
        /// 初始化规则数据
        /// </summary>
        private void InitData_Rules()
        {
            AuthPool2Db.AP2DOpera.GetPool(AuthPool.APPoolType.AMRules);
            Rules_DataTable = AP2SOpera.ReadPool(AuthPool.APPoolType.AMRules);
            AuthPool2Db.AP2DOpera.GetPool(AuthPool.APPoolType.AMRu2It);
            Ru2It_DataTable = AP2SOpera.ReadPool(AuthPool.APPoolType.AMRu2It);
        }
        
        #endregion
        #endregion

        #region 3--用户工具按钮操作
        /// <summary>
        /// 添加用户行
        /// </summary>
        private void toolUsersAdd_Click(object sender, EventArgs e)
        {
            tmpUsersAddRow[0] = 0;
            tmpUsersAddRow[8] = true;
            Users_DataTable.Rows.Add(tmpUsersAddRow);
        }
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
        /// <summary>
        /// 保存用户表的更改
        /// </summary>
        private void toolUsersSave_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_Users.DataSource = Users_DataTable;
                AP2SOpera.SavePool(Users_DataTable, AuthPool.APPoolType.AMUsers);
                AuthPool2Db.AP2DOpera.UpdatePool(AuthPool.APPoolType.AMUsers);
                MessageBox.Show("保存成功!");
                InitData_Users();
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败!");
                throw;
            }
        }
        #endregion

        #region 9--菜单操作
        /// <summary>
        /// 显示规则与对象绑定设置窗口
        /// </summary>
        private void menu_1_1_Click(object sender, EventArgs e)
        {
            AFAuthRuleBinding tmpFm = new AFAuthRuleBinding();
            tmpFm.ShowDialog();
        }

        /// <summary>
        /// 显示不做权限处理的对象设置窗口
        /// </summary>
        private void menu_1_2_Click(object sender, EventArgs e)
        {
            AFAuthSetItemNo tmpFm = new AFAuthSetItemNo();
            tmpFm.ShowDialog();
        }
        #endregion


        private void dgv_Users_CellStateChange(object sender, EventArgs e)
        {
            if (this.dgv_Users.IsCurrentCellDirty)
            {
                this.dgv_Users.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

    }
}
