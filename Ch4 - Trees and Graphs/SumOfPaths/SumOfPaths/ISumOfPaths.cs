using GraphsInfrastructure;

namespace SumOfPaths
{
    public interface ISumOfPaths
    {
        int GetTotalSumsOfPaths(BinaryTreeNode<int> root, int sumToCompare);
    }
}