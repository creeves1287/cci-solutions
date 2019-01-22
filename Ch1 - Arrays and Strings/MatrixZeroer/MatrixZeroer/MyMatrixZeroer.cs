using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixZeroer
{
    public class MyMatrixZeroer : IMatrixZeroer
    {
        public void SetZeroes(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                throw new ArgumentException("The length of the matrix must be greater than zero.");
            }

            if (matrix.Length == 0)
            {
                throw new ArgumentException("The length of the arrays within the matrix must have lengths greater than zero.");
            }

            bool[] zeroedRows = new bool[matrix.Length];
            bool[] zeroedColumns = new bool[matrix[0].Length];

            for (int row = 0; row < matrix.Length; row++)
            {
                if (zeroedRows[row] == true)
                {
                    continue;
                }

                for (int column = 0; column < matrix[0].Length; column++)
                {
                    if (zeroedColumns[column] == true)
                    {
                        continue;
                    }

                    if (matrix[row][column] == 0)
                    {
                        Zero(matrix, row, column);
                        zeroedRows[row] = true;
                        zeroedColumns[column] = true;
                        break;
                    }
                }
            }
        }

        private void Zero(int[][] matrix, int rowToZero, int columnToZero)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (row == rowToZero)
                {
                    for (int column = 0; column < matrix[0].Length; column++)
                    {
                        matrix[row][column] = 0;
                    }
                }
                else
                {
                    matrix[row][columnToZero] = 0;
                }
            }
        }
    }
}
