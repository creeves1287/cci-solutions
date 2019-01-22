using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRotator
{
    public class TextbookMatrixRotator : IMatrixRotator
    {
        public void RotateMatrix(int[][] matrix)
        {
            if (matrix.Length == 0) throw new ArgumentException("The matrix length must be greater than 0");

            if (matrix.Length != matrix[0].Length) throw new ArgumentException("The matrix length must match the length of the individual arrays.");

            int n = matrix.Length;

            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first][i];

                    // left -> top
                    matrix[first][i] = matrix[last - offset][first];

                    // bottom -> left
                    matrix[last - offset][first] = matrix[last][last - offset];

                    // right -> bottom
                    matrix[last][last - offset] = matrix[i][last];

                    // top -> right
                    matrix[i][last] = top;
                }
            }
        }
    }
}
