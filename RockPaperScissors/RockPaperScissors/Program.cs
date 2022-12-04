using RockPaperScissors;
using static GameProcessor;

Console.WriteLine("Time to play rock paper scissors!");
Console.WriteLine("Play until you can beat your opponent!");
Console.WriteLine("Pick your move!");
Console.WriteLine("Rock = 1, Paper = 2, Scissors = 3");

var player = new ConsolePlayer();
var opponent = new RandomPlayer();

var gameOver = false;
while (!gameOver)
{
    Console.WriteLine();
    var playerMove = Moves.None;
    var opponentMove = Moves.None;

    playerMove = player.GetMove();
    opponentMove = opponent.GetMove();

    Console.WriteLine($"You picked {playerMove}");
    Console.WriteLine($"Your opponent picked {opponentMove}");

    var gameState = DetermineWinner(playerMove, opponentMove);

    if (gameState == GameState.PlayerWon)
    {
        Console.WriteLine($"{playerMove} beats {opponentMove}, you win!");
        gameOver = true;
    }
    else if (gameState == GameState.PlayerLost)
    {
        Console.WriteLine($"{opponentMove} beats {playerMove}, try again!");
    }
    else
    {
        Console.WriteLine("Draw! Try again!");
    }
}