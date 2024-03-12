namespace MorpionApp {
  public abstract class Game {
    protected Board _board;
    protected Player _player1;
    protected Player _player2;
    protected int _consecutiveSymbols;
    protected bool _quitGame = false;
    protected bool _currentPlayerTurn = true;

    public Game(int rows, int columns) {
    _board = new Board(rows, columns);
    _player1 = new Player('X');
    _player2 = new Player('O');
    }

    public virtual void Start() {
      while (true) {
      _board = new Board(_board.Rows, _board.Columns);

      while (!_quitGame) {
        char currentPlayerSymbol = _currentPlayerTurn ? _player1.Symbol : _player2.Symbol;
        HandlePlayerTurnInput(currentPlayerSymbol, Board.EmptyCell);

        if (_board.CheckVictory(currentPlayerSymbol, _consecutiveSymbols)) {
          EndOfGame($"Le joueur {(_currentPlayerTurn ? 1 : 2)} a gagné !");
          break;
        }

        _currentPlayerTurn = !_currentPlayerTurn;

        if (_board.CheckTie()) {
          EndOfGame("Aucun vainqueur, la partie se termine sur une égalité.");
          break;
        }
      }

      if (!_quitGame) {
        Console.WriteLine("Appuyez sur [Echap] pour quitter, [Entrée] pour rejouer.");
        GetKey:
          switch (Console.ReadKey(true).Key) {
          case ConsoleKey.Enter:
            break;
          case ConsoleKey.Escape:
            _quitGame = true;
            Console.Clear();
            break;
          default:
            goto GetKey;
          }
        }
      }
    }

    protected abstract (int, int) HandlePlayerTurnInput(char playerSymbol, char EmptyCell);

    protected void EndOfGame(string msg) {
      Console.Clear();
      _board.Display();
      Console.WriteLine(msg);
    }

  }
}