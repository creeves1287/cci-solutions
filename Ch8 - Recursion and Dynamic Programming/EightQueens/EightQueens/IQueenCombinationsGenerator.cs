using System.Collections.Generic;

namespace EightQueens
{
    public interface IQueenCombinationsGenerator
    {
        List<bool[,]> GetQueenCombinations(int width, int height, int queens);
    }
}