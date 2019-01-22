using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixRotator
{
    public class MyMatrixRotator : IMatrixRotator
    {
        public void RotateMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length / 2; i++)
            {
                for (int j = i; j < matrix[i].Length - i - 1; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[matrix.Length - j - 1][i];
                    matrix[matrix.Length - j - 1][i] = matrix[matrix.Length - i - 1][matrix[i].Length - j - 1];
                    matrix[matrix.Length - i - 1][matrix[i].Length - j - 1] = matrix[j][matrix[i].Length - i - 1];
                    matrix[j][matrix[i].Length - i - 1] = temp;
                }
            }
        }
    }
}
