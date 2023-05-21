using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class GameFunctionality
    {
        public static void ShowRules()
        {
            Console.WriteLine("Rules of Tic-Tac-Toe:");
            Console.WriteLine("\t1.Two players take turns marking spaces on a 3x3 grid.");
            Console.WriteLine("\t2.The first player to get three of their symbols in a row wins.");
            Console.WriteLine("\t3.If the board fills up before either player wins, the game is a draw.");
        }

        public static char SetSettings()
        {
            Random rnd = new Random();
            Console.WriteLine("Choose 'X' or 'O' or random(r)");
            char player = Console.ReadLine()[0];

            if (player == 'X' || player == 'O')
            {
                return player;
            }
            else
            {
                int num = rnd.Next(0, 2);
                player = (num == 0) ? 'O' : 'X';
                return player;
            }
        }

        public static void StartGame(char player)
        {
            Console.WriteLine("Game start");
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();
            char[,] board = originator.GetBoard();
            Console.WriteLine("Init board: ");
            ShowBoard(board);
            int coordI, coordJ;
            while (true)
            {
                Console.WriteLine($"Player: {player}");
                do
                {
                    Console.Write("Enter num of row (i): ");
                    coordI = EnterCoords();
                    Console.Write("Enter num of col (j): ");
                    coordJ = EnterCoords();
                } while (coordI < 0 || coordI > 2 || coordJ < 0 || coordJ > 2 || board[coordI, coordJ] != ' ');

                char playSymb = player;
                board[coordI, coordJ] = playSymb;

                Console.WriteLine();
                ShowBoard(board);
                Console.WriteLine();

                if (originator.IsWon())
                {
                    Console.WriteLine($"Player {player} has won");
                    Console.WriteLine("Finish\n");
                    break;
                }
                else if (originator.IsDraw())
                {
                    Console.WriteLine($"The game is a draw");
                    Console.WriteLine("Finish\n");
                    break;
                }

                caretaker.SaveState(originator.SaveState()); // Save the current state before changing the player

                if (player == 'X')
                {
                    player = 'O';
                }
                else
                {
                    player = 'X';
                }

                Console.WriteLine("Do you want to undo the last move? (y/n)");
                char choice = Console.ReadLine()[0];
                if (choice == 'y' && caretaker.Undo() != null)
                {
                    originator.RestoreState(caretaker.Undo());
                    board = originator.GetBoard();
                    Console.WriteLine();
                    ShowBoard(board);
                    Console.WriteLine();
                    if (player == 'X')
                    {
                        player = 'O';
                    }
                    else
                    {
                        player = 'X';
                    }
                }
            }
            ShowBoard(board);
        }

        public static void ShowBoard(char[,] board)
        {
            Console.WriteLine("---------");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"|{board[i, j]}|");
                }
                Console.WriteLine("\n---------");
            }
        }

        public static int EnterCoords()
        {
            int coord;
            coord = int.Parse(Console.ReadLine());
            return coord;
        }
    }
}
