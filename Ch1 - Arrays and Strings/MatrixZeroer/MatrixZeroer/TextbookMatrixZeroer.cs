using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixZeroer
{
    public class TextbookMatrixZeroer : IMatrixZeroer
    {
        public void SetZeroes(int[][] matrix)
        {
            ValidateMatrix(matrix);

            bool[] row = new bool[matrix.Length];
            bool[] column = new bool[matrix[0].Length];

            // store the row and column index with value 0
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row[i] = true;
                        column[j] = true;
                    }
                }
            }

            // nullify rows
            for (int i = 0; i < matrix.Length; i++)
            {
                if (row[i]) NullifyRow(matrix, i);
            }

            // nullify columns
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (column[j]) NullifyColumn(matrix, j);
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
                throw new ArgumentException("The length of the matrix must be greater than zero.");
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
                    throw new ArgumentException("Matrix parameter must have equal row lengths.");
                }
            }
        }
    }
}
