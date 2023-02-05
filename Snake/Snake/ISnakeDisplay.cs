namespace Snake;

public interface ISnakeDisplay
{
    public void DisplayBoard(BoardPositionType[,] outputBoard);
    public void DisplayScore(int score);
    public void DisplayGameOver();
}
