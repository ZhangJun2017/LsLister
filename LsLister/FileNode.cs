using System;
using System.Windows.Forms;

namespace LsLister
{
    public class FileNode : Node
    {
        public FileNode(string fileName, DateTime time, string permission, string owner, string size)
        {
            this.fileName = fileName;
            this.time = time;
            this.permission = permission;
            this.owner = owner;
            this.size = size;
            this.treeNode = new TreeNode(this.fileName);
            this.treeNode.Tag = this;
        }
        public override TreeNode collect()
        {
            return treeNode;
        }
    }
}
