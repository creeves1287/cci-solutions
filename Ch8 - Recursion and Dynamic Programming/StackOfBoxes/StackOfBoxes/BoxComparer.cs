using System.Collections.Generic;

namespace StackOfBoxes
{
    public class BoxComparer : IComparer<Box>
    {
        public int Compare(Box x, Box y)
        {
            return y.Height - x.Height;
        }
    }
}