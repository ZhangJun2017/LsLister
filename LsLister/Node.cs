using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
