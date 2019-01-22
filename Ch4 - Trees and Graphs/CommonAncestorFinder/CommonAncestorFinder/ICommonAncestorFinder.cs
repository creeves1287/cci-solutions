using GraphsInfrastructure;

namespace CommonAncestorFinder
{
    public interface ICommonAncestorFinder
    {
        BinaryTreeNode<int> FindCommonAncestor(BinaryTreeNode<int> root, BinaryTreeNode<int> node1, BinaryTreeNode<int> node2);
    }
}