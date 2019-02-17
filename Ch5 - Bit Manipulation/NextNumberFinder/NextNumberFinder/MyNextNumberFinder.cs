using System;

namespace NextNumberFinder
{
    public class MyNextNumberFinder : INextNumberFinder
    {
        public NextNumbers GetNextNumbers(int n)
        {
            if (n < 1) return null;

            if (n == int.MaxValue) return null;

            NextNumbers numbers = new NextNumbers();
            numbers.Next = GetSubsequentNumber(n);
            numbers.Previous = GetPreviousNumber(n);
            return numbers;
        }

        private int GetSubsequentNumber(int n)
        {
            int a = n;
            int index = 0;

            while (a != 0)
            {
                if ((a & 1) == 0)
                {
                    return IncrementNumber(n, index);
                }

                index++;
                a >>= 1;
            }

            return IncrementNumber(n, index);
        }

        private int GetPreviousNumber(int n)
        {
            int a = n;
            int index = 0;

            while (a != 0)
            {
                if ((a & 1) == 0)
                {
                    return DecrementNumber(n, index);
                }

                index++;
                a >>= 1;
            }

            return -1;
        }

        private int IncrementNumber(int a, int index)
        {
            int adjustment = (int)(Math.Pow(2, index) - Math.Pow(2, index - 1));
            return a + adjustment;
        }

        private int DecrementNumber(int a, int index)
        {
            int adjustment = (int)(Math.Pow(2, index + 1) - Math.Pow(2, index));
            return a - adjustment;
        }
    }
}
