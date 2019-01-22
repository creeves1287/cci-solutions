namespace MinStack
{
    public interface IMinStack
    {
        void Push(int data);
        int Pop();
        int Min();
        int Peek();
        bool IsEmpty();
    }
}