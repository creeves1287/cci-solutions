using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRotator
{
    public class TextbookMatrixRotatorWithMultiArray
    {
        public void RotateMatrix(int[,] matrix)
        {
            int columnLength = matrix.GetLength(0);
            int rowLength = matrix.GetLength(1);

            if (matrix.Length == 0) throw new ArgumentException("The matrix length must be greater than 0");

            if (rowLength != columnLength) throw new ArgumentException("The matrix length must match the length of the individual arrays.");

            int n = columnLength;

            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first, i];

                    // left -> top
                    matrix[first, i] = matrix[last - offset, first];

                    // bottom -> left
                    matrix[last - offset, first] = matrix[last, last - offset];

                    // right -> bottom
                    matrix[last, last - offset] = matrix[i, last];

                    // top -> right 
                    matrix[i, last] = top;
                }
            }
        }
    }
}
