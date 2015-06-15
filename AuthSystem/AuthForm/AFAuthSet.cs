using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AuthSystem.AuthForm
{
    public partial class AFAuthSet : AFBase
    {
        public AFAuthSet()
        {
            InitializeComponent();
            InitMenu();
        }

        #region 初始化窗口界面与菜单生成---------------------------------------------------
        private Panel panel_Left;
        private Panel panel_Right_Down;
        private Panel panel_Right_Up;
        private DataGridView dgv_Allusers;
        private TreeView treeView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn BuMen;
        private DataGridViewTextBoxColumn Phone;
        private ListView listView1;
        private Panel panel_Right;
        /// <summary>
        /// 界面初始化，程序自动生成
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Left = new System.Windows.Forms.Panel();
            this.dgv_Allusers = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuMen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Right = new System.Windows.Forms.Panel();
            this.panel_Right_Down = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel_Right_Up = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Allusers)).BeginInit();
            this.panel_Right.SuspendLayout();
            this.panel_Right_Down.SuspendLayout();
            this.panel_Right_Up.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Left
            // 
            this.panel_Left.BackColor = System.Drawing.SystemColors.Control;
            this.panel_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Left.Controls.Add(this.dgv_Allusers);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 0);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(522, 560);
            this.panel_Left.TabIndex = 0;
            // 
            // dgv_Allusers
            // 
            this.dgv_Allusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Allusers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.UserName,
            this.BuMen,
            this.Phone});
            this.dgv_Allusers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Allusers.Location = new System.Drawing.Point(0, 0);
            this.dgv_Allusers.Name = "dgv_Allusers";
            this.dgv_Allusers.RowTemplate.Height = 23;
            this.dgv_Allusers.Size = new System.Drawing.Size(520, 558);
            this.dgv_Allusers.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // UserName
            // 
            this.UserName.HeaderText = "用户名";
            this.UserName.Name = "UserName";
            // 
            // BuMen
            // 
            this.BuMen.HeaderText = "部门";
            this.BuMen.Name = "BuMen";
            // 
            // Phone
            // 
            this.Phone.HeaderText = "手机";
            this.Phone.Name = "Phone";
            // 
            // panel_Right
            // 
            this.panel_Right.Controls.Add(this.panel_Right_Down);
            this.panel_Right.Controls.Add(this.panel_Right_Up);
            this.panel_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Right.Location = new System.Drawing.Point(522, 0);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(370, 560);
            this.panel_Right.TabIndex = 1;
            // 
            // panel_Right_Down
            // 
            this.panel_Right_Down.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Right_Down.Controls.Add(this.treeView1);
            this.panel_Right_Down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Right_Down.Location = new System.Drawing.Point(0, 261);
            this.panel_Right_Down.Name = "panel_Right_Down";
            this.panel_Right_Down.Size = new System.Drawing.Size(370, 299);
            this.panel_Right_Down.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(368, 297);
            this.treeView1.TabIndex = 0;
            // 
            // panel_Right_Up
            // 
            this.panel_Right_Up.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Right_Up.Controls.Add(this.listView1);
            this.panel_Right_Up.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Right_Up.Location = new System.Drawing.Point(0, 0);
            this.panel_Right_Up.Name = "panel_Right_Up";
            this.panel_Right_Up.Size = new System.Drawing.Size(370, 261);
            this.panel_Right_Up.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(368, 259);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AFAuthSet
            // 
            this.ClientSize = new System.Drawing.Size(892, 560);
            this.Controls.Add(this.panel_Right);
            this.Controls.Add(this.panel_Left);
            this.Name = "AFAuthSet";
            this.Text = "权限管理";
            this.panel_Left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Allusers)).EndInit();
            this.panel_Right.ResumeLayout(false);
            this.panel_Right_Down.ResumeLayout(false);
            this.panel_Right_Up.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        /// <summary>
        /// 初始化菜单按钮
        /// </summary>
        private void InitMenu()
        {
            //用户菜单：panel_Left菜单
            ToolStrip tsLe = new ToolStrip();
            ToolStripButton tsb1 = new ToolStripButton("添加用户",null,new EventHandler(this.tsb1_Click));
            ToolStripButton tsb2 = new ToolStripButton("修改用户");
            ToolStripButton tsb3 = new ToolStripButton("删除用户");
            tsLe.Items.Add(tsb1);
            tsLe.Items.Add(tsb2);
            tsLe.Items.Add(tsb3);
            panel_Left.Controls.Add(tsLe);
            

            
            //角色菜单：panel_Right_Up菜单
            ToolStrip tsRU = new ToolStrip();
            ToolStripButton tsb10 = new ToolStripButton("添加角色");
            ToolStripButton tsb11 = new ToolStripButton("修改角色");
            ToolStripButton tsb12 = new ToolStripButton("删除角色");
            tsRU.Items.Add(tsb10);
            tsRU.Items.Add(tsb11);
            tsRU.Items.Add(tsb12);
            panel_Right_Up.Controls.Add(tsRU);
            //权限菜单:panel_Right_Down菜单
            //ToolStrip tsRD = new ToolStrip();
            //ToolStripSeparator tss20 = new ToolStripSeparator();
            //tsRD.Items.Add(tss20);
            //panel_Right_Down.Controls.Add(tsRD);
        }
        private void tsb1_Click(object sender, EventArgs e) //添加用户处理
        {
            AFAuthSetUserSet afasus = new AFAuthSetUserSet();
            afasus.ShowDialog();
            afasus.Dispose();
        }
        #endregion
        #region 添加用户的窗口定义---------------------------------------------------------
        /// <summary>
        /// 添加用户窗口定义
        /// </summary>
        public class AFAuthSetUserSet : AFBase
        {
            public AFAuthSetUserSet()
            {
                //Init
            }
        }
        #endregion
    }
}
