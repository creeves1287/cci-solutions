using GraphsInfrastructure;
using LinkedList;

namespace BinaryTreeToLinkedList
{
    public class MyLinkedListFromTreeCreator<T> : ILinkedListFromTreeCreator<T>
    {
        public LinkedListNode<LinkedListNode<BinaryTreeNode<T>>> CreateLinkedListFromBinaryTree(BinaryTreeNode<T> root)
        {
            if (root == null) return null;

            LinkedListNode<LinkedListNode<BinaryTreeNode<T>>> treeList = new LinkedListNode<LinkedListNode<BinaryTreeNode<T>>>(
                new LinkedListNode<BinaryTreeNode<T>>(root));

            AddNodeToTreeList(treeList, root.Left);
            AddNodeToTreeList(treeList, root.Right);

            return treeList;
        }

        private void AddNodeToTreeList(LinkedListNode<LinkedListNode<BinaryTreeNode<T>>> treeListNode, BinaryTreeNode<T> node)
        {
            if (node == null) return;

            LinkedListNode<BinaryTreeNode<T>> listNode = new LinkedListNode<BinaryTreeNode<T>>(node);

            if (treeListNode.Next == null)
            {
                treeListNode.Next = new LinkedListNode<LinkedListNode<BinaryTreeNode<T>>>(listNode);
            }
            else
            {
                LinkedListNode<BinaryTreeNode<T>> current = treeListNode.Next.Data;
                while(current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = listNode;
            }

            AddNodeToTreeList(treeListNode.Next, node.Left);
            AddNodeToTreeList(treeListNode.Next, node.Right);
        }
    }
}
