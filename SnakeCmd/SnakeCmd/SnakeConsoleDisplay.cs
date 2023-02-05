using Snake;

namespace SnakeCmd;

internal class SnakeConsoleDisplay : ISnakeDisplay
{
    private const char Wall = 'X';
    private const char Blank = ' ';
    private const char Head = 'H';
    private const char Body = 'S';
    private const char Tail = 'T';
    private const char Apple = 'A';

    private Dictionary<BoardPositionType, char> _boardPositionOutput = new Dictionary<BoardPositionType, char> { 
                                                                         { BoardPositionType.Wall, Wall },
                                                                         { BoardPositionType.Blank, Blank },
                                                                         { BoardPositionType.Head, Head },
                                                                         { BoardPositionType.Body, Body },
                                                                         { BoardPositionType.Tail, Tail },
                                                                         { BoardPositionType.Apple, Apple } 
                                                                        };

    public void DisplayBoard(BoardPositionType[,] outputBoard)
    {
        Console.SetCursorPosition(0, 0);
        var output = "";
        for (int i = 0; i <= outputBoard.GetLength(0) - 1; i++)
        {
            for (int j = 0; j <= outputBoard.GetLength(1) - 1; j++)
            {
                output += _boardPositionOutput[outputBoard[i, j]];
            }
            output += Environment.NewLine;
        }
        Console.Write(output);
    }

    public void DisplayScore(int score)
    {
        Console.WriteLine("Score");
        Console.WriteLine(score);
    }

    public void DisplayGameOver()
    {
        Console.Beep();
        Console.WriteLine("YOU LOSE");
    }

}
