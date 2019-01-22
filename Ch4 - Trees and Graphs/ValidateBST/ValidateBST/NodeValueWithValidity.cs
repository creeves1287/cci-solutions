namespace ValidateBST
{
    public class NodeValueWithValidity<T>
    {
        public T Value { get; set; }
        public bool IsValid { get; set; }

        public NodeValueWithValidity(T value)
        {
            Value = value;
        }
    }
}