using System.Collections.Generic;

namespace StackOfBoxes
{
    public interface IBoxStacker
    {
        int GetLargestStackHeight(List<Box> boxes);
    }
}