using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class MyQueenCombinationsGenerator : IQueenCombinationsGenerator
    {
        public List<bool[,]> GetQueenCombinations(int width, int height, int queens)
        {
            if (width == 0 || height == 0 || queens == 0) return null;
            HashSet<string> memo = new HashSet<string>();
            bool[,] positions = new bool[height, width];
            List<bool[,]> result = new List<bool[,]>();
            GetQueenCombinations(positions, queens, result, memo);
            return result;
        }

        private void GetQueenCombinations(bool[,] positions, int remaining, List<bool[,]> result, HashSet<string> memo)
        {
            string key = GetKey(positions);
            if (memo.Contains(key)) return;
            memo.Add(key);
            if (remaining == 0)
            {
                bool[,] clone = (bool[,])positions.Clone();
                result.Add(clone);
                return;
            }
            bool[,] available = GetAvailableSpaces(positions);
            for (int i = 0; i < positions.GetLength(0); i++)
            {
                for (int j = 0; j < positions.GetLength(1); j++)
                {
                    if (available[i, j])
                    {
                        positions[i, j] = true;
                        remaining--;
                        GetQueenCombinations(positions, remaining, result, memo);
                        positions[i, j] = false;
                        remaining++;
                    }
                }
            }
        }

        private string GetKey(bool[,] positions)
        {
            StringBuilder key = new StringBuilder();
            for (int i = 0; i < positions.GetLength(0); i++)
            {
                for (int j = 0; j < positions.GetLength(1); j++)
                {
                    if (positions[i, j])
                    {
                        int row = i + 1;
                        char column = (char)(j + 'a');
                        key.Append(column);
                        key.Append(row);
                    }
                }
            }
            return key.ToString();
        }

        private bool[,] GetAvailableSpaces(bool[,] positions)
        {
            bool[,] available = new bool[positions.GetLength(0), positions.GetLength(1)];
            SetAllToTrue(available);
            for (int i = 0; i < positions.GetLength(0); i++)
            {
                for (int j = 0; j < positions.GetLength(1); j++)
                {
                    if (positions[i, j])
                    {
                        MarkRowAsUnavailable(available, i, positions.GetLength(1));
                        MarkColumnAsUnavailable(available, j, positions.GetLength(0));
                        MarkDiagonalAsUnavailable(available, i, j, Math.Max(positions.GetLength(0), positions.GetLength(1)));
                    }
                }
            }
            return available;
        }

        private void MarkRowAsUnavailable(bool[,] available, int i, int length)
        {
            for (int k = 0; k < length; k++)
            {
                available[i, k] = false;
            }
        }

        private void MarkColumnAsUnavailable(bool[,] available, int j, int length)
        {
            for (int k = 0; k < length; k++)
            {
                available[k, j] = false;
            }
        }

        private void MarkDiagonalAsUnavailable(bool[,] available, int i, int j, int length)
        {
            for (int k = 0; k < length; k++)
            {
                if (i - k >= 0 && j - k >= 0)
                {
                    available[i - k, j - k] = false;
                }
                if (i + k < available.GetLength(0) && j + k < available.GetLength(1))
                {
                    available[i + k, j + k] = false;
                }
                if (i + k < available.GetLength(0) && j - k >= 0)
                {
                    available[i + k, j - k] = false;
                }
                if (i - k >= 0 && j + k < available.GetLength(1))
                {
                    available[i - k, j + k] = false;
                }

            }
        }

        private void SetAllToTrue(bool[,] available)
        {
            for (int i = 0; i < available.GetLength(0); i++)
            {
                for (int j = 0; j < available.GetLength(1); j++)
                {
                    available[i, j] = true;
                }
            }
        }
    }
}
