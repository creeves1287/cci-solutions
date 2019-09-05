using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class TextbookQueenCombinationsGenerator
    {
        public List<int[]> GetQueenCombinations(int gridSize) 
        {
            List<int[]> results = new List<int[]>();
            GetQueenCombinations(0, new int[gridSize], results);
            return results;
        }

        private void GetQueenCombinations(int row, int[] columns, List<int[]> results)
        {
            if (row == columns.Length) // found valid placement
            {
                results.Add((int[])columns.Clone());
                return;
            }

            for (int col = 0; col < columns.Length; col++)
            {
                if (CheckValid(columns, row, col))
                {
                    columns[row] = col;
                    GetQueenCombinations(row + 1, columns, results);
                }
            }
        }

        private bool CheckValid(int[] columns, int row1, int column1)
        {
            for (int row2 = 0; row2 < row1; row2++)
            {
                int column2 = columns[row2];
                //Check if (row2, column2) invalidates (row1, column1) as a queen spot.

                //Check if rows have a queen in the same column
                if (column1 == column2)
                    return false;

                //Check diagonals: if the distance between the columns equals the distance between the rows, then they're in the same diagonal
                int columnDifference = Math.Abs(column1 - column2);

                //row1 > row2, so no need for abs
                int rowDifference = row1 - row2;

                if (columnDifference == rowDifference)
                    return false;
            }
            return true;
        }
    }
}
