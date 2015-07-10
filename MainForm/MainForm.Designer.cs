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
            this.Form_RuleItem = new System.Windows.Forms.Button();
            this.Form_AuthSet = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 628);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "权限测试程序";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
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
    }
}

