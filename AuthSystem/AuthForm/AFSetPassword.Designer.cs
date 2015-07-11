namespace AuthSystem.AuthForm
{
    partial class AFSetPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_Quit = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.tb_2Password = new System.Windows.Forms.TextBox();
            this.tb_1Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_UserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_Quit
            // 
            this.bt_Quit.Location = new System.Drawing.Point(143, 131);
            this.bt_Quit.Name = "bt_Quit";
            this.bt_Quit.Size = new System.Drawing.Size(90, 40);
            this.bt_Quit.TabIndex = 17;
            this.bt_Quit.Text = "取消";
            this.bt_Quit.UseVisualStyleBackColor = true;
            this.bt_Quit.Click += new System.EventHandler(this.bt_Quit_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(12, 131);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(90, 40);
            this.bt_Save.TabIndex = 16;
            this.bt_Save.Text = "更改";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // tb_2Password
            // 
            this.tb_2Password.Location = new System.Drawing.Point(81, 104);
            this.tb_2Password.Name = "tb_2Password";
            this.tb_2Password.PasswordChar = '*';
            this.tb_2Password.Size = new System.Drawing.Size(152, 21);
            this.tb_2Password.TabIndex = 15;
            // 
            // tb_1Password
            // 
            this.tb_1Password.Location = new System.Drawing.Point(81, 77);
            this.tb_1Password.Name = "tb_1Password";
            this.tb_1Password.PasswordChar = '*';
            this.tb_1Password.Size = new System.Drawing.Size(152, 21);
            this.tb_1Password.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "重复密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "密    码：";
            // 
            // lb_UserName
            // 
            this.lb_UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_UserName.ForeColor = System.Drawing.Color.Maroon;
            this.lb_UserName.Location = new System.Drawing.Point(77, 13);
            this.lb_UserName.Name = "lb_UserName";
            this.lb_UserName.Size = new System.Drawing.Size(65, 22);
            this.lb_UserName.TabIndex = 11;
            this.lb_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(142, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "的密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "更改";
            // 
            // AFSetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 181);
            this.Controls.Add(this.bt_Quit);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.tb_2Password);
            this.Controls.Add(this.tb_1Password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_UserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFSetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Quit;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.TextBox tb_2Password;
        private System.Windows.Forms.TextBox tb_1Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}