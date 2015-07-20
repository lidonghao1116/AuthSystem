namespace MainForm
{
    partial class MainForm
    {
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_isSave = new System.Windows.Forms.CheckBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.tb_Status = new System.Windows.Forms.TextBox();
            this.ReadConfig = new System.Windows.Forms.Button();
            this.SaveConfig = new System.Windows.Forms.Button();
            this.tb_Conn = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Form_AuthSet = new System.Windows.Forms.Button();
            this.Form_RuleItem = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bt_SetPass = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.权限管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.成色资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.款式资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供应商资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.品牌资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仓库资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.石料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 628);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 203);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.cb_isSave);
            this.panel2.Controls.Add(this.tb_password);
            this.panel2.Controls.Add(this.tb_Username);
            this.panel2.Controls.Add(this.tb_Status);
            this.panel2.Controls.Add(this.ReadConfig);
            this.panel2.Controls.Add(this.SaveConfig);
            this.panel2.Controls.Add(this.tb_Conn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(317, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 203);
            this.panel2.TabIndex = 1;
            // 
            // cb_isSave
            // 
            this.cb_isSave.AutoSize = true;
            this.cb_isSave.Location = new System.Drawing.Point(13, 84);
            this.cb_isSave.Name = "cb_isSave";
            this.cb_isSave.Size = new System.Drawing.Size(72, 16);
            this.cb_isSave.TabIndex = 6;
            this.cb_isSave.Text = "记住密码";
            this.cb_isSave.UseVisualStyleBackColor = true;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(4, 57);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(270, 21);
            this.tb_password.TabIndex = 5;
            this.tb_password.Text = "PassWord";
            // 
            // tb_Username
            // 
            this.tb_Username.Location = new System.Drawing.Point(4, 30);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(270, 21);
            this.tb_Username.TabIndex = 4;
            this.tb_Username.Text = "UserName";
            // 
            // tb_Status
            // 
            this.tb_Status.Location = new System.Drawing.Point(3, 129);
            this.tb_Status.Name = "tb_Status";
            this.tb_Status.Size = new System.Drawing.Size(302, 21);
            this.tb_Status.TabIndex = 3;
            this.tb_Status.Text = "状态";
            // 
            // ReadConfig
            // 
            this.ReadConfig.Location = new System.Drawing.Point(91, 156);
            this.ReadConfig.Name = "ReadConfig";
            this.ReadConfig.Size = new System.Drawing.Size(79, 44);
            this.ReadConfig.TabIndex = 2;
            this.ReadConfig.Text = "读取配置";
            this.ReadConfig.UseVisualStyleBackColor = true;
            this.ReadConfig.Click += new System.EventHandler(this.ReadConfig_Click);
            // 
            // SaveConfig
            // 
            this.SaveConfig.Location = new System.Drawing.Point(4, 156);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(81, 44);
            this.SaveConfig.TabIndex = 1;
            this.SaveConfig.Text = "保存配置";
            this.SaveConfig.UseVisualStyleBackColor = true;
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // tb_Conn
            // 
            this.tb_Conn.Location = new System.Drawing.Point(3, 3);
            this.tb_Conn.Name = "tb_Conn";
            this.tb_Conn.Size = new System.Drawing.Size(271, 21);
            this.tb_Conn.TabIndex = 0;
            this.tb_Conn.Text = "ConnString";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RosyBrown;
            this.panel3.Controls.Add(this.Form_AuthSet);
            this.panel3.Controls.Add(this.Form_RuleItem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(631, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 203);
            this.panel3.TabIndex = 2;
            // 
            // Form_AuthSet
            // 
            this.Form_AuthSet.Location = new System.Drawing.Point(18, 38);
            this.Form_AuthSet.Name = "Form_AuthSet";
            this.Form_AuthSet.Size = new System.Drawing.Size(75, 23);
            this.Form_AuthSet.TabIndex = 1;
            this.Form_AuthSet.Text = "权限设置";
            this.Form_AuthSet.UseVisualStyleBackColor = true;
            this.Form_AuthSet.Click += new System.EventHandler(this.Form_AuthSet_Click);
            // 
            // Form_RuleItem
            // 
            this.Form_RuleItem.Location = new System.Drawing.Point(18, 9);
            this.Form_RuleItem.Name = "Form_RuleItem";
            this.Form_RuleItem.Size = new System.Drawing.Size(132, 23);
            this.Form_RuleItem.TabIndex = 0;
            this.Form_RuleItem.Text = "规则对象对应设置";
            this.Form_RuleItem.UseVisualStyleBackColor = true;
            this.Form_RuleItem.Click += new System.EventHandler(this.Form_RuleItem_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel4.Controls.Add(this.bt_SetPass);
            this.panel4.Controls.Add(this.menuStrip1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 212);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(308, 203);
            this.panel4.TabIndex = 3;
            // 
            // bt_SetPass
            // 
            this.bt_SetPass.Location = new System.Drawing.Point(9, 40);
            this.bt_SetPass.Name = "bt_SetPass";
            this.bt_SetPass.Size = new System.Drawing.Size(75, 23);
            this.bt_SetPass.TabIndex = 1;
            this.bt_SetPass.Text = "设置密码";
            this.bt_SetPass.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统设置ToolStripMenuItem,
            this.基本资料ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(308, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.权限管理ToolStripMenuItem,
            this.用户管理ToolStripMenuItem,
            this.连接设置ToolStripMenuItem,
            this.设置密码ToolStripMenuItem});
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 权限管理ToolStripMenuItem
            // 
            this.权限管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询ToolStripMenuItem,
            this.修改ToolStripMenuItem});
            this.权限管理ToolStripMenuItem.Name = "权限管理ToolStripMenuItem";
            this.权限管理ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.权限管理ToolStripMenuItem.Text = "权限管理";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            // 
            // 连接设置ToolStripMenuItem
            // 
            this.连接设置ToolStripMenuItem.Name = "连接设置ToolStripMenuItem";
            this.连接设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.连接设置ToolStripMenuItem.Text = "连接设置";
            // 
            // 设置密码ToolStripMenuItem
            // 
            this.设置密码ToolStripMenuItem.Name = "设置密码ToolStripMenuItem";
            this.设置密码ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设置密码ToolStripMenuItem.Text = "设置密码";
            // 
            // 基本资料ToolStripMenuItem
            // 
            this.基本资料ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.成色资料ToolStripMenuItem,
            this.款式资料ToolStripMenuItem,
            this.属性资料ToolStripMenuItem,
            this.供应商资料ToolStripMenuItem,
            this.品牌资料ToolStripMenuItem,
            this.仓库资料ToolStripMenuItem,
            this.商品分类ToolStripMenuItem,
            this.toolStripSeparator1,
            this.石料ToolStripMenuItem});
            this.基本资料ToolStripMenuItem.Name = "基本资料ToolStripMenuItem";
            this.基本资料ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.基本资料ToolStripMenuItem.Text = "基本资料";
            // 
            // 成色资料ToolStripMenuItem
            // 
            this.成色资料ToolStripMenuItem.Name = "成色资料ToolStripMenuItem";
            this.成色资料ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.成色资料ToolStripMenuItem.Text = "成色资料";
            // 
            // 款式资料ToolStripMenuItem
            // 
            this.款式资料ToolStripMenuItem.Name = "款式资料ToolStripMenuItem";
            this.款式资料ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.款式资料ToolStripMenuItem.Text = "款式资料";
            // 
            // 属性资料ToolStripMenuItem
            // 
            this.属性资料ToolStripMenuItem.Name = "属性资料ToolStripMenuItem";
            this.属性资料ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.属性资料ToolStripMenuItem.Text = "属性资料";
            // 
            // 供应商资料ToolStripMenuItem
            // 
            this.供应商资料ToolStripMenuItem.Name = "供应商资料ToolStripMenuItem";
            this.供应商资料ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.供应商资料ToolStripMenuItem.Text = "供应商资料";
            // 
            // 品牌资料ToolStripMenuItem
            // 
            this.品牌资料ToolStripMenuItem.Name = "品牌资料ToolStripMenuItem";
            this.品牌资料ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.品牌资料ToolStripMenuItem.Text = "品牌资料";
            // 
            // 仓库资料ToolStripMenuItem
            // 
            this.仓库资料ToolStripMenuItem.Name = "仓库资料ToolStripMenuItem";
            this.仓库资料ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.仓库资料ToolStripMenuItem.Text = "仓库资料";
            // 
            // 商品分类ToolStripMenuItem
            // 
            this.商品分类ToolStripMenuItem.Name = "商品分类ToolStripMenuItem";
            this.商品分类ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.商品分类ToolStripMenuItem.Text = "商品分类";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // 石料ToolStripMenuItem
            // 
            this.石料ToolStripMenuItem.Name = "石料ToolStripMenuItem";
            this.石料ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.石料ToolStripMenuItem.Text = "石料";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(317, 212);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(308, 203);
            this.listBox1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(631, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 628);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "权限测试程序";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_Conn;
        private System.Windows.Forms.Button ReadConfig;
        private System.Windows.Forms.Button SaveConfig;
        private System.Windows.Forms.TextBox tb_Status;
        private System.Windows.Forms.CheckBox cb_isSave;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Form_RuleItem;
        private System.Windows.Forms.Button Form_AuthSet;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 权限管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基本资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 成色资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 款式资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 供应商资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 品牌资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仓库资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 石料ToolStripMenuItem;
        private System.Windows.Forms.Button bt_SetPass;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
    }
}

