namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameState = new GameState();

            while (true)
            {
                if(!Console.KeyAvailable)
                {
                    gameState.Snake.Move(gameState.ApplePosition);
                    Console.SetCursorPosition(0, 0);
                    gameState.DrawBoard();
                    Thread.Sleep(100);
                }
                else
                {
                    gameState.Snake.UpdateDirection(Console.ReadKey(false));
                }
            }
        }
    }
}