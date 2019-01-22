using GraphsInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfPaths
{
    public class MySumOfPaths : ISumOfPaths
    {
        public int GetTotalSumsOfPaths(BinaryTreeNode<int> root, int sumToCompare)
        {
            return GetTotalSumsOfPathsHelper(root, sumToCompare, 0);
        }

        private int GetTotalSumsOfPathsHelper(BinaryTreeNode<int> root, int sumToCompare, int totalSums)
        {
            if (root == null)
                return totalSums;

            totalSums = GetTotalSumsOfPathsFromNode(root, sumToCompare, totalSums, 0);
            totalSums = GetTotalSumsOfPathsHelper(root.Left, sumToCompare, totalSums);
            totalSums = GetTotalSumsOfPathsHelper(root.Right, sumToCompare, totalSums);

            return totalSums;
        }

        private int GetTotalSumsOfPathsFromNode(BinaryTreeNode<int> root, int sumToCompare, int totalSums, int currentSum)
        {
            if (root == null)
                return totalSums;

            currentSum += root.Value;

            if (currentSum == sumToCompare)
                totalSums++;

            totalSums = GetTotalSumsOfPathsFromNode(root.Left, sumToCompare, totalSums, currentSum);
            totalSums = GetTotalSumsOfPathsFromNode(root.Right, sumToCompare, totalSums, currentSum);

            return totalSums;
        }
    }
}
