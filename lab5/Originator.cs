using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Originator
    {
        private char[,] board;

        public Originator()
        {
            board = InitBoard();
        }

        public void PlayMove(int row, int col, char symbol)
        {
            board[row, col] = symbol;
        }

        public Memento SaveState()
        {
            char[,] clonedBoard = (char[,])board.Clone();
            return new Memento(clonedBoard);
        }

        public void RestoreState(Memento memento)
        {
            board = memento.Board;
        }

        public bool IsWon()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
                else if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return true;
                }
            }
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[2, 2] != ' ' && board[2, 2] == board[1, 1] && board[1, 1] == board[0, 0])
            {
                return true;
            }
            return false;
        }

        public bool IsDraw()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public char[,] GetBoard()
        {
            return board;
        }

        private char[,] InitBoard()
        {
            char[,] initialBoard = new char[3, 3];
            for (int i = 0; i < initialBoard.GetLength(0); i++)
            {
                for (int j = 0; j < initialBoard.GetLength(1); j++)
                {
                    initialBoard[i, j] = ' ';
                }
            }
            return initialBoard;
        }
    }
}
