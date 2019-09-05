using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using EightQueens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EightQueensTests
{
    [TestClass]
    public class QueenCombinationsGeneratorTests
    {
        [TestMethod]
        public void MyQueenCombinationsGeneratorTests()
        {
            IQueenCombinationsGenerator queenCombinationsGenerator = new MyQueenCombinationsGenerator();
            RunTests(queenCombinationsGenerator);
        }

        private void RunTests(IQueenCombinationsGenerator queenCombinationsGenerator)
        {
            int width = 20;
            int height = 20;
            int queens = 20;
            List<bool[,]> result = queenCombinationsGenerator.GetQueenCombinations(width, height, queens);
            PrintResult(result);
        }

        private void PrintResult(List<bool[,]> result)
        {
            StringBuilder print = new StringBuilder();
            foreach(bool[,] board in result)
            {
                AddBoardToPrint(board, print);
            }
            print.Append($"Total Count: { result.Count }");
            Trace.WriteLine(print);
        }

        private void AddBoardToPrint(bool[,] board, StringBuilder print)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j])
                    {
                        print.Append('♕');
                    }
                    else
                    {
                        print.Append('□');
                    }
                    print.Append(' ');
                }
                print.Append('\n');
            }
            print.Append('\n');
        }
    }
}
