namespace MorpionApp.Tests {
  public class BoardTests {

    [Fact]
    public void BoardInitializationTest() {
      int rows = 3;
      int columns = 3;

      var board = new Board(rows, columns);

      Assert.Equal(rows, board.Rows);
      Assert.Equal(columns, board.Columns);
      Assert.NotNull(board.Grid);
      Assert.Equal(rows, board.Grid.GetLength(0));
      Assert.Equal(columns, board.Grid.GetLength(1));

      for (int i = 0; i < rows; i++) {
        for (int j = 0; j < columns; j++) {
          Assert.Equal(Board.EmptyCell, board.Grid[i, j]);
        }
      }
    }

    [Fact]
    public void PlacePieceTest() {

    int rows = 3;
    int columns = 3;
    var board = new Board(rows, columns);
    char symbol = 'X';
    int row = 1;
    int column = 2;

    bool result = board.PlacePiece(row, column, symbol);

    Assert.True(result);
    Assert.Equal(symbol, board.Grid[row, column]);
    }

    [Fact]
    public void CheckRowWinTest() {

    var board = new Board(3, 3);
    char symbol = 'X';
    int consecutiveSymbols = 3;

    board.Grid[0, 0] = symbol;
    board.Grid[0, 1] = symbol;
    board.Grid[0, 2] = symbol;

    bool result = board.CheckRowWin(symbol, consecutiveSymbols);

    Assert.True(result);
    }

    [Fact]
    public void CheckColumnWinTest() {
    var board = new Board(3, 3);
    char symbol = 'X';
    int consecutiveSymbols = 3;

    board.Grid[0, 0] = symbol;
    board.Grid[1, 0] = symbol;
    board.Grid[2, 0] = symbol;

    bool result = board.CheckColumnWin(symbol, consecutiveSymbols);

    Assert.True(result);
    }

    [Fact]
    public void CheckDiagonalWinTest() {
    var board = new Board(3, 3);
    char symbol = 'X';
    int consecutiveSymbols = 3;

    board.Grid[0, 0] = symbol;
    board.Grid[1, 1] = symbol;
    board.Grid[2, 2] = symbol;

    bool result = board.CheckDiagonalWin(symbol, consecutiveSymbols);

    Assert.True(result);
    }

    [Fact]
    public void CheckTieTest() {
    var board = new Board(3, 3);
    char symbolX = 'X';
    char symbolO = 'O';

    board.Grid[0, 0] = symbolX;
    board.Grid[0, 1] = symbolO;
    board.Grid[0, 2] = symbolX;
    board.Grid[1, 0] = symbolO;
    board.Grid[1, 1] = symbolX;
    board.Grid[1, 2] = symbolO;
    board.Grid[2, 0] = symbolO;
    board.Grid[2, 1] = symbolX;
    board.Grid[2, 2] = symbolO;

    bool result = board.CheckTie();

    Assert.True(result);
    }
  }
}