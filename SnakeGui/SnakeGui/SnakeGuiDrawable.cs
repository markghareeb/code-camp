using Snake;

namespace SnakeGui;

class SnakeGuiDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Green;
        canvas.StrokeSize = 4;
        canvas.DrawRectangle(10, 10, 100, 100);
    }  
}
