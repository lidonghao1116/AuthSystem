using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AuthSystem.AuthPool2Soft;
using System.Windows.Forms;

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
        private DataTable tmpDtItemNo;
        private DataRow tmpAddRow;

        #region 窗口初始化

        private System.Windows.Forms.ToolStrip toolMenu;
        private System.Windows.Forms.ToolStripButton toolAddItem;
        private System.Windows.Forms.ToolStripButton toolDelItem;
        private System.Windows.Forms.ToolStripButton toolSaveItem;
        private System.Windows.Forms.DataGridView dgv_ItemsNo;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFAuthSetItemNo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_ItemsNo.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ItemsNo.RowTemplate.Height = 23;
            this.dgv_ItemsNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ItemsNo.Size = new System.Drawing.Size(828, 543);
            this.dgv_ItemsNo.TabIndex = 1;
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
            //更新ItemsNo的数据池
            AuthSystem.AuthPool2Db.AP2DOpera.GetPool(AuthPool.APPoolType.AMItemsNo);
            //从数据池取数据
            tmpDtItemNo = AP2SOpera.ReadPool(AuthPool.APPoolType.AMItemsNo);
            dgv_ItemsNo.DataSource = tmpDtItemNo;
            tmpAddRow = tmpDtItemNo.NewRow();
            dgv_ItemsNo.Columns[0].Visible = false;
            dgv_ItemsNo.Columns[1].HeaderText = "ID";
            dgv_ItemsNo.Columns[1].Width = 40;
            dgv_ItemsNo.Columns[2].HeaderText = "Item名字";
            dgv_ItemsNo.Columns[2].Width = 150;
            dgv_ItemsNo.Columns[3].HeaderText = "Item路径";
            dgv_ItemsNo.Columns[3].Width = 350;
            dgv_ItemsNo.Columns[4].HeaderText = "备注";
            dgv_ItemsNo.Columns[4].Width = 300;

        }
        #endregion
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// 添加Item
        /// </summary>
        private void toolAddItem_Click(object sender, EventArgs e)
        {
            tmpDtItemNo.Rows.Add(tmpAddRow);
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
                dgv_ItemsNo.DataSource = tmpDtItemNo;
                //先保存到数据池
                AP2SOpera.SavePool(tmpDtItemNo, AuthPool.APPoolType.AMItemsNo);
                //再提交数据池更新
                AuthPool2Db.AP2DOpera.UpdatePool(AuthPool.APPoolType.AMItemsNo);
                InitData();
                MessageBox.Show("保存成功！");
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败!");
                throw;
            }
        }
    }
}
