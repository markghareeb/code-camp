using RockPaperScissors;

public class GameProcessor
{
    public enum Moves
    {
        None = 0,
        Rock = 1,
        Paper = 2,
        Scissors = 3
    };

    public enum GameState
    {
        Draw = 0,
        PlayerLost,
        PlayerWon
    }

    public static GameState DetermineWinner(Moves playerMove, Moves opponentMove)
    {
        if ((playerMove == Moves.Rock && opponentMove == Moves.Scissors) 
            || (playerMove == Moves.Paper && opponentMove == Moves.Rock)
            || (playerMove == Moves.Scissors && opponentMove == Moves.Paper))
        {
            return GameState.PlayerWon;
        }
        else if (playerMove == opponentMove)
        {
            return GameState.Draw;
        }
        else
        {
            return GameState.PlayerLost;
        }
    }
}