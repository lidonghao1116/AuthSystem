namespace AddSql
{
    partial class Form1
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
            this.dgv_Value = new System.Windows.Forms.DataGridView();
            this.bt_GetConn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Value)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Value
            // 
            this.dgv_Value.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Value.Location = new System.Drawing.Point(2, 3);
            this.dgv_Value.Name = "dgv_Value";
            this.dgv_Value.RowTemplate.Height = 23;
            this.dgv_Value.Size = new System.Drawing.Size(529, 447);
            this.dgv_Value.TabIndex = 0;
            // 
            // bt_GetConn
            // 
            this.bt_GetConn.Location = new System.Drawing.Point(555, 12);
            this.bt_GetConn.Name = "bt_GetConn";
            this.bt_GetConn.Size = new System.Drawing.Size(75, 23);
            this.bt_GetConn.TabIndex = 1;
            this.bt_GetConn.Text = "button1";
            this.bt_GetConn.UseVisualStyleBackColor = true;
            this.bt_GetConn.Click += new System.EventHandler(this.bt_GetConn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 553);
            this.Controls.Add(this.bt_GetConn);
            this.Controls.Add(this.dgv_Value);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Value;
        private System.Windows.Forms.Button bt_GetConn;
    }
}

