using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TowersOfHanoi;

namespace TowersOfHanoiTests
{
    [TestClass]
    public class TowersOfHanioSolverTests
    {
        [TestMethod]
        public void MyTowersOfHanoiSolverTests()
        {
            ITowersOfHanoiSolver towersOfHanoiSolver = new MyTowersOFHanoiSolver();
            RunTests(towersOfHanoiSolver);
        }

        private void RunTests(ITowersOfHanoiSolver towersOfHanoiSolver)
        {
            int n = 3;
            Stack<int> start = CreateStartTower(n);
            Stack<int> buffer = new Stack<int>();
            Stack<int> end = new Stack<int>();
            towersOfHanoiSolver.SolvePuzzle(start, buffer, end, n, PrintTowers);
        }

        private Stack<int> CreateStartTower(int n)
        {
            Stack<int> start = new Stack<int>();
            for (int i = n; i > 0; i--)
            {
                start.Push(i);
            }
            return start;
        }

        private void PrintTowers(Stack<int> start, Stack<int> buffer, Stack<int> end)
        {
            Stack<int> temp1 = new Stack<int>();
            Stack<int> temp2 = new Stack<int>();
            Stack<int> temp3 = new Stack<int>();
            int n = start.Count + buffer.Count + end.Count;
            for (int i = n; i > 0; i--)
            {
                PrintTower(start, temp1, n, i, false);
                PrintTower(buffer, temp2, n, i, false);
                PrintTower(end, temp3, n, i, true);
            }
            Trace.Write("\n\n\n");
            ResetTower(start, temp1);
            ResetTower(buffer, temp2);
            ResetTower(end, temp3);
        }

        private void PrintTower(Stack<int> tower, Stack<int> temp, int n, int index, bool isEnd)
        {
            if (index > tower.Count)
            {
                PrintRow(n, 0);
            }
            else
            {
                int val = tower.Pop();
                temp.Push(val);
                PrintRow(n, val);
            }
            if (isEnd)
                Trace.Write("\n");
            else
                Trace.Write("\t");
        }

        private void ResetTower(Stack<int> tower, Stack<int> temp)
        {
            while (temp.Count > 0)
            {
                int val = temp.Pop();
                tower.Push(val);
            }
        }
        private void PrintRow(int n, int val)
        {
            for (int j = 0; j < n; j++)
            {
                if (j < (n - val))
                {
                    Trace.Write("   ");
                }
                else
                {
                    Trace.Write("__");
                }
            }
            Trace.Write("||");
            for (int j = 0; j < n; j++)
            {
                if (j < val)
                {
                    Trace.Write("__");
                }
                else
                {
                    Trace.Write("   ");
                }
            }
        }
    }
}
