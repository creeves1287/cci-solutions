using GraphsInfrastructure;

namespace MinimalTree
{
    public interface IMinimalTree
    {
        BinaryTreeNode<int> CreateMinimalTree(int[] arr);
    }
}