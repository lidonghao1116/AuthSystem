using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using AuthSystem.AuthData;
using AuthSystem.AuthPool;

namespace AuthSystem.AuthForm
{
    /// <summary>
    /// 管理不进行权限管理的Items的数据的类
    /// </summary>
    public class AFAuthSetItemNo:AFBase
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

        #region 1-------初始化
        public AFAuthSetItemNo()
        {
            ADAct.ConnString = APPoolGlobal.GlobalAMSystemConfig.ConnectionString; //设置连接字符串
            InitializeComponent();  //初始化窗口
            InitData();             //初始化数据
        }
        private DataTable tmpDtItemNo;
        private DataRow tmpAddRow;
        private ADAction ADAct = new ADAction();


        #region 窗口初始化

        private System.Windows.Forms.ToolStrip toolMenu;
        private System.Windows.Forms.ToolStripButton toolAddItem;
        private System.Windows.Forms.ToolStripButton toolDelItem;
        private System.Windows.Forms.ToolStripButton toolSaveItem;
        private ToolStripButton toolMoveItems;
        private System.Windows.Forms.DataGridView dgv_ItemsNo;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFAuthSetItemNo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolMenu = new System.Windows.Forms.ToolStrip();
            this.toolAddItem = new System.Windows.Forms.ToolStripButton();
            this.toolDelItem = new System.Windows.Forms.ToolStripButton();
            this.toolSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dgv_ItemsNo = new System.Windows.Forms.DataGridView();
            this.toolMoveItems = new System.Windows.Forms.ToolStripButton();
            this.toolMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ItemsNo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolMenu
            // 
            this.toolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddItem,
            this.toolDelItem,
            this.toolSaveItem,
            this.toolMoveItems});
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
            this.toolAddItem.Click += new System.EventHandler(this.toolAddItem_Click);
            // 
            // toolDelItem
            // 
            this.toolDelItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDelItem.Image = ((System.Drawing.Image)(resources.GetObject("toolDelItem.Image")));
            this.toolDelItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelItem.Name = "toolDelItem";
            this.toolDelItem.Size = new System.Drawing.Size(62, 22);
            this.toolDelItem.Text = "删除Item";
            this.toolDelItem.Click += new System.EventHandler(this.toolDelItem_Click);
            // 
            // toolSaveItem
            // 
            this.toolSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("toolSaveItem.Image")));
            this.toolSaveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveItem.Name = "toolSaveItem";
            this.toolSaveItem.Size = new System.Drawing.Size(62, 22);
            this.toolSaveItem.Text = "保存Item";
            this.toolSaveItem.Click += new System.EventHandler(this.toolSaveItem_Click);
            // 
            // dgv_ItemsNo
            // 
            this.dgv_ItemsNo.AllowUserToAddRows = false;
            this.dgv_ItemsNo.AllowUserToResizeRows = false;
            this.dgv_ItemsNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ItemsNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ItemsNo.Location = new System.Drawing.Point(0, 25);
            this.dgv_ItemsNo.MultiSelect = false;
            this.dgv_ItemsNo.Name = "dgv_ItemsNo";
            this.dgv_ItemsNo.RowHeadersVisible = false;
            this.dgv_ItemsNo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_ItemsNo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ItemsNo.RowTemplate.Height = 23;
            this.dgv_ItemsNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ItemsNo.Size = new System.Drawing.Size(828, 543);
            this.dgv_ItemsNo.TabIndex = 1;
            // 
            // toolMoveItems
            // 
            this.toolMoveItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolMoveItems.Image = ((System.Drawing.Image)(resources.GetObject("toolMoveItems.Image")));
            this.toolMoveItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMoveItems.Name = "toolMoveItems";
            this.toolMoveItems.Size = new System.Drawing.Size(80, 22);
            this.toolMoveItems.Text = "转移到Items";
            this.toolMoveItems.Click += new System.EventHandler(this.toolMoveItems_Click);
            // 
            // AFAuthSetItemNo
            // 
            this.ClientSize = new System.Drawing.Size(828, 568);
            this.Controls.Add(this.dgv_ItemsNo);
            this.Controls.Add(this.toolMenu);
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
            ADAct.ReadToPool(PoolType.ItemsNo);
            tmpDtItemNo = ADAct.ReadPool(PoolType.ItemsNo);

            dgv_ItemsNo.DataSource = tmpDtItemNo;

            dgv_ItemsNo.Columns[0].HeaderText = "ID";
            dgv_ItemsNo.Columns[0].Width = 40;
            dgv_ItemsNo.Columns[1].HeaderText = "Item名字";
            dgv_ItemsNo.Columns[1].Width = 150;
            dgv_ItemsNo.Columns[2].HeaderText = "Item路径";
            dgv_ItemsNo.Columns[2].Width = 350;
            dgv_ItemsNo.Columns[3].HeaderText = "Item类型";
            dgv_ItemsNo.Columns[3].Width = 100;
            dgv_ItemsNo.Columns[4].HeaderText = "备注";
            dgv_ItemsNo.Columns[4].Width = 200;

        }
        #endregion
        #endregion

        #region 工具菜单的按键处理
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// 添加Item
        /// </summary>
        private void toolAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                tmpAddRow = tmpDtItemNo.NewRow();
                tmpDtItemNo.Rows.Add(tmpAddRow);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// 删除Item
        /// </summary>
        private void toolDelItem_Click(object sender, EventArgs e)
        {
            if (dgv_ItemsNo.SelectedRows.Count > 0)
            {
                dgv_ItemsNo.Rows.RemoveAt(dgv_ItemsNo.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("请选择要删除的行！");
            }
        }

        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// 保存所有Item
        /// </summary>
        private void toolSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_ItemsNo.DataSource = null;
                ADAct.SavePool(PoolType.ItemsNo, tmpDtItemNo);
                ADAct.UpdatePool(PoolType.ItemsNo);
                InitData();
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败!");
                throw;
            }
        }

        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// 转移选择的item到Items表
        /// </summary>
        private void toolMoveItems_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
