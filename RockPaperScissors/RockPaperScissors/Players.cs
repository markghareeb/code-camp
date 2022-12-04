using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using static GameProcessor;

namespace RockPaperScissors
{
    public interface IPlayer
    {
        Moves GetMove();
    }

    class ConsolePlayer : IPlayer
    {
        public Moves GetMove()
        {
            string input;
            Moves playerMove = Moves.None;

            do
            {
                input = Console.ReadLine();
                if (!Enum.TryParse(input, out playerMove))
                {
                    Console.WriteLine("Invalid move, try again!");
                }
            } while (input == null || playerMove == Moves.None);

            return playerMove;
        }
    }

    class RandomPlayer : IPlayer
    {
        public Moves GetMove()
        {
            return (Moves)Random.Shared.Next(1, 4);
        }

    }

    
}
