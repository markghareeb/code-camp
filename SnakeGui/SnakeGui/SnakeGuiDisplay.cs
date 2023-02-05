using Snake;

namespace SnakeGui;

class SnakeGuiDisplay : ISnakeDisplay
{
    private ICanvas _canvas;
    
    public SnakeGuiDisplay(ICanvas canvas)
    {
        _canvas = canvas;
        var gameState = new GameState(40, 40, new SnakeGuiDisplay(canvas));
        Task.Run(async () =>
        {
            gameState.DoGameLoop(false);
        });
    }

    public void DisplayBoard(BoardPositionType[,] outputBoard)
    {
        throw new NotImplementedException();
    }

    public void DisplayScore(int score)
    {
        throw new NotImplementedException();
    }

    public void DisplayGameOver()
    {
        throw new NotImplementedException();
    }
}
