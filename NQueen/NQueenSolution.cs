using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NQueen
{
    class NQueenSolution
    {
        static void Main(string[] args)
        {
            var soln = new Solution();
            var answer = soln.SolveNQueens(1);
            string json = JsonConvert.SerializeObject(answer, Formatting.Indented);
            Console.WriteLine(json);
            Console.ReadLine();
        }

        public class Solution
        {
            static IList<IList<string>> result;
            public IList<IList<string>> SolveNQueens(int n)
            {
                result = new List<IList<string>>();
                //Initialize all element of n*n 2-d array to .
                char[,] board = new char[n, n];
                initializeBoard(board);
                solve(board, 0, 0, 0);

                return result;
            }

            private void initializeBoard(char[,] board)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(0); j++)
                    {
                        board[i, j] = '.';
                    }
                }
            }

            private void solve(char[,] board, int stRow, int stCol, int placedQueens)
            {
                int n = board.GetLength(0);
                if (stRow > n || stCol > n)
                    return;
                if (placedQueens == n)
                    deepCloneAndStoreResult(board);
                else
                {
                    for (int r = stRow; r < n; r++)//row
                    {
                        bool queenPlaced = false; //optimization - does queen placed in any of the column in this row i
                        for (int c = stCol; c < n; c++)//column
                        {
                            if(!doesAttackOtherQueen(board, r, c))
                            {
                                queenPlaced = true;
                                placeQueen(board, r, c);
                                solve(board, stRow + 1, stCol, placedQueens + 1);
                                removeQueen(board, r, c);
                            }
                        }
                            if (!queenPlaced)
                                return; //No further probation is needed
                    }
                }
            }

            private bool doesAttackOtherQueen(char[,] board, int r, int c)
            {
                return attackInRowProfile(board, r, c) || attackInColumnProfile(board, r, c) || attackInDiagonal(board, r, c);
            }

            private bool attackInDiagonal(char[,] board, int r, int c)
            {
                return leftUp(board, r, c) || leftDown(board, r, c) || rightUp(board, r, c) || rightDown(board, r, c);
            }

            private bool rightDown(char[,] board, int r, int c)
            {
                int n = board.GetLength(0);
                for (int i = 0; i < n; i++)
                {
                    if (r + i >= n || c + i >= n)//outside board so return as false
                        return false;
                    if (board[r + i, c + i] == 'Q')
                        return true;
                }
                return false;
            }

            private bool rightUp(char[,] board, int r, int c)
            {
                int n = board.GetLength(0);
                for (int i = 0; i < n; i++)
                {
                    if (r - i < 0 || c + i >= n)//outside board so return as false
                        return false;
                    if (board[r - i, c + i] == 'Q')
                        return true;
                }
                return false;
            }

            private bool leftDown(char[,] board, int r, int c)
            {
                int n = board.GetLength(0);
                for (int i = 0; i < n ; i++)
                {
                    if (r + i >= n || c - i < 0)//outside board so return as false
                        return false;
                    if (board[r + i, c - i] == 'Q')
                        return true;
                }
                return false;
            }

            private bool leftUp(char[,] board, int r, int c)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (r - i < 0 || c - i < 0)//outside board so return as false
                        return false;
                    if (board[r - i, c - i] == 'Q')
                        return true;
                }
                return false;
            }

            private bool attackInColumnProfile(char[,] board, int r, int c)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (board[r, i] == 'Q')
                        return true;
                }
                return false;
            }
            private bool attackInRowProfile(char[,] board, int r, int c)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (board[i, c] == 'Q')
                        return true;
                }
                return false;
            }
            private void deepCloneAndStoreResult(char[,] board)
            {
                List<string> temp = new List<string>();
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    string rowStr = string.Join(string.Empty, GetRow(board, i));
                    temp.Add(rowStr);
                }
                result.Add(temp);
            }
            public char[] GetRow(char[,] matrix, int rowNumber)
            {
                return Enumerable.Range(0, matrix.GetLength(1))
                        .Select(x => matrix[rowNumber, x])
                        .ToArray();
            }
            private void placeQueen(char[,] board, int r, int c)
            {
                board[r,c] = 'Q';
            }
            private void removeQueen(char[,] board, int r, int c)
            {
                board[r,c] = '.';
            }
        }
    }
}
