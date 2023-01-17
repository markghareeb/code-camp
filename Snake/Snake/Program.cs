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
                    // detect collision
                    // // based apple position, if snake head is about to eat the apple, pass in a true; else false
                    gameState.Snake.Move(gameState.ApplePosition);
                    
                    // // snake head == a wall
                    // // snake head == snake linked list position
                    // // bonus for speed for better score

                    Console.SetCursorPosition(0, 0);
                    gameState.DrawBoard();
                    // maybe eating apples increases this? game state has a var for it?
                    // every x number of apples eaten or score threshold is passed, decrease sleep by 10 or 20 percent
                    // // or milliseconds or something
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