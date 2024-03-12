namespace MorpionApp {
  public class Board {
    private
    const int BoardSizeRows = 3;
    private
    const int BoardSizeColumns = 3;
    public
    const char EmptyCell = ' ';

    private char[, ] _grid;

    public Board() {
      _grid = new char[BoardSizeColumns, BoardSizeRows];
      InitializeBoard();
    }

    private void InitializeBoard() {
      for (int row = 0; row < BoardSizeRows; row++) {
        for (int col = 0; col < BoardSizeColumns; col++) {
          _grid[row, col] = EmptyCell;
        }
      }
    }

    public char[, ] Grid => _grid;

    public void PlacePiece(int row, int column, char playerSymbol) {
      _grid[row, column] = playerSymbol;
    }

    private bool CheckRowWin(char playerSymbol) {
      for (int row = 0; row < BoardSizeRows; row++) {
        if (_grid[row, 0] == playerSymbol && _grid[row, 1] == playerSymbol && _grid[row, 2] == playerSymbol) {
          return true;
        }
      }
      return false;
    }

    private bool CheckColumnWin(char playerSymbol) {
      for (int col = 0; col < BoardSizeColumns; col++) {
        if (_grid[0, col] == playerSymbol && _grid[1, col] == playerSymbol && _grid[2, col] == playerSymbol) {
          return true;
        }
      }
      return false;
    }

    private bool CheckDiagonalWin(char playerSymbol) {
      return (_grid[0, 0] == playerSymbol && _grid[1, 1] == playerSymbol && _grid[2, 2] == playerSymbol) ||
        (_grid[0, 2] == playerSymbol && _grid[1, 1] == playerSymbol && _grid[2, 0] == playerSymbol);
    }

    public bool checkVictory(char playerSymbol) {
      return CheckRowWin(playerSymbol) || CheckColumnWin(playerSymbol) || CheckDiagonalWin(playerSymbol);
    }

    public bool checkTie() =>
      _grid[0, 0] != EmptyCell && _grid[1, 0] != EmptyCell && _grid[2, 0] != EmptyCell &&
      _grid[0, 1] != EmptyCell && _grid[1, 1] != EmptyCell && _grid[2, 1] != EmptyCell &&
      _grid[0, 2] != EmptyCell && _grid[1, 2] != EmptyCell && _grid[2, 2] != EmptyCell;

    public void Display() {
      Console.WriteLine();
      Console.WriteLine($" {_grid[0, 0]}  |  {_grid[0, 1]}  |  {_grid[0, 2]}");
      Console.WriteLine("    |     |");
      Console.WriteLine("----+-----+----");
      Console.WriteLine("    |     |");
      Console.WriteLine($" {_grid[1, 0]}  |  {_grid[1, 1]}  |  {_grid[1, 2]}");
      Console.WriteLine("    |     |");
      Console.WriteLine("----+-----+----");
      Console.WriteLine("    |     |");
      Console.WriteLine($" {_grid[2, 0]}  |  {_grid[1, 1]}  |  {_grid[2, 2]}");
    }
  }
}