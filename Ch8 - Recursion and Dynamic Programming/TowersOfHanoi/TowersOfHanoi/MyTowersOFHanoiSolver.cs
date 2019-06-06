using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    public class MyTowersOFHanoiSolver : ITowersOfHanoiSolver
    {
        public void SolvePuzzle(Stack<int> start, Stack<int> buffer, Stack<int> end, int n, Action<Stack<int>, Stack<int>, Stack<int>> towersAction)
        {
            if (n < 1) return;
            SolvePuzzle(start, end, buffer, n - 1, (s, e, b) => { towersAction(s, b, e); });
            towersAction(start, buffer, end);
            int disk = start.Pop();
            end.Push(disk);
            SolvePuzzle(buffer, start, end, n - 1, (b, s, e) => { towersAction(s, b, e); });
        }
    }
}
