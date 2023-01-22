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
        public int Score { get; set; }
        public int Speed { get; set; }
        public GameState()
        {
            //consider setting read-only vars for wall positions
            Board = new char[20, 20];
            InitializeBoard(Board);
            //parameterize snake? 
            Snake = new Snake((10, 10), 3);
            ApplePosition = GetApplePosition();
            Score = 0;
            Speed = 500;
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

        public bool GameOverCollision()
        {
            var nextHeadPosition = Snake.CalculateNewHead();
            return WallHit(nextHeadPosition) || BodyHit(nextHeadPosition);
        }
        
        public bool WallHit((int x, int y) nextHeadPosition)
        {
            return nextHeadPosition.x <= 0 || // checks top wall 
                   nextHeadPosition.x >= Board.GetLength(0) - 1 || // checks bottom wall 
                   nextHeadPosition.y <= 0 || // checks left wall 
                   nextHeadPosition.y >= Board.GetLength(1) - 1; // checks right wall 
        }

        public bool BodyHit((int x, int y) nextHeadPosition)
        {
            return Snake.IsHere(nextHeadPosition);
        }

        public bool WillTheSnakeEatAnApple()
        {
            var nextHeadPosition = Snake.CalculateNewHead();
            return AppleHit(nextHeadPosition);
        }

        public bool AppleHit((int x, int y) nextHeadPosition)
        {
            return nextHeadPosition == ApplePosition;
        }
    }
}
