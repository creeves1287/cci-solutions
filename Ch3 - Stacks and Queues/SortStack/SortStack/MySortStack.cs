using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStack
{
    public class MySortStack : ISortStack
    {
        public void Sort(Stack<int> input)
        {
            if (input == null || input.Count < 2)
            {
                return;
            }

            Stack<int> temp = new Stack<int>();

            MoveToStack(input, temp);

            while (temp.Count > 0)
            {
                int value = temp.Pop();
                
                while (input.Count > 0 && value > input.Peek())
                {
                    temp.Push(input.Pop());
                }

                input.Push(value);
            }
        }

        public void MoveToStack(Stack<int> sender, Stack<int> recipient)
        {
            while (sender.Count > 0)
            {
                recipient.Push(sender.Pop());
            }
        }
    }
}
