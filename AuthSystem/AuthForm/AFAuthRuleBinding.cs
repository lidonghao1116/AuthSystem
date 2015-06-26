using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AuthSystem.AuthModel;
using AuthSystem.AuthDao;

namespace AuthSystem.AuthForm
{
    public class AFAuthRuleBinding : AFBase
    {
        #region 0-------定义公共变量
        private BindingSource RulesBindingSource = new BindingSource();//所有Rules的绑定对象
        private ToolStripButton toolSaveItems;
        private BindingSource ItemsBindingSource = new BindingSource();//所有Items的绑定对象
        private bool itemsHasChange = false;//Items是否有更改
        private bool RulesHasChange = false;//Rules是否有更改
        private AMRule currAMRule;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;        //当前选择的Rule
        private bool LoadOver = false;
        #endregion

        #region 1-------初始化
        public AFAuthRuleBinding()
        {
            InitializeComponent(); //初始化界面
            InitRules();  //初始化规则表
            InitItems();  //初始化对象表
            LoadOver = true;//表示初始化完成
        }
        #region 初始化界面
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.ToolStrip ItemstoolStrip;
        private System.Windows.Forms.ToolStripButton toolSaveRu2It;
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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolSaveRu2It = new System.Windows.Forms.ToolStripButton();
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
            this.panel_Right.Location = new System.Drawing.Point(458, 0);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(517, 574);
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
            this.dgv_Items.Size = new System.Drawing.Size(517, 549);
            this.dgv_Items.TabIndex = 1;
            // 
            // RulestoolStrip
            // 
            this.RulestoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddItem,
            this.toolDelItem,
            this.toolSaveItems});
            this.RulestoolStrip.Location = new System.Drawing.Point(0, 0);
            this.RulestoolStrip.Name = "RulestoolStrip";
            this.RulestoolStrip.Size = new System.Drawing.Size(517, 25);
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
            this.panel_Left.Size = new System.Drawing.Size(975, 574);
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
            this.dgv_Rules.Size = new System.Drawing.Size(975, 549);
            this.dgv_Rules.TabIndex = 1;
            this.dgv_Rules.SelectionChanged += new System.EventHandler(this.dgv_Rules_SeleChanged);
            // 
            // ItemstoolStrip
            // 
            this.ItemstoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolSaveRu2It});
            this.ItemstoolStrip.Location = new System.Drawing.Point(0, 0);
            this.ItemstoolStrip.Name = "ItemstoolStrip";
            this.ItemstoolStrip.Size = new System.Drawing.Size(975, 25);
            this.ItemstoolStrip.TabIndex = 0;
            this.ItemstoolStrip.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton1.Text = "添加Rule";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton2.Text = "删除Rule";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton3.Text = "保存Rule";
            // 
            // toolSaveRu2It
            // 
            this.toolSaveRu2It.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSaveRu2It.Image = ((System.Drawing.Image)(resources.GetObject("toolSaveRu2It.Image")));
            this.toolSaveRu2It.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveRu2It.Name = "toolSaveRu2It";
            this.toolSaveRu2It.Size = new System.Drawing.Size(60, 22);
            this.toolSaveRu2It.Text = "保存关系";
            this.toolSaveRu2It.Click += new System.EventHandler(this.toolSaveRu2It_Click);
            // 
            // AFAuthRuleBinding
            // 
            this.ClientSize = new System.Drawing.Size(975, 574);
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

        #region 初始化数据
        //1-初始化Rules数据表内容-------------------------------------------------------------------------------------
        /// <summary>
        /// 初始化Rules数据表内容
        /// </summary>
        private void InitRules()
        {
            List<AMRule> tmpAMRules = ADAuthOpera.GetAuthRules();
            RulesBindingSource.DataSource = typeof(AMRule);
            RulesBindingSource.DataSource = tmpAMRules;
            dgv_Rules.DataSource = RulesBindingSource;
            dgv_Rules.Columns[0].HeaderText = "ID";
            dgv_Rules.Columns[0].Width = 30;
            dgv_Rules.Columns[1].HeaderText = "Rule名字";
            dgv_Rules.Columns[1].Width = 100;
            dgv_Rules.Columns[2].Visible = false;
            dgv_Rules.Columns[3].HeaderText = "上级RuleID";
            dgv_Rules.Columns[3].Width = 100;
            dgv_Rules.Columns[4].HeaderText = "备注";
            dgv_Rules.Columns[4].Width = 200;
        }

        //2-初始化Items数据表内容-------------------------------------------------------------------------------------
        /// <summary>
        /// 初始化Items数据表内容
        /// </summary>
        private void InitItems()
        {
            List<AMItem> tmpAMItems = ADAuthOpera.GetAuthItems();
            ItemsBindingSource.DataSource = typeof(AMItem);
            ItemsBindingSource.DataSource = tmpAMItems;
            DataGridViewCheckBoxColumn ItemsDGVCBC = new DataGridViewCheckBoxColumn(false);  //定义在表前要添加的checkBox列
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
        #endregion

        #region Items表的tools按键处理
        /// <summary>
        /// 添加Item新行
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
            try
            {
                List<AMItem> tmpAMItemsSave = (List<AMItem>)ItemsBindingSource.DataSource;
                if (ADAuthOpera.SaveAuthItems(tmpAMItemsSave))
                    MessageBox.Show("Items保存成功!");
                else
                    MessageBox.Show("Items保存失败");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Rules表的选择项切换处理
        /// <summary>
        /// 切换Rules选择项时，同步更改Items的选择项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Rules_SeleChanged(object sender, EventArgs e)
        {
            if (LoadOver)
            {
                if (dgv_Rules.SelectedRows.Count > 0)
                {
                    currAMRule = (AMRule)RulesBindingSource[dgv_Rules.SelectedRows[0].Index]; //当前被选中的规则对象
                    List<string> currItemsID = ADAuthOpera.GetAMItemsValue(AMItemValueType.Item_ID, ADAuthOpera.GetAuthItems(currAMRule));//当前选中的规则的所有ItemsID
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
        }
        #endregion

        #region 保存对应关系
        private void toolSaveRu2It_Click(object sender, EventArgs e)
        {
            dgv_Items.CommitEdit(DataGridViewDataErrorContexts.Commit);
            AMRule currAMR = (AMRule)RulesBindingSource[dgv_Rules.SelectedRows[0].Index]; //当前被选中的规则对象
            List<AMItem> tmpSaveItems = new List<AMItem>();
            for (int i = 0; i <dgv_Items.Rows.Count; i++)
            {
                if ((bool)dgv_Items.Rows[i].Cells[0].Value)
                {
                    tmpSaveItems.Add((AMItem)ItemsBindingSource[i]);
                }
            }
            ADAuthOpera.SaveAuthRu2It(tmpSaveItems, currAMR).ToString();
            //MessageBox.Show(tmpSaveItems.Count.ToString());
        }
        #endregion

    }
}
