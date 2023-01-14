namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameState = new GameState();

            while (true)
            {
                gameState.Snake.Move();
                gameState.DrawBoard();
                if (Console.KeyAvailable)
                {
                    gameState.Snake.UpdateDirection(Console.ReadKey(false));
                }
                
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}