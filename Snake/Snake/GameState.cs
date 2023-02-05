using System.Diagnostics;
using System.Text;

namespace Snake;

public class GameState
{
    private readonly int _topWallPosition;
    private readonly int _rightWallPosition;
    private readonly int _bottomWallPosition;
    private readonly int _leftWallPosition;

    private Stopwatch _gameTimer { get; set; }

    public BoardPositionType[,] Board { get; set; }
    public (int x, int y) StartingPosition { get; set; }
    public (int x, int y) ApplePosition { get; set; }
    public Snake Snake { get; set; }
    public int Score { get; set; }
    public int Speed { get; set; }
    private ISnakeDisplay _display{ get; set; }


    public GameState(int boardHeight, int boardWidth, ISnakeDisplay display)
    {
        Board = new BoardPositionType[boardHeight, boardWidth];

        _topWallPosition = 0;
        _rightWallPosition = boardWidth - 1;
        _bottomWallPosition = boardHeight - 1;
        _leftWallPosition = 0;

        InitializeBoard(Board);
        Snake = new Snake((boardHeight / 2, boardWidth / 2), 3);
        ApplePosition = GetNewApplePosition();
        Score = 0;
        Speed = 500;

        _display = display;

        _gameTimer = new Stopwatch();
        _gameTimer.Start();
    }

    private void InitializeBoard(BoardPositionType[,] board)
    {
        for (int i = 0; i <= _bottomWallPosition; i++)
        {
            for (int j = 0; j <= _rightWallPosition; j++)
            {
                if (i == 0 || j == 0 || i == _bottomWallPosition || j == _rightWallPosition)
                {
                    board[i, j] = BoardPositionType.Wall;
                }
                else
                {
                    board[i, j] = BoardPositionType.Blank;
                }
            }
        }
    }

    public void DrawBoard()
    {
        BoardPositionType[,] outputBoard = (BoardPositionType[,])Board.Clone();

        for (int i = 0; i <= _bottomWallPosition; i++)
        {
            for (int j = 0; j <= _rightWallPosition; j++)
            {
                if (Snake.IsHere((i, j)))
                {
                    if (Snake.IsHead((i, j)))
                    {
                        outputBoard[i, j] = BoardPositionType.Head;
                    }
                    else if (Snake.IsTail((i, j)))
                    {
                        outputBoard[i, j] = BoardPositionType.Tail;
                    }
                    else
                    {
                        outputBoard[i, j] = BoardPositionType.Body;
                    }
                }
                else if (ApplePosition == (i, j))
                {
                    outputBoard[i, j] = BoardPositionType.Apple;
                }
            }
        }
        _display.DisplayBoard(outputBoard);
    }

    public void DoGameLoop(bool moveOverride)
    {
        if (_gameTimer.ElapsedMilliseconds >= Speed || moveOverride)
        {
            if (GameOverCollision())
            {
                _display.DisplayGameOver();
                Thread.Sleep(5000);                
                Environment.Exit(0); // probably don't need to exit, retry? y/n
            }

            var appleEaten = WillTheSnakeEatAnApple();
            if (appleEaten)
            {
                ApplePosition = GetNewApplePosition();
                Score += Speed;
                Console.Beep();
            }
            Snake.Move(appleEaten);

            DrawBoard();
            _display.DisplayScore(Score);
            _gameTimer.Restart();
        }
    }

    public (int x, int y) GetNewApplePosition()
    {
        (int x, int y) applePosition;
        do
        {
            applePosition = (Random.Shared.Next(1, _bottomWallPosition - 1), Random.Shared.Next(1, _rightWallPosition - 1));
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
        return nextHeadPosition.x <= _topWallPosition ||
                nextHeadPosition.y >= _rightWallPosition ||
                nextHeadPosition.x >= _bottomWallPosition ||
                nextHeadPosition.y <= _leftWallPosition;
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

public enum BoardPositionType
{
    Wall,
    Blank,
    Head,
    Body,
    Tail,
    Apple
}