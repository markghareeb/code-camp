using System.Text;

namespace Snake
{
    internal class GameState
    {
        //should we do this? 
        private const char HEAD = 'H';
        private const char BODY = 'S';
        private const char TAIL = 'T';
        private const char WALL = 'X';
        private const char APPLE = 'A';
        private const char BLANK = ' ';
        
        public char[,] Board { get; set; }
        public (int x, int y) StartingPosition { get; set; }
        public (int x, int y) ApplePosition { get; set; }
        public Snake Snake { get; set; }

        public GameState()
        {
            Board = new char[20, 20];
            InitializeBoard(Board);
            //parameterize snake? 
            Snake = new Snake((10, 10), 3);
            ApplePosition = GetApplePosition();
        }

        private static void InitializeBoard(char[,] board) 
        { 
            for (int i = 0; i < board.GetLength(0); i++) 
            { 
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i == board.GetLength(0) - 1 || j == board.GetLength(1) - 1)
                    {
                        board[i, j] = WALL;
                    }
                    else
                    {
                        board[i, j] = BLANK;
                    }
                }
            }
        }

        public void DrawBoard()
        {
            StringBuilder board = new StringBuilder();

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    //this 100,000 percent needs to go somewhere else
                    if (Snake.IsHere((i, j)) && ApplePosition == (i, j))
                    {
                        ApplePosition = GetApplePosition();
                    }

                    if (Snake.IsHere((i, j)))
                    {
                        if (Snake.IsHead((i, j)))
                        {
                            board.Append(HEAD);
                        }
                        else if (Snake.IsTail((i, j)))
                        {
                            board.Append(TAIL);
                        }
                        else
                        {
                            board.Append(BODY);
                        }
                    }
                    else if (ApplePosition == (i, j))
                    {
                        board.Append(APPLE);
                    }
                    else
                    {
                        board.Append(Board[i, j]);
                    }
                }
                board.AppendLine();
            }
            Console.Write(board.ToString());
        }

        public (int x, int y) GetApplePosition()
        {
            (int x, int y) applePosition;
            do
            {
                applePosition = (Random.Shared.Next(1, Board.GetLength(0) - 1), Random.Shared.Next(1, Board.GetLength(1) - 1));
            } while (Snake.IsHere(applePosition));
            return applePosition;
        }
    }
}
