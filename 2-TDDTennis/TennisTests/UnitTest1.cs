namespace TennisApp {
    public class TennisGameTests
    {
        [Fact]
        public void Player_One_Scores_First_Point_Should_Be_15_0()
        {
            TennisGame game = new TennisGame();

            game.PlayerOneScores();
            string score = game.GetScore();

            Assert.Equal("15-0", score);
        }

    }
}