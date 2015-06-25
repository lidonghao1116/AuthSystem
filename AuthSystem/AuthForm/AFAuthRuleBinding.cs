using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AuthSystem.AuthModel;
using AuthSystem.AuthDao;

namespace AuthSystem.AuthForm
{
    public class AFAuthRuleBinding:AFBase
    {
        #region 0-------定义公共变量
        private BindingSource RulesBindingSource = new BindingSource();
        private ToolStripButton toolSaveItems;//所有Rules的绑定对象
        private BindingSource ItemsBindingSource = new BindingSource();//所有Items的绑定对象
        private List<AMItem> tmpAMItems;
        private bool itemsHasChange = false;//Items是否有更改
        private bool RulesHasChange = false;//Rules是否有更改
        private AMRule currAMRule;
        #endregion
        #region 1-------界面初始化
        public AFAuthRuleBinding()
        {
            InitializeComponent();
            InitRules();
            InitItems();
        }

        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.ToolStrip ItemstoolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel_Right;
        private System.Windows.Forms.ToolStrip RulestoolStrip;
        private System.Windows.Forms.DataGridView dgv_Items;
        private System.Windows.Forms.ToolStripButton toolDelItem;
        private System.Windows.Forms.DataGridView dgv_Rules;
        private System.Windows.Forms.ToolStripButton toolAddItem;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFAuthRuleBinding));
            this.panel_Right = new System.Windows.Forms.Panel();
            this.dgv_Items = new System.Windows.Forms.DataGridView();
            this.RulestoolStrip = new System.Windows.Forms.ToolStrip();
            this.toolAddItem = new System.Windows.Forms.ToolStripButton();
            this.toolDelItem = new System.Windows.Forms.ToolStripButton();
            this.toolSaveItems = new System.Windows.Forms.ToolStripButton();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.dgv_Rules = new System.Windows.Forms.DataGridView();
            this.ItemstoolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Items)).BeginInit();
            this.RulestoolStrip.SuspendLayout();
            this.panel_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rules)).BeginInit();
            this.ItemstoolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Right
            // 
            this.panel_Right.Controls.Add(this.dgv_Items);
            this.panel_Right.Controls.Add(this.RulestoolStrip);
            this.panel_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Right.Location = new System.Drawing.Point(561, 0);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(597, 665);
            this.panel_Right.TabIndex = 1;
            // 
            // dgv_Items
            // 
            this.dgv_Items.AllowUserToAddRows = false;
            this.dgv_Items.AllowUserToDeleteRows = false;
            this.dgv_Items.AllowUserToResizeRows = false;
            this.dgv_Items.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Items.Location = new System.Drawing.Point(0, 25);
            this.dgv_Items.MultiSelect = false;
            this.dgv_Items.Name = "dgv_Items";
            this.dgv_Items.RowHeadersVisible = false;
            this.dgv_Items.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Items.RowTemplate.Height = 23;
            this.dgv_Items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Items.Size = new System.Drawing.Size(597, 640);
            this.dgv_Items.TabIndex = 1;
            this.dgv_Items.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Items_CellValueChanged);
            this.dgv_Items.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_Items_DirtyState);
            // 
            // RulestoolStrip
            // 
            this.RulestoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddItem,
            this.toolDelItem,
            this.toolSaveItems});
            this.RulestoolStrip.Location = new System.Drawing.Point(0, 0);
            this.RulestoolStrip.Name = "RulestoolStrip";
            this.RulestoolStrip.Size = new System.Drawing.Size(597, 25);
            this.RulestoolStrip.TabIndex = 0;
            this.RulestoolStrip.Text = "toolStrip1";
            // 
            // toolAddItem
            // 
            this.toolAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
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
            // toolSaveItems
            // 
            this.toolSaveItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSaveItems.Image = ((System.Drawing.Image)(resources.GetObject("toolSaveItems.Image")));
            this.toolSaveItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveItems.Name = "toolSaveItems";
            this.toolSaveItems.Size = new System.Drawing.Size(36, 22);
            this.toolSaveItems.Text = "保存";
            this.toolSaveItems.Click += new System.EventHandler(this.toolSaveItems_Click);
            // 
            // panel_Left
            // 
            this.panel_Left.Controls.Add(this.dgv_Rules);
            this.panel_Left.Controls.Add(this.ItemstoolStrip);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Left.Location = new System.Drawing.Point(0, 0);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(1158, 665);
            this.panel_Left.TabIndex = 0;
            // 
            // dgv_Rules
            // 
            this.dgv_Rules.AllowUserToAddRows = false;
            this.dgv_Rules.AllowUserToDeleteRows = false;
            this.dgv_Rules.AllowUserToResizeRows = false;
            this.dgv_Rules.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv_Rules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Rules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Rules.Location = new System.Drawing.Point(0, 25);
            this.dgv_Rules.MultiSelect = false;
            this.dgv_Rules.Name = "dgv_Rules";
            this.dgv_Rules.RowHeadersVisible = false;
            this.dgv_Rules.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Rules.RowTemplate.Height = 23;
            this.dgv_Rules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Rules.Size = new System.Drawing.Size(1158, 640);
            this.dgv_Rules.TabIndex = 1;
            this.dgv_Rules.SelectionChanged += new System.EventHandler(this.dgv_Rules_SeleChanged);
            // 
            // ItemstoolStrip
            // 
            this.ItemstoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.ItemstoolStrip.Location = new System.Drawing.Point(0, 0);
            this.ItemstoolStrip.Name = "ItemstoolStrip";
            this.ItemstoolStrip.Size = new System.Drawing.Size(1158, 25);
            this.ItemstoolStrip.TabIndex = 0;
            this.ItemstoolStrip.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // AFAuthRuleBinding
            // 
            this.ClientSize = new System.Drawing.Size(1158, 665);
            this.Controls.Add(this.panel_Right);
            this.Controls.Add(this.panel_Left);
            this.Name = "AFAuthRuleBinding";
            this.panel_Right.ResumeLayout(false);
            this.panel_Right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Items)).EndInit();
            this.RulestoolStrip.ResumeLayout(false);
            this.RulestoolStrip.PerformLayout();
            this.panel_Left.ResumeLayout(false);
            this.panel_Left.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rules)).EndInit();
            this.ItemstoolStrip.ResumeLayout(false);
            this.ItemstoolStrip.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region 2-------自定义初始化
        //1-初始化Rules数据表内容-------------------------------------------------------------------------------------
        private void InitRules()
        {
            List<AMRule> tmpAMRules = ADAuthOpera.GetAuthRules();
            RulesBindingSource.DataSource = typeof(AMRule);
            RulesBindingSource.DataSource = tmpAMRules;
            dgv_Rules.DataSource = RulesBindingSource;
        }

        //2-初始化Items数据表内容-------------------------------------------------------------------------------------
        private void InitItems()
        {
            tmpAMItems = ADAuthOpera.GetAuthItems();
            ItemsBindingSource.DataSource = typeof(AMItem);
            ItemsBindingSource.DataSource = tmpAMItems;
            DataGridViewCheckBoxColumn ItemsDGVCBC = new DataGridViewCheckBoxColumn(false);
            ItemsDGVCBC.Name = "SeleItem";
            ItemsDGVCBC.HeaderText = "选择";
            ItemsDGVCBC.Width = 40;
            dgv_Items.Columns.Add(ItemsDGVCBC);
            dgv_Items.DataSource = ItemsBindingSource;
            dgv_Items.Columns[1].Width = 30;
            dgv_Items.Columns[1].HeaderText = "ID";
            dgv_Items.Columns[2].Width = 100;
            dgv_Items.Columns[2].HeaderText = "Item名字";
            dgv_Items.Columns[3].Width = 300;
            dgv_Items.Columns[3].HeaderText = "Item路径";
            dgv_Items.Columns[4].Width = 100;
            dgv_Items.Columns[4].HeaderText = "备注";
        }

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        #region Items按键处理
        /// <summary>
        /// 添加Item行
        /// </summary>
        private void toolAddItem_Click(object sender, EventArgs e)
        {
            ItemsBindingSource.AddNew();
        }
        /// <summary>
        /// 删除Item行
        /// </summary>
        private void toolDelItem_Click(object sender, EventArgs e)
        {
            
            if (dgv_Items.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            else
            {
                //取当前选择行
                int currRow = dgv_Items.SelectedRows[0].Index;
                ItemsBindingSource.RemoveAt(currRow);
            }
        }
        /// <summary>
        /// 保存所有Item
        /// </summary>
        private void toolSaveItems_Click(object sender, EventArgs e)
        {
            List<AMItem> tmpAMItemsSave = new List<AMItem>();
            tmpAMItemsSave = (List<AMItem>)ItemsBindingSource.DataSource;
            if (AuthDao.ADAuthOpera.SaveAuthItems(tmpAMItemsSave))
                MessageBox.Show("Items保存成功!");
            else
                MessageBox.Show("Items保存失败");
        }
        #endregion

        #region Rules项选择切换处理
        /// <summary>
        /// 切换Rules选择项时，同步更改Items的选择项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Rules_SeleChanged(object sender, EventArgs e)
        {
            if (dgv_Rules.SelectedRows.Count > 0)
            {
                //当前选择的规则对象
                currAMRule=(AMRule)RulesBindingSource[dgv_Rules.SelectedRows[0].Index];
                List<AMItem> currItems = new List<AMItem>();
                currItems = AuthDao.ADAuthOpera.GetAuthItems(currAMRule);
                List<string> currItemsID = new List<string>();
                for (int x = 0; x < dgv_Items.Rows.Count; x++)
                {
                    dgv_Items.Rows[x].Cells[0].Value = false;
                }

                foreach (AMItem x in currItems)
                {
                    currItemsID.Add(x.Item_ID);
                }
                for (int x = 0; x < dgv_Items.Rows.Count; x++)
                {
                    if (currItemsID.Contains(dgv_Items.Rows[x].Cells[1].Value.ToString()))
                    {
                        dgv_Items.Rows[x].Cells[0].Value = true;
                    }
                    else
                    {
                        dgv_Items.Rows[x].Cells[0].Value = false;
                    }
                }
            }
        }
        #endregion

        #region Items 勾选与取消勾选时，对所选Rules对应的Items进行更改
        private void dgv_Items_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show(dgv_Items.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                //当前选择的Rule
                //保存dgv_Items勾选的对象到当前选择的Rule

            }
        }
        /// <summary>
        /// 两步提交datagridview数据，不然勾选事件不能实时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Items_DirtyState(object sender, EventArgs e)
        {
            if (dgv_Items.IsCurrentCellDirty)
            {
                dgv_Items.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #endregion
        
    }
}
