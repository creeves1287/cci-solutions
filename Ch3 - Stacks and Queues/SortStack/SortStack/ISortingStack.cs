namespace SortStack
{
    public interface ISortingStack
    {
        void Push(int value);
        int Pop();
        int Peek();
        bool IsEmpty();
    }
}