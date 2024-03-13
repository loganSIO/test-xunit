namespace TennisApp {
  public class TennisGame {
    private int playerOneScore = 0;
    private int playerTwoScore = 0;

    public string GetScore() {
      if (IsTied()) {
        if (playerOneScore < 3) {
          return TranslateScore(playerOneScore) + "-All";
        }
        return "Deuce";
      }

      if (IsAdvantage()) {
        return "Advantage " + GetLeadingPlayerName();
      }

      if (IsGamePoint()) {
        return "Player " + GetLeadingPlayerName() + " Wins";
      }

      return TranslateScore(playerOneScore) + "-" + TranslateScore(playerTwoScore);
    }

    private bool IsTied() {
      return playerOneScore == playerTwoScore;
    }

    private bool IsAdvantage() {
      return playerOneScore >= 3 && playerTwoScore >= 3 && Math.Abs(playerOneScore - playerTwoScore) == 1;
    }

    private bool IsGamePoint() {
      return playerOneScore >= 4 || playerTwoScore >= 4 && Math.Abs(playerOneScore - playerTwoScore) >= 2;
    }

    private string GetLeadingPlayerName() {
      return playerOneScore > playerTwoScore ? "One" : "Two";
    }

    private string TranslateScore(int score) {
      switch (score) {
      case 0:
        return "0";
      case 1:
        return "15";
      case 2:
        return "30";
      case 3:
        return "40";
      default:
        return "Score not implemented";
      }
    }

    public void PlayerOneScores() {
      playerOneScore++;
    }

    public void PlayerTwoScores() {
      playerTwoScore++;
    }
  }
}