using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixRotator.UnitTests
{
    [TestClass]
    public class MatrixRotatorTests
    {
        [TestMethod]
        public void Setup()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void MyMatrixRotatorTest()
        {
            IMatrixRotator matrixRotator = new MyMatrixRotator();
            RunTests(matrixRotator);
        }

        [TestMethod]
        public void TextbookMatrixRotatorTest()
        {
            IMatrixRotator matrixRotator = new TextbookMatrixRotator();
            RunTests(matrixRotator);
        }

        private void RunTests(IMatrixRotator matrixRotator)
        {
            MatrixRotateTest(matrixRotator);
        }

        private void MatrixRotateTest(IMatrixRotator matrixRotator)
        {
            int size = 100;
            int[][] matrix = new int[size][];
            for (int i = 0; i < matrix.Length; i++)
            {
                int[] row = matrix[i] = new int[size];
                for (int j = 0; j < row.Length; j++)
                {
                    row[j] = j + i;
                }
            }

            int[][] expected = new int[size][];

            for (int i = 0; i < expected.Length; i++)
            {
                int[] row = expected[i] = new int[size];
                for (int j = 0; j < row.Length; j++)
                {
                    row[j] = i + expected.Length - j -1;
                }
            }

            matrixRotator.RotateMatrix(matrix);

            for (int i = 0; i < matrix.Length; i++)
            {
                int[] row = matrix[i];
                for (int j = 0; j < row.Length; j++)
                {
                    int matrixValue = matrix[i][j];
                    int expectedValue = expected[i][j];
                    Assert.AreEqual(expectedValue, matrixValue);
                }
            }
        }
    }
}
