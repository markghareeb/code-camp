using System.Diagnostics;
using System.Text;

namespace Snake
{
    internal class GameState
    {
        private const char HEAD = 'H';
        private const char BODY = 'S';
        private const char TAIL = 'T';
        private const char WALL = 'X';
        private const char APPLE = 'A';
        private const char BLANK = ' ';

        private readonly int topWallPosition;
        private readonly int rightWallPosition;
        private readonly int bottomWallPosition;
        private readonly int leftWallPosition;

        private Stopwatch gameTimer { get; set; }

        public char[,] Board { get; set; }
        public (int x, int y) StartingPosition { get; set; }
        public (int x, int y) ApplePosition { get; set; }
        public Snake Snake { get; set; }
        public int Score { get; set; }
        public int Speed { get; set; }
        

        public GameState(int boardHeight, int boardWidth)
        {
            Board = new char[boardHeight, boardWidth];

            topWallPosition = 0;
            rightWallPosition = boardWidth - 1;
            bottomWallPosition = boardHeight - 1;
            leftWallPosition = 0;

            InitializeBoard(Board);
            Snake = new Snake((boardHeight/2, boardWidth/2), 3);
            ApplePosition = GetNewApplePosition();
            Score = 0;
            Speed = 500;

            gameTimer = new Stopwatch();
            gameTimer.Start();
        }

        private void InitializeBoard(char[,] board) 
        { 
            for (int i = 0; i <= bottomWallPosition; i++) 
            { 
                for (int j = 0; j <= rightWallPosition; j++)
                {
                    if (i == 0 || j == 0 || i == bottomWallPosition || j == rightWallPosition)
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

            for (int i = 0; i <= bottomWallPosition; i++)
            {
                for (int j = 0; j <= rightWallPosition; j++)
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

        public void DoGameLoop(bool moveOverride)
        {
            if (gameTimer.ElapsedMilliseconds >= Speed || moveOverride)
            {
                if (GameOverCollision())
                {
                    Console.Beep();
                    Console.WriteLine("YOU LOSE");
                    Environment.Exit(0);
                }

                var appleEaten = WillTheSnakeEatAnApple();
                if (appleEaten)
                {
                    ApplePosition = GetNewApplePosition();
                    Score += Speed;
                    Console.Beep();
                }
                Snake.Move(appleEaten);

                Console.SetCursorPosition(0, 0);
                DrawBoard();
                Console.WriteLine(Score);
                gameTimer.Restart();
            }
        }

        public (int x, int y) GetNewApplePosition()
        {
            // generate a random x and y coordinate for the apple position 
            // make sure the apple position isn't in the wall or snake!
            // return the apple position

            return (20, 20);
        }

        public bool GameOverCollision()
        {
            // get the next position of a snake head
            // check if the position is the same as the wall
            // check if the position is the same as the snake body

            return false;
        }
        
        public bool WallHit((int x, int y) nextHeadPosition)
        {
            return nextHeadPosition.x <= topWallPosition ||
                   nextHeadPosition.y >= rightWallPosition || 
                   nextHeadPosition.x >= bottomWallPosition ||
                   nextHeadPosition.y <= leftWallPosition;
        }

        public bool BodyHit((int x, int y) nextHeadPosition)
        {
            return Snake.IsHere(nextHeadPosition);
        }

        public bool WillTheSnakeEatAnApple()
        {
            // get the next position of a snake head
            // get the position of the apple
            // if they match, return true, otherwise return false

            return false;
        }
    }
}
