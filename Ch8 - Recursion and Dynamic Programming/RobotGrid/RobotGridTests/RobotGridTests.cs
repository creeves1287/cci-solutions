using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotGrid;

namespace RobotGridTests
{
    [TestClass]
    public class RobotGridTests
    {
        [TestMethod]
        public void MyRobotGridTraverserTests()
        {
            IRobotGridTraverser robotGridTraverser = new MyRobotGridTraverser();
            RunTests(robotGridTraverser);
        }

        [TestMethod]
        public void TextbookRobotGridTraverserTests()
        {
            IRobotGridTraverser robotGridTraverser = new TextbookRobotGridTraverser();
            RunTests(robotGridTraverser);
        }

        private void RunTests(IRobotGridTraverser robotGridTraverser)
        {
            TraverseGridNoObstaclesTest(robotGridTraverser);
        }

        private void TraverseGridNoObstaclesTest(IRobotGridTraverser robotGridTraverser)
        {
            int rows = 100,
                columns = 100;
            Cell[][] grid = ConstructGrid(rows, columns);
            PopulateGrid(grid, 0.2);
            char[][] gridDrawing = ConstructDrawingGrid(rows, columns);
            LinkedListNode path = robotGridTraverser.TraverseGrid(grid);
            PopulateDrawingGrid(gridDrawing, grid);
            DrawPath(grid, path, gridDrawing);
            DrawGrid(gridDrawing);
        }

        private Cell[][] ConstructGrid(int rows, int columns)
        {
            Cell[][] grid = new Cell[rows][];
            for (int i = 0; i < rows; i++)
            {
                grid[i] = new Cell[columns];
            }
            return grid;
        }

        private char[][] ConstructDrawingGrid(int rows, int columns)
        {
            char[][] grid = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                grid[i] = new char[columns];
            }
            return grid;
        }

        private void PopulateGridNoObstacles(Cell[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    grid[i][j] = new Cell();
                }
            }
        }

        private void PopulateGrid(Cell[][] grid, double percentObstacles)
        {
            Random r = new Random();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    grid[i][j] = new Cell();
                    double obstacle = r.NextDouble();
                    if (obstacle <= percentObstacles)
                    {
                        grid[i][j].IsValid = false;
                    }
                }
            }
        }

        private void PopulateDrawingGrid(char[][] gridDrawing, Cell[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    Cell cell = grid[i][j];
                    if (cell.IsValid || (i == 0 && j == 0) || (i == grid.Length - 1 && j == grid[0].Length - 1))
                    {
                        gridDrawing[i][j] = '-';
                    }
                    else
                    {
                        gridDrawing[i][j] = 'x';
                    }
                }
            }
        }

        private void DrawGrid(char[][] gridDrawing)
        {
            for (int i = 0; i < gridDrawing.Length; i++)
            {
                for (int j = 0; j < gridDrawing[0].Length; j++)
                {
                    Trace.Write("   " + gridDrawing[i][j] + "   ");
                    if (j == gridDrawing[0].Length - 1)
                    {
                        Trace.Write("\n");
                    }
                }
            }
        }

        private void DrawPath(Cell[][] grid, LinkedListNode path, char[][] drawingGrid)
        {
            if (path == null) return;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    Cell cell = grid[i][j];
                    if (cell == path.Value && path != null)
                    {
                        drawingGrid[i][j] = '*';
                        path = path.Next;
                    }
                }
            }
        }
    }
}
