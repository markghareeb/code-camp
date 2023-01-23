namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameState = new GameState(30, 30);
            Console.Clear();
            bool moveOverride = false;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    gameState.Snake.UpdateDirection(Console.ReadKey(false));
                    moveOverride = true;
                }
                gameState.DoGameLoop(moveOverride);
                moveOverride = false;
            }
        }
    }
}