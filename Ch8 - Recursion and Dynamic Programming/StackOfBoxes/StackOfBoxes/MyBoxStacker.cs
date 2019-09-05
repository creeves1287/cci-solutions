using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOfBoxes
{
    public class MyBoxStacker : IBoxStacker
    {
        public int GetLargestStackHeight(List<Box> boxes)
        {
            if (boxes == null) return -1;
            bool[,] matrix = GetAdjacencyMatrix(boxes);
            int[] heights = new int[boxes.Count];
            for (int i = 0; i < boxes.Count; i++)
            {
                GetHeight(i, boxes, matrix, heights);
            }
            int height = GetLargestHeight(heights);
            return height;
        }

        private int GetHeight(int boxIndex, List<Box> boxes, bool[,] matrix, int[] heights)
        {
            if (boxIndex == boxes.Count)
                return 0;

            if (heights[boxIndex] > 0)
                return heights[boxIndex];

            Box box = boxes[boxIndex];
            int maxHeight = box.Height;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                bool outgoing = matrix[boxIndex, i];
                if (outgoing)
                {
                    int height = GetHeight(i, boxes, matrix, heights);
                    int combinedHeight = height + box.Height;
                    if (combinedHeight > maxHeight)
                    {
                        maxHeight = combinedHeight;
                    }
                }
            }
            heights[boxIndex] = maxHeight;
            return maxHeight;
        }

        private bool[,] GetAdjacencyMatrix(List<Box> boxes)
        {
            bool[,] matrix = new bool[boxes.Count, boxes.Count];
            for (int i = 0; i < boxes.Count; i++)
            {
                Box box1 = boxes[i];
                for (int j = i + 1; j < boxes.Count; j++)
                {
                    Box box2 = boxes[j];
                    int width = box1.Width - box2.Width;
                    int height = box1.Height - box2.Height;
                    int depth = box1.Depth - box2.Depth;

                    if (width > 0 && height > 0 && depth > 0)
                        matrix[i, j] = true;
                    else if (width < 0 && height < 0 && depth < 0)
                        matrix[j, i] = true;
                }
            }
            return matrix;
        }

        private int GetLargestHeight(int[] heights)
        {
            int maxHeight = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                int height = heights[i];
                if (height > maxHeight)
                    maxHeight = height;
            }
            return maxHeight;
        }
    }
}
