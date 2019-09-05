using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOfBoxes
{
    public class TextbookBoxStackerMemo : IBoxStacker
    {
        public int GetLargestStackHeight(List<Box> boxes)
        {
            if (boxes == null) return -1;
            int maxHeight = 0;
            int[] stackMap = new int[boxes.Count];
            for (int i = 0; i < boxes.Count; i++)
            {
                int height = GetLargestStackHeight(boxes, i, stackMap);
                maxHeight = Math.Max(maxHeight, height);
            }
            return maxHeight;
        }

        private int GetLargestStackHeight(List<Box> boxes, int bottomIndex, int[] stackMap)
        {
            if (bottomIndex < boxes.Count && stackMap[bottomIndex] > 0)
            {
                return stackMap[bottomIndex];
            }
            Box bottom = boxes[bottomIndex];
            int maxHeight = 0;
            for (int i = bottomIndex + 1; i < boxes.Count; i++)
            {
                if (CanBeAbove(boxes[i], bottom))
                {
                    int height = GetLargestStackHeight(boxes, i, stackMap);
                    maxHeight = Math.Max(maxHeight, height);
                }
            }
            maxHeight += bottom.Height;
            stackMap[bottomIndex] = maxHeight;
            return maxHeight;
        }

        private bool CanBeAbove(Box box, Box bottom)
        {
            bool canBeAbove = (box.Height < bottom.Height && box.Width < bottom.Width && box.Depth < bottom.Depth);
            return canBeAbove;
        }
    }
}
