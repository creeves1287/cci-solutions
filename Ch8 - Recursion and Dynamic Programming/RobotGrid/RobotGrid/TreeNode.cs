using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGrid
{
    public class TreeNode
    {
        public TreeNode(Cell data)
        {
            Value = data;
        }
        public Cell Value { get; }
        public TreeNode Right { get; set; }
        public TreeNode Down { get; set; }
        public TreeNode Parent { get; set; }
    }
}
