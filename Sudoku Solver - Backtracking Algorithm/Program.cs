using System;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Transactions;

namespace Sudoku_Solver___Backtracking_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] sudokuBoard = new int[,]
            {
            {3, 0, 0, 0, 0, 8, 0, 0, 0},
            {7, 0, 8, 3, 2, 0, 0, 0, 5},
            {0, 0, 0, 9, 0, 0, 0, 1, 0},
            {9, 0, 0, 0, 0, 4, 0, 2, 0},
            {0, 0, 0, 0, 1, 0, 0, 0, 0},
            {0, 7, 0, 8, 0, 0, 0, 0, 9},
            {0, 5, 0, 0, 0, 3, 0, 0, 0},
            {8, 0, 0, 0, 4, 7, 5, 0, 3},
            {0, 0, 0, 5, 0, 0, 0, 0, 6}
            };

            if (SudokuSolver(sudokuBoard))
            {
                PrintMatrix(sudokuBoard);
            }
            else
            {
                Console.WriteLine("This Sudoku cannot be solved!");
            }
        }

        static bool SudokuSolver(int[,] board)
        {
            int currentRow = -1;
            int currentCol = -1;

            bool isEmpty = true;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 0)
                    {
                        currentRow = row;
                        currentCol = col;

                        isEmpty = false;
                        break;
                    }
                }
                if (isEmpty == false)
                {
                    break;
                }
            }

            if (isEmpty)
            {
                return true;
            }

            for (int num = 1; num <= board.GetLength(0); num++)
            {
                if (IsTheRightNumber(board, currentRow, currentCol, num))
                {
                    board[currentRow, currentCol] = num;

                    if (SudokuSolver(board))
                    {
                        return true;
                    }
                    else
                    {
                        board[currentRow, currentCol] = 0;
                    }

                }
            }

            return false;
        }

        static bool IsTheRightNumber(int[,] board, int currentRow, int currentCol, int num)
        {

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[currentRow, col] == num)
                {
                    return false;
                }
            }

            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (board[row, currentCol] == num)
                {
                    return false;
                }
            }

            int squareroot = (int)Math.Sqrt(board.GetLength(0));
            int rowStart = currentRow - currentRow % squareroot;
            int colStart = currentCol - currentCol % squareroot;

            for (int row = rowStart; row < rowStart + squareroot; row++)
            {
                for (int col = colStart; col < colStart + squareroot; col++)
                {
                    if (board[row, col] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void PrintMatrix(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {

                    Console.Write(board[row,col] + " ");

                }
                Console.WriteLine();
            }
        }
    }
}
