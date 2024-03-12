namespace MorpionApp {
  public class Board {
    private
    readonly int _rows;
    private
    readonly int _columns;
    public
    const char EmptyCell = ' ';

    private char[, ] _grid;

    public Board(int rows, int columns) {
      _rows = rows;
      _columns = columns;
      _grid = new char[_rows, _columns];
      InitializeBoard();
    }

    private void InitializeBoard() {
      for (int row = 0; row < _rows; row++) {
        for (int col = 0; col < _columns; col++) {
          _grid[row, col] = EmptyCell;
        }
      }
    }

    public char[, ] Grid => _grid;

    public bool PlacePiece(int row, int column, char symbol) {
      if (row < 0 || row >= _rows || column < 0 || column >= _columns) {
        return false;
      }

      if (_grid[row, column] != EmptyCell) {
        return false;
      }

      _grid[row, column] = symbol;
      return true;
    }

    public bool CheckRowWin(char symbol) {
      for (int row = 0; row < _rows; row++) {
        bool win = true;
        for (int col = 0; col < _columns; col++) {
          if (_grid[row, col] != symbol) {
            win = false;
            break;
          }
        }

        if (win) {
          return true;
        }
      }

      return false;
    }

    public bool CheckColumnWin(char symbol) {
      for (int col = 0; col < _columns; col++) {
        bool win = true;
        for (int row = 0; row < _rows; row++) {
          if (_grid[row, col] != symbol) {
            win = false;
            break;
          }
        }

        if (win) {
          return true;
        }
      }

      return false;
    }

    public bool CheckDiagonalWin(char symbol) {
      for (int i = 0; i < Math.Min(_rows, _columns); i++) {
        if (_grid[i, i] != symbol) {
          break;
        }

        if (i == Math.Min(_rows, _columns) - 1) {
          return true;
        }
      }

      for (int i = 0; i < Math.Min(_rows, _columns); i++) {
        if (_grid[i, _columns - 1 - i] != symbol) {
          break;
        }

        if (i == Math.Min(_rows, _columns) - 1) {
          return true;
        }
      }

      return false;
    }

    public bool CheckTie() {
      for (int row = 0; row < _rows; row++) {
        for (int col = 0; col < _columns; col++) {
          if (_grid[row, col] == EmptyCell) {
            return false;
          }
        }
      }
      return true;
    }

    public bool CheckVictory(char symbol)
    {
        return CheckRowWin(symbol) || CheckColumnWin(symbol) || CheckDiagonalWin(symbol);
    }

    public void Display() {
      Console.WriteLine();
      for (int row = 0; row < _rows; row++) {
        for (int col = 0; col < _columns; col++) {
          Console.Write($" {_grid[row, col]} ");
          if (col < _columns - 1) {
            Console.Write("|");
          }
        }
        Console.WriteLine();
        if (row < _rows - 1) {
          for (int col = 0; col < _columns; col++) {
            Console.Write("---");
            if (col < _columns - 1) {
              Console.Write("+");
            }
          }
          Console.WriteLine();
        }
      }
    }
  }
}