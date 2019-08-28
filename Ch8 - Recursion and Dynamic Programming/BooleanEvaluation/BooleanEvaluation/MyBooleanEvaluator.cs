using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanEvaluation
{
    //string expression = "1^0|0|1";

    public class MyBooleanEvaluator : IBooleanEvaluator
    {
        public int CountBooleanEvaluations(string expression, bool evaluation)
        {
            if (expression == null) return -1;
            if (expression.Length == 0) return 0;
            int[] evaluations = CountBooleanEvaluations(expression, 0, expression.Length - 1);
            int index = (evaluation) ? 1 : 0;
            return evaluations[index];
        }

        private int[] CountBooleanEvaluations(string expression, int start, int end)
        {
            if (start == end)
            {
                int index = int.Parse(expression[start].ToString());
                int[] result = new int[2];
                result[index]++;
                return result;
            }

            int[] total = new int[2];
            for (int i = start + 1; i < end; i += 2)
            {
                char op = expression[i];
                int[] left = CountBooleanEvaluations(expression, start, i - 1);
                int[] right = CountBooleanEvaluations(expression, i + 1, end);
                int[] evaluations = Evaluate(left, right, op);
                total[0] += evaluations[0];
                total[1] += evaluations[1];
            }
            return total;
        }

        private int[] Evaluate(int[] left, int[] right, char op)
        {
            int[] total = new int[2];
            switch (op)
            {
                case '|':
                    total[0] = left[0] * right[0];
                    total[1] = left[0] * right[1] + left[1] * right[0] + left[1] * right[1];
                    break;
                case '&':
                    total[0] = left[0] * right[1] + left[1] * right[0] + left[0] * right[0];
                    total[1] = left[1] * right[1];
                    break;
                case '^':
                    total[0] = left[1] * right[1] + left[0] * right[0];
                    total[1] = left[1] * right[0] + left[0] * right[1];
                    break;
                default:
                    throw new ArgumentException("Invalid operator.");
            }
            return total;
        }
    }
}
