namespace MorpionApp {
  public class Board {
    public int Rows { get { return _rows; } }
    public int Columns { get { return _columns; } }
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

    public bool CheckRowWin(char symbol, int consecutiveSymbols) {
      for (int row = 0; row < _rows; row++) {
        for (int col = 0; col <= _columns - consecutiveSymbols; col++) {
          bool win = true;
          for (int i = 0; i < consecutiveSymbols; i++) {
            if (_grid[row, col + i] != symbol) {
              win = false;
              break;
            }
          }

          if (win) {
            return true;
          }
        }
      }
      return false;
    }

    public bool CheckColumnWin(char symbol, int consecutiveSymbols) {
      for (int col = 0; col < _columns; col++) {
        for (int row = 0; row <= _rows - consecutiveSymbols; row++) {
        bool win = true;
        for (int i = 0; i < consecutiveSymbols; i++) {
          if (_grid[row + i, col] != symbol) {
            win = false;
            break;
          }
        }

        if (win) {
          return true;
        }
      }
    }
      return false;
    }

    public bool CheckDiagonalWin(char symbol, int consecutiveSymbols) {
      for (int row = 0; row <= _rows - consecutiveSymbols; row++) {
        for (int col = 0; col <= _columns - consecutiveSymbols; col++) {
          bool win = true;
          for (int i = 0; i < consecutiveSymbols; i++) {
            if (_grid[row + i, col + i] != symbol) {
              win = false;
              break;
            }
          }
          if (win) {
            return true;
          }
        }
      }

      for (int row = 0; row <= _rows - consecutiveSymbols; row++) {
        for (int col = _columns - 1; col >= consecutiveSymbols - 1; col--) {
          bool win = true;
          for (int i = 0; i < consecutiveSymbols; i++) {
            if (_grid[row + i, col - i] != symbol) {
              win = false;
              break;
            }
          }
          if (win) {
            return true;
          }
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

    public bool CheckVictory(char symbol, int consecutiveSymbols)
    {
        return CheckRowWin(symbol, consecutiveSymbols) || CheckColumnWin(symbol, consecutiveSymbols) || CheckDiagonalWin(symbol, consecutiveSymbols);
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