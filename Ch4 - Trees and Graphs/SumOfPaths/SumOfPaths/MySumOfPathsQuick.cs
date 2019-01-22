using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfPaths
{
    public class MySumOfPathsQuick : ISumOfPaths
    {
        public int GetTotalSumsOfPaths(BinaryTreeNode<int> root, int sumToCompare)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            return GetTotalSumsOfPathsHelper(root, dict, sumToCompare, 0, 0);
        }

        private int GetTotalSumsOfPathsHelper(BinaryTreeNode<int> root, Dictionary<int, int> sumDict, int targetSum, int runningSum, int total)
        {
            if (root == null)
                return total;

            runningSum += root.Value;

            int complement = runningSum - targetSum;

            if (sumDict.ContainsKey(complement))
                total += sumDict[complement];

            if (sumDict.ContainsKey(runningSum))
                sumDict[runningSum]++;
            else
                sumDict.Add(runningSum, 1);

            total = GetTotalSumsOfPathsHelper(root.Left, sumDict, targetSum, runningSum, total);
            total = GetTotalSumsOfPathsHelper(root.Right, sumDict, targetSum, runningSum, total);

            if (sumDict[runningSum] == 1)
                sumDict.Remove(runningSum);
            else
                sumDict[runningSum]--;

            return total;
        }
    }
}
