using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LsLister
{
    public class ListParser
    {
        public String[] lines;
        public List<List<string>> listInString = new List<List<string>>();
        public FolderNode topNode = new FolderNode("/", DateTime.Now, "", "", "");
        public TreeNode topTreeNode = new TreeNode("/");
        public ListParser(String[] lines)
        {
            this.lines = lines;
        }
        public Node nodeParse(string nodeLine, string size = "")
        {
            if (nodeLine == "")
            {
                return new FileNode("出错！", DateTime.Now, "", "", "");
            }
            string[] nodeSp = System.Text.RegularExpressions.Regex.Split(nodeLine, " \\+0800 ");
            string[] nodeInfoSp = nodeSp[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (nodeSp[1].EndsWith("/"))
            {
                return new FolderNode(nodeSp[1].Substring(0, nodeSp[1].Length - 1), DateTime.Parse(nodeInfoSp[5] + " " + nodeInfoSp[6]), nodeInfoSp[0], nodeInfoSp[2], size);
            }
            else
            {
                return new FileNode(nodeSp[1], DateTime.Parse(nodeInfoSp[5] + " " + nodeInfoSp[6]), nodeInfoSp[0], nodeInfoSp[2], nodeInfoSp[4]);
            }
        }
        public void parse()
        {
            List<string> tmp = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    tmp.Add(lines[i]);
                }
                else
                {
                    listInString.Add(tmp);
                    tmp = new List<string>();
                }
            }
            for(int i = 0; i < listInString.Count; i++)
            {
                for(int j = 2; j < listInString[i].Count; j++)
                {
                    string[] pathTree = listInString[i][0].TrimEnd(':').Split('/');
                    topNode.addNodeTo(pathTree, nodeParse(listInString[i][j], listInString[i][1].Split(' ')[1]));
                }
            }
            topTreeNode = topNode.collect();
        }
    }
}
