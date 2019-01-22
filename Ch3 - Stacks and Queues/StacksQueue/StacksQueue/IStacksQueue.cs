namespace StacksQueue
{
    public interface IStacksQueue<T>
    {
        void Add(T item);
        T Remove();
        T Peek();
        bool IsEmpty();
    }
}