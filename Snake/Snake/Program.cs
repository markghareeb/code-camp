namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameState = new GameState();
            Console.Clear();
            while (true)
            {
                if(!Console.KeyAvailable) //consider flipping this logic to else
                {
                    if (gameState.GameOverCollision())
                    {
                        Console.Beep();
                        Console.WriteLine("YOU LOSE");
                        Environment.Exit(0);
                    }

                    var appleEaten = gameState.WillTheSnakeEatAnApple();
                    if (appleEaten)
                    {
                        gameState.ApplePosition = gameState.GetApplePosition();
                        gameState.Score += gameState.Speed;
                        Console.Beep();
                    }
                    gameState.Snake.Move(appleEaten);                    

                    Console.SetCursorPosition(0, 0);
                    gameState.DrawBoard();
                    Console.WriteLine(gameState.Score);
                    // // bonus for speed for better score
                    // maybe eating apples increases this? game state has a var for it?
                    // every x number of apples eaten or score threshold is passed, decrease sleep by 10 or 20 percent
                    // // or milliseconds or something
                    Thread.Sleep(gameState.Speed);
                }
                else
                {
                    gameState.Snake.UpdateDirection(Console.ReadKey(false));
                }
                /*
                if (Console.KeyAvailable) { gameState.Snake.UpdateDirection(Console.ReadKey(false)); }
                if (gameState.Timer.Elapsed > 1000) {  doTheOtherThings() }
                */            
            }
        }
    }
}