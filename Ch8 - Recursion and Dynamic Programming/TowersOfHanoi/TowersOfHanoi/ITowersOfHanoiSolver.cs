using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    public interface ITowersOfHanoiSolver
    {
        void SolvePuzzle(Stack<int> start, Stack<int> buffer, Stack<int> end, int n, Action<Stack<int>, Stack<int>, Stack<int>> towersAction);
    }
}