using LinkedList;

namespace KthToLast
{
    public interface IKthToLastAnalyzer<T>
    {
        Node<T> GetKthToLastNode(Node<T> head, int k);
    }
}