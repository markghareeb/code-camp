using static GameProcessor;

namespace RockPaperScissors.Test
{
    public class GameProcessorTests
    {
        private IPlayer rockPlayer;
        private IPlayer paperPlayer;
        private IPlayer scissorsPlayer;

        public GameProcessorTests()
        {
            rockPlayer = new RockPlayer();
            paperPlayer = new PaperPlayer();
            scissorsPlayer = new ScissorsPlayer();
        }

        [Fact]
        public void CheckGameStateForRockWin()
        {
            var gameState = DetermineWinner(rockPlayer.GetMove(), scissorsPlayer.GetMove());
            Assert.Equal(GameState.PlayerWon, gameState);
        }
        
        [Fact]
        public void CheckGameStateForPaperWin()
        {
            var gameState = DetermineWinner(paperPlayer.GetMove(), rockPlayer.GetMove());
            Assert.Equal(GameState.PlayerWon, gameState);
        }

        [Fact]
        public void CheckGameStateForScissorsWin()
        {
            var gameState = DetermineWinner(scissorsPlayer.GetMove(), paperPlayer.GetMove());
            Assert.Equal(GameState.PlayerWon, gameState);
        }

        [Fact]
        public void CheckGameStateForRockLoss()
        {
            var gameState = DetermineWinner(rockPlayer.GetMove(), paperPlayer.GetMove());
            Assert.Equal(GameState.PlayerLost, gameState);
        }
        
        [Fact]
        public void CheckGameStateForPaperLoss()
        {
            var gameState = DetermineWinner(paperPlayer.GetMove(), scissorsPlayer.GetMove());
            Assert.Equal(GameState.PlayerLost, gameState);
        }

        [Fact]
        public void CheckGameStateForScissorsLoss()
        {
            var gameState = DetermineWinner(scissorsPlayer.GetMove(), rockPlayer.GetMove());
            Assert.Equal(GameState.PlayerLost, gameState);
        }

        [Fact]
        public void CheckGameStateForRockDraw()
        {
            var gameState = DetermineWinner(rockPlayer.GetMove(), rockPlayer.GetMove());
            Assert.Equal(GameState.Draw, gameState);
        }

        [Fact]
        public void CheckGameStateForPaperDraw()
        {
            var gameState = DetermineWinner(paperPlayer.GetMove(), paperPlayer.GetMove());
            Assert.Equal(GameState.Draw, gameState);
        }

        [Fact]
        public void CheckGameStateForScissorsDraw()
        {
            var gameState = DetermineWinner(scissorsPlayer.GetMove(), scissorsPlayer.GetMove());
            Assert.Equal(GameState.Draw, gameState);
        }
    }
}