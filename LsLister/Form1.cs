using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LsLister
{
    public partial class Form1 : Form
    {
        ListParser parser;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string[] lines = {""};
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
            }
            parser=new ListParser(lines);
            parser.parse();
            treeView1.Nodes.AddRange(new TreeNode[] { parser.topTreeNode });
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == null || !treeView1.SelectedNode.Tag.GetType().Equals(typeof(FolderNode)))
            {
                return;
            }
            listView1.Clear();
            listView1.Columns.Add("名称", (int)(listView1.Width*0.5));
            listView1.Columns.Add("大小",(int)(listView1.Width * 0.1));
            listView1.Columns.Add("修改日期", (int)(listView1.Width * 0.2));
            listView1.Columns.Add("所有者", (int)(listView1.Width * 0.1));
            listView1.Columns.Add("权限", (int)(listView1.Width * 0.1));
            foreach (Node node in ((FolderNode)treeView1.SelectedNode.Tag).children.Values)
            {
                listView1.Items.Add(new ListViewItem(new String[] { node.fileName, node.size, node.time.ToString(), node.owner, node.permission }));
            }
        }
    }
}
