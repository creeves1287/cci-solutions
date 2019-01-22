using GraphsInfrastructure;
using LinkedList;

namespace BinaryTreeToLinkedList
{
    public interface ILinkedListFromTreeCreator<T>
    {
        LinkedListNode<LinkedListNode<BinaryTreeNode<T>>> CreateLinkedListFromBinaryTree(BinaryTreeNode<T> root);
    }
}