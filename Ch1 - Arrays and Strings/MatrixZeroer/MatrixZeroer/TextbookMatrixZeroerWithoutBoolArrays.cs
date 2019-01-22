using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixZeroer
{
    public class TextbookMatrixZeroerWithoutBoolArrays : IMatrixZeroer
    {
        public void SetZeroes(int[][] matrix)
        {
            ValidateMatrix(matrix);

            bool rowHasZero = false;
            bool columnHasZero = false;

            for (int j = 0; j < matrix[0].Length; j++)
            {
                if(matrix[0][j] == 0)
                {
                    rowHasZero = true;
                    break;
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    columnHasZero = true;
                    break;
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    NullifyRow(matrix, i);
                }
            }

            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    NullifyColumn(matrix, j);
                }
            }

            if (rowHasZero)
            {
                NullifyRow(matrix, 0);
            }

            if (columnHasZero)
            {
                NullifyColumn(matrix, 0);
            }
        }

        private void NullifyRow(int[][] matrix, int row)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrix[row][j] = 0;
            }
        }

        private void NullifyColumn(int[][] matrix, int column)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][column] = 0;
            }
        }

        private void ValidateMatrix(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                throw new ArgumentException("Matrix must have a length greater than zero.");
            }

            int rowLength = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (i == 0)
                {
                    rowLength = matrix[i].Length;
                }

                if (matrix[i].Length != rowLength)
                {
                    throw new ArgumentException("Row lengths must be equal.");
                }
            }
        }
    }
}
