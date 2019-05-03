using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGrid
{
    public class TextbookRobotGridTraverser : IRobotGridTraverser
    {
        public LinkedListNode TraverseGrid(Cell[][] grid)
        {
            if (grid == null || grid.Length == 0) return null;

            List<Cell> path = new List<Cell>();
            HashSet<Cell> blockedCells = new HashSet<Cell>();

            if (GetPath(grid, grid.Length - 1, grid[0].Length - 1, blockedCells, path))
                return ConvertToLinkedList(path);

            return null;
        }

        private bool GetPath(Cell[][] grid, int row, int column, HashSet<Cell> blockedCells, List<Cell> path)
        {
            if (row < 0 || column < 0 || !grid[row][column].IsValid || blockedCells.Contains(grid[row][column]))
                return false;

            bool isAtOrigin = (row == 0 && column == 0);

            if (isAtOrigin || GetPath(grid, row - 1, column, blockedCells, path) || GetPath(grid, row, column - 1, blockedCells, path))
            {
                path.Add(grid[row][column]);
                return true;
            }

            blockedCells.Add(grid[row][column]);
            return false;
        }

        private LinkedListNode ConvertToLinkedList(List<Cell> path)
        {
            LinkedListNode head = null;
            LinkedListNode previous = null;
            for (int i = 0; i < path.Count; i++)
            {
                Cell cell = path[i];
                LinkedListNode node = new LinkedListNode(cell);
                if (head == null)
                {
                    head = node;
                }
                else
                {
                    previous.Next = node;
                }
                previous = node;
            }
            return head;
        }
    }
}
