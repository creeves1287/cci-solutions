using GraphsInfrastructure;

namespace BalancedTreeVerifier
{
    public interface IBalancedTreeVerifier<T>
    {
        bool IsBalanced(BinaryTreeNode<T> root);
    }
}