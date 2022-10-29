using System;
using System.Windows.Forms;

namespace LsLister
{
    public class Node
    {
        public string fileName;
        public DateTime time;
        public string permission;
        public string owner;
        public string size;
        public TreeNode treeNode;
        public virtual TreeNode collect() { return treeNode; }
    }
}
