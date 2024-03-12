namespace MorpionApp.Tests {

  public class PlayerTests
  {
      [Fact]
      public void PlayerConstructorSetsSymbolCorrectly()
      {
          char expectedSymbol = 'X';

          Player player = new Player(expectedSymbol);
          char actualSymbol = player.Symbol;

          Assert.Equal(expectedSymbol, actualSymbol);
      }
  }

}