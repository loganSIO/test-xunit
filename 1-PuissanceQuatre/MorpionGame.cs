namespace MorpionApp {
  public class MorpionGame : Game {

    public MorpionGame() : base(3, 3) {
    }

    protected override (int, int) HandlePlayerTurnInput(char playerSymbol, char EmptyCell) {
      var (row, column) = (0, 0);
      bool moved = false;

      while (!_quitGame && !moved) {
        Console.Clear();
        _board.Display();
        Console.WriteLine();
        Console.WriteLine("Choisir une case valide et appuyer sur [Entrée] pour placer votre symbole.");
        Console.SetCursorPosition(column * 4 + 2, row * 2 + 1);

        var key = Console.ReadKey(true).Key;

        switch (key) {
        case ConsoleKey.Escape:
          _quitGame = true;
          Console.Clear();
          break;

        case ConsoleKey.RightArrow:
          column = (column + 1) % 3;
          break;

        case ConsoleKey.LeftArrow:
          column = (column == 0) ? 2 : column - 1;
          break;

        case ConsoleKey.UpArrow:
          row = (row == 0) ? 2 : row - 1;
          break;

        case ConsoleKey.DownArrow:
          row = (row + 1) % 3;
          break;

        case ConsoleKey.Enter:
          if (_board.Grid[row, column] == EmptyCell) {
            _board.Grid[row, column] = playerSymbol;
            moved = true;
            _quitGame = false;
          }
          break;
        default:
          Console.WriteLine("Touche non valide");
          break;
        }
      }

      return (row, column);
    }
  }
}