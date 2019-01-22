namespace SetOfStacks
{
    public interface ISetOfStacks<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
    }
}