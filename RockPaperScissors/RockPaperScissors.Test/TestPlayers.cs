namespace RockPaperScissors.Test
{
    internal class RockPlayer : IPlayer
    {
        public GameProcessor.Moves GetMove()
        {
            return GameProcessor.Moves.Rock;
        }
    }

    internal class PaperPlayer : IPlayer
    {
        public GameProcessor.Moves GetMove()
        {
            return GameProcessor.Moves.Paper;
        }
    }

    internal class ScissorsPlayer : IPlayer
    {
        public GameProcessor.Moves GetMove()
        {
            return GameProcessor.Moves.Scissors;
        }
    }
}
