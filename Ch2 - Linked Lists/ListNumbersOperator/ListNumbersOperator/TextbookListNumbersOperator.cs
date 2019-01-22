using LinkedList;

namespace ListNumbersOperator
{
    public class TextbookListNumbersOperator : IListNumbersOperator
    {
        public Node<int> AddNumbers(Node<int> first, Node<int> second)
        {
            int carry = 0;
            Node<int> node = AddNumbers(first, second, carry);
            return node;
        } 

        private Node<int> AddNumbers(Node<int> first, Node<int> second, int carry)
        {
            if (first == null && second == null && carry == 0)
            {
                return null;
            }

            Node<int> result = new Node<int>();
            int sum = carry;

            if (first != null)
            {
                sum += first.Data;
            }

            if (second != null)
            {
                sum += second.Data;
            }

            result.Data = sum % 10;

            if (first != null || second != null)
            {
                Node<int> more = AddNumbers(
                    (first == null) ? null : first.Next,
                    (second == null) ? null: second.Next,
                    (sum >= 10) ? 1 : 0);

                result.Next = more;
            }

            return result;
        }
    }
}
