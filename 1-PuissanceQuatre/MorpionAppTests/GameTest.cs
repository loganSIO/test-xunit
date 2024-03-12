using System.Reflection;

namespace MorpionApp.Tests {
  public class MorpionGameTests {
    [Fact]
    public void Constructor_InitializesGameCorrectly() {
      var morpionGame = new MorpionGame();

      var board = GetBoardFromMorpionGame(morpionGame);

      Assert.NotNull(board);
      Assert.Equal(3, board.Rows);
      Assert.Equal(3, board.Columns);
    }

    private Board GetBoardFromMorpionGame(MorpionGame morpionGame) {
      var gameType = typeof (Game);
      var boardField = gameType.GetField("_board", BindingFlags.NonPublic | BindingFlags.Instance);
      return (Board) boardField.GetValue(morpionGame);
    }
  }
}