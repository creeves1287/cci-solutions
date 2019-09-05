using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOfBoxes
{
    public class TextbookBoxStackerWithChoices : IBoxStacker
    {
        public int GetLargestStackHeight(List<Box> boxes)
        {
            if (boxes == null) return -1;
            boxes.Sort(new BoxComparer());
            int[] stackMap = new int[boxes.Count];
            int height = GetLargestStackHeight(boxes, null, 0, stackMap);
            return height;
        }

        private int GetLargestStackHeight(List<Box> boxes, Box bottom, int offset, int[] stackMap)
        {
            if (offset >= boxes.Count) return 0;

            //height with this bottom
            Box newBottom = boxes[offset];
            int heightWithBottom = 0;
            if (bottom == null || CanBeAbove(bottom, newBottom))
            {
                if (stackMap[offset] == 0)
                {
                    stackMap[offset] = GetLargestStackHeight(boxes, newBottom, offset + 1, stackMap);
                    stackMap[offset] += newBottom.Height;
                }
                heightWithBottom = stackMap[offset];
            }

            //height without this bottom
            int heightWithoutBottom = GetLargestStackHeight(boxes, bottom, offset + 1, stackMap);

            //return better of two options
            return Math.Max(heightWithBottom, heightWithoutBottom);
        }

        private bool CanBeAbove(Box bottom, Box top)
        {
            return (bottom.Width > top.Width && bottom.Height > top.Height && bottom.Depth > top.Depth);
        }
    }
}
