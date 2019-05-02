using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGrid
{
    public class MyRobotGridTraverser : IRobotGridTraverser
    {
        public LinkedListNode TraverseGrid(Cell[][] grid)
        {
            if (grid == null) return null;
            TreeNode root = new TreeNode(grid[0][0]);
            PathsTree tree = new PathsTree(root);
            Dictionary<Cell, TreeNode> memo = new Dictionary<Cell, TreeNode>();
            FindPaths(tree, root, 0, 0, grid, memo);
            LinkedListNode path = BuildPath(tree.PathsEnd);
            return path;
        }

        private void FindPaths(PathsTree tree, TreeNode root, int row, int column, 
            Cell[][] grid, Dictionary<Cell, TreeNode> memo)
        {
            if (row == grid.Length - 1 && column == grid[0].Length - 1)
            {
                tree.AddEnd(root);
            }
            if (row + 1 < grid.Length && grid[row + 1][column].IsValid)
            {
                if (memo.ContainsKey(grid[row + 1][column]))
                {
                    root.Down = memo[grid[row + 1][column]];
                }
                else
                {
                    root.Down = new TreeNode(grid[row + 1][column]);
                    root.Down.Parent = root;
                    memo.Add(grid[row + 1][column], root.Down);
                    FindPaths(tree, root.Down, row + 1, column, grid, memo);
                }
            }
            if (column + 1 < grid[0].Length && grid[row][column + 1].IsValid)
            {
                if (memo.ContainsKey(grid[row][column + 1]))
                {
                    root.Down = memo[grid[row][column + 1]];
                }
                else
                {
                    root.Right = new TreeNode(grid[row][column + 1]);
                    root.Right.Parent = root;
                    memo.Add(grid[row][column + 1], root.Right);
                    FindPaths(tree, root.Right, row, column + 1, grid, memo);
                }
            }
        }

        private LinkedListNode BuildPath(List<TreeNode> pathsEnd)
        {
            if (pathsEnd.Count == 0) return null;
            TreeNode node = pathsEnd[0];
            LinkedListNode head = null;
            while (node != null)
            {
                LinkedListNode current = new LinkedListNode(node.Value);
                current.Next = head;
                head = current;
                node = node.Parent;
            }
            return head;
        }
    }
}
