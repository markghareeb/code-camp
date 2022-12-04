namespace RockPaperScissors.Test
{
    internal class RockOpponent : IPlayer
    {
        public GameProcessor.Moves GetMove()
        {
            return GameProcessor.Moves.Rock;
        }
    }

    internal class PaperOpponent : IPlayer
    {
        public GameProcessor.Moves GetMove()
        {
            return GameProcessor.Moves.Paper;
        }
    }

    internal class ScissorsOpponent : IPlayer
    {
        public GameProcessor.Moves GetMove()
        {
            return GameProcessor.Moves.Scissors;
        }
    }
}
