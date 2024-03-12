namespace MorpionApp {
  public class ConnectFourGame : Game {
    private int _column = 0;

    public ConnectFourGame() : base(6, 7) {
      _consecutiveSymbols = 4;
    }

    protected override (int, int) HandlePlayerTurnInput(char playerSymbol, char EmptyCell) {
        bool moved = false;

        while (!_quitGame && !moved) {
            Console.Clear();
            _board.Display();
            Console.WriteLine();
            Console.WriteLine("Choisir une colonne valide et appuyer sur [Entrée] pour placer votre symbole.");
            Console.SetCursorPosition(_column * 4 + 2, 0);

            var key = Console.ReadKey(true).Key;

            switch (key) {
                case ConsoleKey.Escape:
                    _quitGame = true;
                    Console.Clear();
                    break;

                case ConsoleKey.RightArrow:
                    _column = (_column + 1) % 7;
                    break;

                case ConsoleKey.LeftArrow:
                    _column = (_column == 0) ? 6 : _column - 1;
                    break;

                case ConsoleKey.Enter:
                    int row = FindLowestEmptyRow(_column);
                    if (row != -1) {
                        _board.Grid[row, _column] = playerSymbol;
                        moved = true;
                        _quitGame = false;
                    } else {
                        Console.WriteLine("La colonne est pleine. Choisissez une autre colonne.");
                    }
                    break;

                default:
                    Console.WriteLine("Touche non valide");
                    break;
            }
        }

        return (-1, _column);
    }

    private int FindLowestEmptyRow(int column) {
    for (int row = _board.Rows - 1; row >= 0; row--) {
        if (_board.Grid[row, column] == Board.EmptyCell) {
            return row;
        }
    }
    return -1;
    }
  }
}