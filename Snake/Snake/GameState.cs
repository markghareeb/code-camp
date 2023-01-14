using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class GameState
    {
        //should we do this? 
        private const char HEAD = 'H';
        private const char BODY = 'S';
        private const char TAIL = 'T';
        private const char WALL = 'X';
        private const char BLANK = ' ';
        
        public char[,] Board { get; set; }
        public (int x, int y) StartingPosition { get; set; }
        public Snake Snake { get; set; }

        public GameState()
        {
            Board = new char[40, 40];
            InitializeBoard(Board);
            //parameterize snake? 
            Snake = new Snake((20, 20), 3);
        }

        private static void InitializeBoard(char[,] board) 
        { 
            for (int i = 0; i < board.GetLength(0); i++) 
            { 
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (i == 0 || y == 0 || i == board.GetLength(0) - 1 || y == board.GetLength(1) - 1)
                    {
                        board[i, y] = WALL;
                    }
                    else
                    {
                        board[i, y] = BLANK;
                    }
                }
            }
        }

        public void DrawBoard()
        {
            StringBuilder board = new StringBuilder();

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int y = 0; y < Board.GetLength(1); y++)
                {
                    if (Snake.IsHere((i, y)))
                    {
                        if (Snake.IsHead((i, y)))
                        {
                            board.Append(HEAD);
                        }
                        else if (Snake.IsTail((i, y)))
                        {
                            board.Append(TAIL);
                        }
                        else
                        {
                            board.Append(BODY);
                        }
                    }
                    else
                    {
                        board.Append(Board[i, y]);
                    }
                }
                board.AppendLine();
            }
            Console.Write(board.ToString());
        }
    }
}
