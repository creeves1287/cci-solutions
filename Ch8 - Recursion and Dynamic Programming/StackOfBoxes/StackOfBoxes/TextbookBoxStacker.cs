using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOfBoxes
{
    public class TextbookBoxStacker : IBoxStacker
    {
        public int GetLargestStackHeight(List<Box> boxes)
        {
            boxes.Sort(new BoxComparer());
            int maxHeight = 0;
            for (int i = 0; i < boxes.Count; i++)
            {
                int height = GetLargestStackHeight(boxes, i);
                maxHeight = Math.Max(maxHeight, height);
            }
            return maxHeight;
        }

        private int GetLargestStackHeight(List<Box> boxes, int boxIndex)
        {
            Box bottom = boxes[boxIndex];
            int maxHeight = 0;
            for (int i = boxIndex + 1; i < boxes.Count; i++)
            {
                Box top = boxes[i];
                if (CanBeStacked(bottom, top))
                {
                    int height = GetLargestStackHeight(boxes, i);
                    maxHeight = Math.Max(maxHeight, height);
                }
            }
            maxHeight += bottom.Height;
            return maxHeight;
        }

        private bool CanBeStacked(Box bottom, Box top)
        {
            bool canBeStacked = (bottom.Height > top.Height && bottom.Width > top.Width && bottom.Depth > top.Depth);
            return canBeStacked;
        }
    }
}
