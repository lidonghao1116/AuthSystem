using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AuthSystem.AuthData;

namespace XmlConfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private AuthSystem.AuthData.XmlConfig xc=new AuthSystem.AuthData.XmlConfig();
        private void button1_Click(object sender, EventArgs e)
        {
            xc.LoadFile("a.dat");
            List<string> tmpList = xc.GetNodes();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(tmpList.ToArray());
            MessageBox.Show(xc.GetNode("ac1").Name);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AuthSystem.AuthData.XmlConfig xc = new AuthSystem.AuthData.XmlConfig();
            xc.LoadFile("a.dat");
            MemoryStream ms = xc.Export();
            richTextBox1.LoadFile(ms, RichTextBoxStreamType.PlainText);
            ms.Close();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            xc.Save();
        }

        private void bt_addNode_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="")
            {
                xc.AddNode(textBox1.Text);
            }
            else
            {
                xc.AddNode(textBox1.Text, comboBox1.Text);
            }
            
        }

        private void bt_delNode_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                xc.DelNode(comboBox1.Text);
                comboBox1.Items.Remove(comboBox1.Text);
            }
        }

    }
}
