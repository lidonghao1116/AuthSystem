using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

using AuthSystem.AuthModel;
using AuthSystem.AuthData;
using AuthSystem.AuthPool;
using AuthSystem.AuthForm;

namespace AuthSystem.AuthForm
{
    public class AFAuthRuleBinding : AFBase
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

        #region 0-------定义公共变量
        private DataTable tmpDtItems;   //所有Items数据
        private DataTable tmpDtRules;   //所有Rules数据
        private bool LoadOver1 = false;              //是否初始化完成
        private bool LoadOver2 = false;              //是否加载成功窗口
        private DataRow tmpRuleRow;                 //临时row
        private DataRow tmpItemRow;
        private ToolStripButton toolMoveItemsNo;
        
        private ADAction ADAct = new ADAction();       //数据与pool操作类        
        #endregion

        #region 1-------初始化
        public AFAuthRuleBinding()
        {
            ADAct.ConnString = APPoolGlobal.GlobalAMSystemConfig.ConnectionString; //设置连接字符串
            InitializeComponent(); //初始化界面
            
            InitRules();  //初始化规则表
            InitItems();  //初始化对象表
            InitRu2It();
            LoadOver1 = true;//表示初始化完成
        }
        #region 初始化界面
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.ToolStrip ItemstoolStrip;
        private System.Windows.Forms.Panel panel_Right;
        private System.Windows.Forms.ToolStrip RulestoolStrip;
        private System.Windows.Forms.DataGridView dgv_Items;
        private System.Windows.Forms.ToolStripButton toolDelItem;
        private System.Windows.Forms.DataGridView dgv_Rules;
        private System.Windows.Forms.ToolStripButton toolAddItem;
        private ToolStripButton toolSaveItems;
        private ToolStripButton toolRuleAdd;
        private ToolStripButton toolRuleDel;
        private ToolStripButton toolRuleSave;
        private TableLayoutPanel layoutMain;
        private ToolStripButton toolManageItemsNo;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFAuthRuleBinding));
            this.panel_Right = new System.Windows.Forms.Panel();
            this.dgv_Items = new System.Windows.Forms.DataGridView();
            this.RulestoolStrip = new System.Windows.Forms.ToolStrip();
            this.toolAddItem = new System.Windows.Forms.ToolStripButton();
            this.toolDelItem = new System.Windows.Forms.ToolStripButton();
            this.toolSaveItems = new System.Windows.Forms.ToolStripButton();
            this.toolManageItemsNo = new System.Windows.Forms.ToolStripButton();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.dgv_Rules = new System.Windows.Forms.DataGridView();
            this.ItemstoolStrip = new System.Windows.Forms.ToolStrip();
            this.toolRuleAdd = new System.Windows.Forms.ToolStripButton();
            this.toolRuleDel = new System.Windows.Forms.ToolStripButton();
            this.toolRuleSave = new System.Windows.Forms.ToolStripButton();
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.toolMoveItemsNo = new System.Windows.Forms.ToolStripButton();
            this.panel_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Items)).BeginInit();
            this.RulestoolStrip.SuspendLayout();
            this.panel_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rules)).BeginInit();
            this.ItemstoolStrip.SuspendLayout();
            this.layoutMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Right
            // 
            this.panel_Right.Controls.Add(this.dgv_Items);
            this.panel_Right.Controls.Add(this.RulestoolStrip);
            this.panel_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Right.Location = new System.Drawing.Point(468, 3);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(693, 671);
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
            this.dgv_Items.Size = new System.Drawing.Size(693, 646);
            this.dgv_Items.TabIndex = 1;
            this.dgv_Items.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Items_CellMouseUp);
            this.dgv_Items.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_Items_DirtyStateChanged);
            // 
            // RulestoolStrip
            // 
            this.RulestoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddItem,
            this.toolDelItem,
            this.toolSaveItems,
            this.toolManageItemsNo,
            this.toolMoveItemsNo});
            this.RulestoolStrip.Location = new System.Drawing.Point(0, 0);
            this.RulestoolStrip.Name = "RulestoolStrip";
            this.RulestoolStrip.Size = new System.Drawing.Size(693, 25);
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
            // toolManageItemsNo
            // 
            this.toolManageItemsNo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolManageItemsNo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolManageItemsNo.Image = ((System.Drawing.Image)(resources.GetObject("toolManageItemsNo.Image")));
            this.toolManageItemsNo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolManageItemsNo.Name = "toolManageItemsNo";
            this.toolManageItemsNo.Size = new System.Drawing.Size(156, 22);
            this.toolManageItemsNo.Text = "管理不用做权限处理的对象";
            this.toolManageItemsNo.Click += new System.EventHandler(this.toolManageItemsNo_Click);
            // 
            // panel_Left
            // 
            this.panel_Left.Controls.Add(this.dgv_Rules);
            this.panel_Left.Controls.Add(this.ItemstoolStrip);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Left.Location = new System.Drawing.Point(3, 3);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(459, 671);
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
            this.dgv_Rules.Size = new System.Drawing.Size(459, 646);
            this.dgv_Rules.TabIndex = 1;
            this.dgv_Rules.SelectionChanged += new System.EventHandler(this.dgv_Rules_SeleChanged);
            // 
            // ItemstoolStrip
            // 
            this.ItemstoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRuleAdd,
            this.toolRuleDel,
            this.toolRuleSave});
            this.ItemstoolStrip.Location = new System.Drawing.Point(0, 0);
            this.ItemstoolStrip.Name = "ItemstoolStrip";
            this.ItemstoolStrip.Size = new System.Drawing.Size(459, 25);
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
            // layoutMain
            // 
            this.layoutMain.ColumnCount = 2;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.layoutMain.Controls.Add(this.panel_Left, 0, 0);
            this.layoutMain.Controls.Add(this.panel_Right, 1, 0);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 1;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Size = new System.Drawing.Size(1164, 677);
            this.layoutMain.TabIndex = 2;
            // 
            // toolMoveItemsNo
            // 
            this.toolMoveItemsNo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolMoveItemsNo.Image = ((System.Drawing.Image)(resources.GetObject("toolMoveItemsNo.Image")));
            this.toolMoveItemsNo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMoveItemsNo.Name = "toolMoveItemsNo";
            this.toolMoveItemsNo.Size = new System.Drawing.Size(98, 22);
            this.toolMoveItemsNo.Text = "转移到ItemsNo";
            this.toolMoveItemsNo.Click += new System.EventHandler(this.toolMoveItemsNo_Click);
            // 
            // AFAuthRuleBinding
            // 
            this.ClientSize = new System.Drawing.Size(1164, 677);
            this.Controls.Add(this.layoutMain);
            this.Name = "AFAuthRuleBinding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置规则与对象对应关系";
            this.Shown += new System.EventHandler(this.Form_Shown);
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
            this.layoutMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region 初始化数据
        private void InitRu2It()
        {
            ADAct.ReadToPool(PoolType.Ru2It);
        }
        //1-初始化Rules数据表内容-------------------------------------------------------------------------------------
        /// <summary>
        /// 初始化Rules数据表内容
        /// </summary>
        private void InitRules()
        {
            ADAct.ReadToPool(PoolType.Rules);//从数据库更新数据
            tmpDtRules = ADAct.ReadPool(PoolType.Rules);//取数据

            dgv_Rules.DataSource = tmpDtRules;

            dgv_Rules.Columns[0].HeaderText = "ID";
            dgv_Rules.Columns[0].Width = 30;
            dgv_Rules.Columns[1].HeaderText="规则名字";
            dgv_Rules.Columns[1].Width = 150;
            dgv_Rules.Columns[2].HeaderText = "上级规则";
            dgv_Rules.Columns[2].Width = 80;
            dgv_Rules.Columns[3].HeaderText = "备注";
            dgv_Rules.Columns[3].Width = 250;
        }

        //2-初始化Items数据表内容-------------------------------------------------------------------------------------
        /// <summary>
        /// 初始化Items数据表内容
        /// </summary>
        private void InitItems()
        {
            ADAct.ReadToPool(PoolType.Items);//从数据库更新数据
            tmpDtItems = ADAct.ReadPool(PoolType.Items);//取数据

            DataGridViewCheckBoxColumn ItemsDGVCBC = new DataGridViewCheckBoxColumn(false);  //定义在表前要添加的checkBox列
            ItemsDGVCBC.Name = "SeleItem";
            dgv_Items.Columns.Add(ItemsDGVCBC);
            dgv_Items.DataSource = tmpDtItems;
            dgv_Items.Columns[0].HeaderText = "选择";
            dgv_Items.Columns[0].Width = 40;
            dgv_Items.Columns[1].Width = 30;
            dgv_Items.Columns[1].HeaderText = "ID";
            dgv_Items.Columns[2].Width = 130;
            dgv_Items.Columns[2].HeaderText = "Item名字";
            dgv_Items.Columns[3].Width = 350;
            dgv_Items.Columns[3].HeaderText = "Item路径";
            dgv_Items.Columns[4].Width = 100;
            dgv_Items.Columns[4].HeaderText = "Item类型";
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
            try
            {
                tmpRuleRow = tmpDtRules.NewRow();
                tmpDtRules.Rows.Add(tmpRuleRow);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
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
                dgv_Rules.DataSource = null;
                ADAct.SavePool(PoolType.Rules, tmpDtRules);
                ADAct.UpdatePool(PoolType.Rules);
                InitRules();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
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
            try
            {
                tmpItemRow = tmpDtItems.NewRow();
                tmpDtItems.Rows.Add(tmpItemRow);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
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
                dgv_Items.DataSource = null;
                dgv_Items.Columns.Clear();
                ADAct.SavePool(PoolType.Items, tmpDtItems);
                ADAct.UpdatePool(PoolType.Items);
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
            if (LoadOver2)
            {
                if (dgv_Rules.SelectedRows.Count > 0)
                {
                    //当前选中Rule
                    //currAMRuleIndex = dgv_Rules.SelectedRows[0].Index; //当前被选中行
                    string currAMRule_ID = dgv_Rules.SelectedRows[0].Cells["Rule_ID"].Value.ToString();
                    //取Rule的对应数据
                    List<string> currItemsID = ADAct.ReadPoolRu2It(currAMRule_ID);
                    //勾选数据
                    for (int x = 0; x < dgv_Items.Rows.Count; x++)
                    {
                        if (currItemsID.Contains(dgv_Items.Rows[x].Cells["Item_ID"].Value.ToString()))
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
        /// <summary>
        /// 鼠标点击Cell后的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Items_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgv_Rules.SelectedRows.Count > 0)//只有选择了Rule才会进行处理
                {
                    if (e.ColumnIndex == 0)//点击第1列时才会处理下面事件
                    {
                        DataGridViewCell tmpCell = dgv_Items.Rows[e.RowIndex].Cells[e.ColumnIndex]; //取当前点击的Items的Cell
                        //取当前选择的RuleID
                        int tmpSeleRuleID = Convert.ToInt32(dgv_Rules.SelectedRows[0].Cells["Rule_ID"].Value);
                        //当前选择的ItemID
                        int tmpSeleItemID = Convert.ToInt32(dgv_Items.Rows[e.RowIndex].Cells["Item_ID"].Value);

                        if ((bool)tmpCell.Value)
                        {
                            ChangeRu2It(Ru2ItAction.Add, tmpSeleRuleID, tmpSeleItemID);
                        }
                        else
                        {
                            ChangeRu2It(Ru2ItAction.Del, tmpSeleRuleID, tmpSeleItemID);
                        }
                    }
                    else
                    {
                        //处理其它列
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 添加删除对应处理
        /// </summary>
        /// <param name="act"></param>
        /// <param name="RuleID"></param>
        /// <param name="ItemID"></param>
        private void ChangeRu2It(Ru2ItAction act, int RuleID, int ItemID)
        {
            try
            {
                ADAct.ReadToPool(PoolType.Ru2It);
                DataTable tmpDt = ADAct.ReadPool(PoolType.Ru2It);
                switch (act)
                {

                    case Ru2ItAction.Add:
                        bool tmpIsAdd = true;
                        for (int i = 0; i < tmpDt.Rows.Count; i++)
                        {
                            if (tmpDt.Rows[i]["Rule_ID"].ToString() == RuleID.ToString() && tmpDt.Rows[i]["Item_ID"].ToString() == ItemID.ToString())
                            {
                                tmpIsAdd = false;
                            }
                        }
                        if (tmpIsAdd)
                        {
                            DataRow tmpRowAdd = tmpDt.NewRow();
                            tmpRowAdd[0] = RuleID;
                            tmpRowAdd[1] = ItemID;
                            tmpDt.Rows.Add(tmpRowAdd);
                        }
                        break;
                    case Ru2ItAction.Del:
                        int tmpIndex = 999999;
                        for (int i = 0; i < tmpDt.Rows.Count; i++)
                        {
                            if (tmpDt.Rows[i]["Rule_ID"].ToString() == RuleID.ToString() && tmpDt.Rows[i]["Item_ID"].ToString() == ItemID.ToString())
                            {
                                tmpIndex = i;
                            }
                        }
                        if (!(tmpIndex == 999999))
                        {
                            tmpDt.Rows[tmpIndex].Delete();
                        }
                        break;
                    default:
                        break;
                }
                ADAct.SavePool(PoolType.Ru2It, tmpDt);
                ADAct.UpdatePool(PoolType.Ru2It);
                InitRu2It();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private enum Ru2ItAction
        {
            Add,
            Del
        }
       
        #endregion
        
        #region 一些其它处理
        /// <summary>
        /// 窗体第一次显示时，设置LoadOver2=true
        /// </summary>
        private void Form_Shown(object sender, EventArgs e)
        {
            LoadOver2 = true;

            //加载时，默认Items的选择状态
            if (dgv_Rules.SelectedRows.Count > 0)
            {
                //当前选中Rule
                //currAMRuleIndex = dgv_Rules.SelectedRows[0].Index; //当前被选中行
                string currAMRule_ID = dgv_Rules.SelectedRows[0].Cells["Rule_ID"].Value.ToString();
                //取Rule的对应数据
                List<string> currItemsID = ADAct.ReadPoolRu2It(currAMRule_ID);
                //勾选数据
                for (int x = 0; x < dgv_Items.Rows.Count; x++)
                {
                    if (currItemsID.Contains(dgv_Items.Rows[x].Cells["Item_ID"].Value.ToString()))
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

        /// <summary>
        /// 实时提交dgv_items更改
        /// </summary>
        private void dgv_Items_DirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_Items.IsCurrentCellDirty)
            {
                dgv_Items.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }  
        #endregion

        #region 不做权限处理相关
        private void toolManageItemsNo_Click(object sender, EventArgs e)
        {
            AFAuthSetItemNo tmpForm = new AFAuthSetItemNo();
            tmpForm.ShowDialog();
        }

        private void toolMoveItemsNo_Click(object sender, EventArgs e)
        {
            
        }
        #endregion
    }
}
