namespace TennisApp {
    public class TennisGameTests {

        [Fact]
        public void PlayerOneScoresOnce_ShouldBe_15_Love() {
            TennisGame game = new TennisGame();
            game.PlayerOneScores();
            string score = game.GetScore();
            Assert.Equal("15-0", score);
        }

        [Fact]
        public void PlayerTwoScoresOnce_ShouldBe_Love_15() {
            TennisGame game = new TennisGame();
            game.PlayerTwoScores();
            string score = game.GetScore();
            Assert.Equal("0-15", score);
        }

        [Fact]
        public void PlayerOneScoresTwice_ShouldBe_30_Love() {
            TennisGame game = new TennisGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            string score = game.GetScore();
            Assert.Equal("30-0", score);
        }

        [Fact]
        public void PlayerTwoScoresTwice_ShouldBe_Love_30() {
            TennisGame game = new TennisGame();
            game.PlayerTwoScores();
            game.PlayerTwoScores();
            string score = game.GetScore();
            Assert.Equal("0-30", score);
        }

        [Fact]
        public void PlayerOneScoresThrice_ShouldBe_40_Love() {
            TennisGame game = new TennisGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerOneScores();
            string score = game.GetScore();
            Assert.Equal("40-0", score);
        }

        [Fact]
        public void PlayerTwoScoresThrice_ShouldBe_Love_40() {
            TennisGame game = new TennisGame();
            game.PlayerTwoScores();
            game.PlayerTwoScores();
            game.PlayerTwoScores();
            string score = game.GetScore();
            Assert.Equal("0-40", score);
        }

        [Fact]
        public void PlayerOneScoresFourTimes_ShouldBe_PlayerOne_Wins() {
            TennisGame game = new TennisGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerOneScores();
            string score = game.GetScore();
            Assert.Equal("Player One Wins", score);
        }

        [Fact]
        public void PlayerTwoScoresFourTimes_ShouldBe_PlayerTwo_Wins() {
            TennisGame game = new TennisGame();
            game.PlayerTwoScores();
            game.PlayerTwoScores();
            game.PlayerTwoScores();
            game.PlayerTwoScores();
            string score = game.GetScore();
            Assert.Equal("Player Two Wins", score);
        }

        [Fact]
        public void PlayerOneScoresThreeTimesAndPlayerTwoScoresThreeTimes_ShouldBe_Deuce() {
            TennisGame game = new TennisGame();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerOneScores();
            game.PlayerTwoScores();
            game.PlayerTwoScores();
            game.PlayerTwoScores();
            string score = game.GetScore();
            Assert.Equal("Deuce", score);
        }
    }
}
