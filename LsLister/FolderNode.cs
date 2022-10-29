using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LsLister
{
    public class FolderNode : Node
    {
        public Dictionary<string, Node> children;
        public FolderNode(string fileName, DateTime time, string permission, string owner, string size)
        {
            this.fileName = fileName;
            this.time = time;
            this.permission = permission;
            this.owner = owner;
            this.size = size;
            this.children = new Dictionary<string, Node>();
        }
        public void addNodeTo(string[] pathTree, Node node)
        {
            if (pathTree.Length == 0)
            {
                addNode(node);
            }
            else {
                if (!children.ContainsKey(pathTree[0]))
                {
                    children.Add(pathTree[0], new FolderNode(pathTree[0],node.time,"未知节点","unknown","0"));
                }
                FolderNode tmp = (FolderNode)children[pathTree[0]];
                tmp.addNodeTo(pathTree.Skip(1).ToArray(), node);
            }
        }
        public void addNode(Node node)
        {
            children.Add(node.fileName, node);
        }
        public override TreeNode collect()
        {
            TreeNode toReturn = new TreeNode(fileName);
            foreach(Node node in children.Values)
            {
                toReturn.Nodes.Add(node.collect());
            }
            toReturn.Tag = this;
            return toReturn;
        }
    }
}
