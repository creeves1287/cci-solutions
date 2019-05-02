using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGrid
{
    public class PathsTree
    {
        public PathsTree(TreeNode root)
        {
            Root = root;
        }
        public TreeNode Root { get; }
        public List<TreeNode> PathsEnd { get; set; } = new List<TreeNode>();
        public void AddEnd(TreeNode end)
        {
            PathsEnd.Add(end);
        }
    }
}
