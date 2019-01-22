namespace TripleStack
{
    public interface IStacks<T>
    {
        void Push(T item, int stackIndex);
        T Pop(int stackIndex);
        T Peek(int stackIndex);
        bool IsEmpty(int stackIndex);
    }
}