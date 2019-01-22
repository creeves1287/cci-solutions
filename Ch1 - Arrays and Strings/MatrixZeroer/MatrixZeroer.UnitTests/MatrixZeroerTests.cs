using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixZeroer.UnitTests
{
    [TestClass]
    public class MatrixZeroerTests
    {
        [TestMethod]
        public void MyMatrixZeroerTest()
        {
            IMatrixZeroer matrixZeroer = new MyMatrixZeroer();
            RunTests(matrixZeroer);
        }

        [TestMethod]
        public void TextbookMatrixZeroerTest()
        {
            IMatrixZeroer matrixZeroer = new TextbookMatrixZeroer();
            RunTests(matrixZeroer);
        }

        [TestMethod]
        public void TextbookMatrixZeroerWithoutBoolArraysTest()
        {
            IMatrixZeroer matrixZeroer = new TextbookMatrixZeroerWithoutBoolArrays();
            RunTests(matrixZeroer);
        }

        public void RunTests(IMatrixZeroer matrixZeroer)
        {
            SetMatrixZeroesTest(matrixZeroer);
        }

        public void SetMatrixZeroesTest(IMatrixZeroer matrixZeroer)
        {
            int arrSize = 4;
            int[][] matrix = new int[3][];
            int[][] expected = new int[3][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[arrSize];
                expected[row] = new int[arrSize];

                for (int column = 0; column < matrix[row].Length; column++)
                {
                    matrix[row][column] = row + column;
                    expected[row][column] = matrix[row][column];
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int column = 0; column < matrix[0].Length; column++)
                {
                    if (row + column == 0)
                    {
                        for (int i = 0; i < expected[0].Length; i++)
                        {
                            expected[row][i] = 0;
                        }

                        for (int i = 0; i < expected.Length; i++)
                        {
                            if (expected[i] == null)
                            {
                                expected[i] = new int[arrSize];
                            }
                            expected[i][column] = 0;
                        }
                    }
                }
            }

            matrixZeroer.SetZeroes(matrix);

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int column = 0; column < matrix[0].Length; column++)
                {
                    Assert.AreEqual(expected[row][column], matrix[row][column]);
                }
            }
        }
    }
}
