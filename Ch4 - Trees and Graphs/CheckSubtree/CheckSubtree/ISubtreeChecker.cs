using GraphsInfrastructure;

namespace CheckSubtree
{
    public interface ISubtreeChecker
    {
        bool IsSubtree(BinaryTreeNode t1, BinaryTreeNode t2);
    }
}