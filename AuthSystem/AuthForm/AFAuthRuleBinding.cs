﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using AuthSystem.AuthModel;
using AuthSystem.AuthPool2Soft;

namespace AuthSystem.AuthForm
{
    public class AFAuthRuleBinding : AFBase
    {
        #region 0-------定义公共变量
        private DataTable tmpDtItems;   //所有Items数据
        private DataTable tmpDtRules;   //所有Rules数据
        private ToolStripButton toolSaveItems;
        private bool itemsHasChange = false;//Items是否有更改
        private bool RulesHasChange = false;//Rules是否有更改
        private int currAMRuleIndex;
        private ToolStripButton toolRuleAdd;
        private ToolStripButton toolRuleDel;
        private ToolStripButton toolRuleSave;        //当前选择的Rule
        private bool LoadOver = false;              //是否初始化完成
        #endregion

        #region 1-------初始化
        public AFAuthRuleBinding()
        {
            AuthSystem.AuthPool2Db.AP2DOpera.GetPool();
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
            this.toolRuleAdd = new System.Windows.Forms.ToolStripButton();
            this.toolRuleDel = new System.Windows.Forms.ToolStripButton();
            this.toolRuleSave = new System.Windows.Forms.ToolStripButton();
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
            this.panel_Right.Location = new System.Drawing.Point(575, 0);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(589, 677);
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
            this.dgv_Items.Size = new System.Drawing.Size(589, 652);
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
            this.RulestoolStrip.Size = new System.Drawing.Size(589, 25);
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
            this.panel_Left.Size = new System.Drawing.Size(1164, 677);
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
            this.dgv_Rules.Size = new System.Drawing.Size(1164, 652);
            this.dgv_Rules.TabIndex = 1;
            this.dgv_Rules.SelectionChanged += new System.EventHandler(this.dgv_Rules_SeleChanged);
            // 
            // ItemstoolStrip
            // 
            this.ItemstoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRuleAdd,
            this.toolRuleDel,
            this.toolRuleSave,
            this.toolSaveRu2It});
            this.ItemstoolStrip.Location = new System.Drawing.Point(0, 0);
            this.ItemstoolStrip.Name = "ItemstoolStrip";
            this.ItemstoolStrip.Size = new System.Drawing.Size(1164, 25);
            this.ItemstoolStrip.TabIndex = 0;
            this.ItemstoolStrip.Text = "toolStrip2";
            // 
            // toolRuleAdd
            // 
            this.toolRuleAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolRuleAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolRuleAdd.Image")));
            this.toolRuleAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRuleAdd.Name = "toolRuleAdd";
            this.toolRuleAdd.Size = new System.Drawing.Size(61, 22);
            this.toolRuleAdd.Text = "添加Rule";
            this.toolRuleAdd.Click += new System.EventHandler(this.toolRuleAdd_Click);
            // 
            // toolRuleDel
            // 
            this.toolRuleDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolRuleDel.Image = ((System.Drawing.Image)(resources.GetObject("toolRuleDel.Image")));
            this.toolRuleDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRuleDel.Name = "toolRuleDel";
            this.toolRuleDel.Size = new System.Drawing.Size(61, 22);
            this.toolRuleDel.Text = "删除Rule";
            this.toolRuleDel.Click += new System.EventHandler(this.toolRuleDel_Click);
            // 
            // toolRuleSave
            // 
            this.toolRuleSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolRuleSave.Image = ((System.Drawing.Image)(resources.GetObject("toolRuleSave.Image")));
            this.toolRuleSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRuleSave.Name = "toolRuleSave";
            this.toolRuleSave.Size = new System.Drawing.Size(61, 22);
            this.toolRuleSave.Text = "保存Rule";
            this.toolRuleSave.Click += new System.EventHandler(this.toolRuleSave_Click);
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
            this.ClientSize = new System.Drawing.Size(1164, 677);
            this.Controls.Add(this.panel_Right);
            this.Controls.Add(this.panel_Left);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFAuthRuleBinding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置规则与对象对应关系";
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
            tmpDtRules = AuthPool2Soft.AP2SOpera.ReadPool(AuthPool.APPoolType.AMRules);
            dgv_Rules.DataSource = tmpDtRules;
            dgv_Rules.Columns[0].Visible = false;
            dgv_Rules.Columns[1].HeaderText = "ID";
            dgv_Rules.Columns[1].Width = 30;
            dgv_Rules.Columns[2].HeaderText="Rule名字";
            dgv_Rules.Columns[2].Width = 100;
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
            tmpDtItems = AuthPool2Soft.AP2SOpera.ReadPool(AuthPool.APPoolType.AMItems);
            DataGridViewCheckBoxColumn ItemsDGVCBC = new DataGridViewCheckBoxColumn(false);  //定义在表前要添加的checkBox列
            ItemsDGVCBC.Name = "SeleItem";
            dgv_Items.Columns.Add(ItemsDGVCBC);
            dgv_Items.DataSource = tmpDtItems;
            dgv_Items.Columns[0].HeaderText = "选择";
            dgv_Items.Columns[0].Width = 40;
            dgv_Items.Columns[1].Visible = false;
            dgv_Items.Columns[2].Width = 30;
            dgv_Items.Columns[2].HeaderText = "ID";
            dgv_Items.Columns[3].Width = 100;
            dgv_Items.Columns[3].HeaderText = "Item名字";
            dgv_Items.Columns[4].Width = 300;
            dgv_Items.Columns[4].HeaderText = "Item路径";
            dgv_Items.Columns[5].Width = 100;
            dgv_Items.Columns[5].HeaderText = "备注";
        }
        #endregion
        #endregion

        #region Rules表的tools按键处理
        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// 添加Rules
        /// </summary>
        private void toolRuleAdd_Click(object sender, EventArgs e)
        {
            tmpDtRules.Rows.Add(tmpDtRules.NewRow());
        }

        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// 删除Rules
        /// </summary>
        private void toolRuleDel_Click(object sender, EventArgs e)
        {
            if (dgv_Rules.SelectedRows.Count > 0)
            {
                int x = dgv_Rules.SelectedRows[0].Index;
                dgv_Rules.Rows.RemoveAt(x);
            }
            
        }

        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// 保存Rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolRuleSave_Click(object sender, EventArgs e)
        {
            try
            {
                AP2SOpera.SavePool(tmpDtRules, AuthPool.APPoolType.AMRules);
                AuthPool2Db.AP2DOpera.UpdatePool(AuthPool.APPoolType.AMRules);
                MessageBox.Show("保存成功！");
                InitRules();
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败！");
                throw;
            }
            
        }

        #endregion

        #region Items表的tools按键处理
        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// 添加Item新行
        /// </summary>
        private void toolAddItem_Click(object sender, EventArgs e)
        {
            tmpDtItems.Rows.Add(tmpDtItems.NewRow());
        }

        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// 删除Item行
        /// </summary>
        private void toolDelItem_Click(object sender, EventArgs e)
        {
            
            if (dgv_Items.SelectedRows.Count > 0)
            {
                int x = dgv_Items.SelectedRows[0].Index;
                dgv_Items.Rows.RemoveAt(x);
            }
        }

        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// 保存所有Item
        /// </summary>
        private void toolSaveItems_Click(object sender, EventArgs e)
        {
            try
            {
                AP2SOpera.SavePool(tmpDtItems, AuthPool.APPoolType.AMItems);
                AuthPool2Db.AP2DOpera.UpdatePool(AuthPool.APPoolType.AMItems);
                MessageBox.Show("保存成功！");
                InitItems();
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败！");
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
                    //当前选中Rule
                    //currAMRuleIndex = dgv_Rules.SelectedRows[0].Index; //当前被选中行
                    string currAMRule_Item_ID = dgv_Rules.SelectedRows[0].Cells["Rule_Item_ID"].Value.ToString();
                    //取Rule的对应数据
                    List<string> currItemsID = AuthPool2Soft.AP2SOpera.ReadPool_Ru2It(currAMRule_Item_ID);
                    //勾选数据
                    for (int x = 0; x < dgv_Items.Rows.Count; x++)
                    {
                        if (currItemsID.Contains(dgv_Items.Rows[x].Cells[2].Value.ToString()))
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
            //判断是否有选择Rule
            if (dgv_Rules.SelectedRows.Count > 0)
            {
                //当前选择的Rule的Rule_Item_ID
                string tmpRule_Item_ID = dgv_Rules.SelectedRows[0].Cells["Rule_Item_ID"].Value.ToString();
                //循环dgv_Items，勾选的项加入List.String
                List<string> tmpItemID = new List<string>();
                List<string> tmpItemIDdel = new List<string>();
                for (int i = 0; i < dgv_Items.Rows.Count; i++)
                {
                    if ((bool)dgv_Items.Rows[i].Cells[0].Value)
                    {
                        tmpItemID.Add(dgv_Items.Rows[i].Cells["Item_ID"].Value.ToString());
                    }
                    else
                    {
                        tmpItemIDdel.Add(dgv_Items.Rows[i].Cells["Item_ID"].Value.ToString());
                    }
                }
                //循环List.String,删除没勾选行
                AP2SOpera.DelRowPool_Ru2It(tmpRule_Item_ID);
                AuthPool2Db.AP2DOpera.UpdatePool(AuthPool.APPoolType.AMRu2It);
                AuthPool2Db.AP2DOpera.GetPool(AuthPool.APPoolType.AMRu2It);
                //循环List.String，添加Row到poolRu2It
                foreach (string x in tmpItemID)
                {
                    AP2SOpera.AddRowPool_Ru2It(tmpRule_Item_ID, x);
                }
                
                //更新池到数据库
                AuthPool2Db.AP2DOpera.UpdatePool(AuthPool.APPoolType.AMRu2It);

            }
            else
            {
                MessageBox.Show("请选择要保存数据的Rule");
            }
        }
        #endregion

        

        

        

        

    }
}
