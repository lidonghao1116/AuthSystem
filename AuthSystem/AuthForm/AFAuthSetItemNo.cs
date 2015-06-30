using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AuthSystem.AuthPool2Soft;

namespace AuthSystem.AuthForm
{
    /// <summary>
    /// 管理不进行权限管理的Items的数据的类
    /// </summary>
    public class AFAuthSetItemNo:AFBase
    {
        public AFAuthSetItemNo()
        {
            InitializeComponent();  //初始化窗口
            InitData();             //初始化数据
        }


        #region 窗口初始化

        private System.Windows.Forms.ToolStrip toolMenu;
        private System.Windows.Forms.ToolStripButton toolAddItem;
        private System.Windows.Forms.ToolStripButton toolDelItem;
        private System.Windows.Forms.ToolStripButton toolSaveItem;
        private System.Windows.Forms.DataGridView dgv_ItemsNo;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFAuthSetItemNo));
            this.toolMenu = new System.Windows.Forms.ToolStrip();
            this.toolAddItem = new System.Windows.Forms.ToolStripButton();
            this.toolDelItem = new System.Windows.Forms.ToolStripButton();
            this.toolSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dgv_ItemsNo = new System.Windows.Forms.DataGridView();
            this.toolMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ItemsNo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolMenu
            // 
            this.toolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddItem,
            this.toolDelItem,
            this.toolSaveItem});
            this.toolMenu.Location = new System.Drawing.Point(0, 0);
            this.toolMenu.Name = "toolMenu";
            this.toolMenu.Size = new System.Drawing.Size(828, 25);
            this.toolMenu.TabIndex = 0;
            this.toolMenu.Text = "toolStrip1";
            // 
            // toolAddItem
            // 
            this.toolAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolAddItem.Image = ((System.Drawing.Image)(resources.GetObject("toolAddItem.Image")));
            this.toolAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddItem.Name = "toolAddItem";
            this.toolAddItem.Size = new System.Drawing.Size(62, 22);
            this.toolAddItem.Text = "添加Item";
            // 
            // toolDelItem
            // 
            this.toolDelItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDelItem.Image = ((System.Drawing.Image)(resources.GetObject("toolDelItem.Image")));
            this.toolDelItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelItem.Name = "toolDelItem";
            this.toolDelItem.Size = new System.Drawing.Size(62, 22);
            this.toolDelItem.Text = "删除Item";
            // 
            // toolSaveItem
            // 
            this.toolSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("toolSaveItem.Image")));
            this.toolSaveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveItem.Name = "toolSaveItem";
            this.toolSaveItem.Size = new System.Drawing.Size(62, 22);
            this.toolSaveItem.Text = "保存Item";
            // 
            // dgv_ItemsNo
            // 
            this.dgv_ItemsNo.AllowUserToAddRows = false;
            this.dgv_ItemsNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ItemsNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ItemsNo.Location = new System.Drawing.Point(0, 25);
            this.dgv_ItemsNo.Name = "dgv_ItemsNo";
            this.dgv_ItemsNo.RowTemplate.Height = 23;
            this.dgv_ItemsNo.Size = new System.Drawing.Size(828, 543);
            this.dgv_ItemsNo.TabIndex = 1;
            // 
            // AFAuthSetItemNo
            // 
            this.ClientSize = new System.Drawing.Size(828, 568);
            this.Controls.Add(this.dgv_ItemsNo);
            this.Controls.Add(this.toolMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFAuthSetItemNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置不进行权限管理的对象";
            this.toolMenu.ResumeLayout(false);
            this.toolMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ItemsNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region 数据初始化
        private void InitData()
        {
            //更新ItemsNo的数据池
            AuthSystem.AuthPool2Db.AP2DOpera.GetPool(AuthPool.APPoolType.AMItems);
            //从数据池取数据
            DataTable tmpDtItemNo = AP2SOpera.ReadPool(AuthPool.APPoolType.AMItems);

        }
        #endregion
    }
}
