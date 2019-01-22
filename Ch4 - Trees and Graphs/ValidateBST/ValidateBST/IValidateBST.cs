using GraphsInfrastructure;

namespace ValidateBST
{
    public interface IValidateBST
    {
        bool IsBST(BinaryTreeNode<int> root);
    }
}