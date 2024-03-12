namespace MorpionApp {
  public class Game
  {
      private Board _board;
      private Player _player1;
      private Player _player2;
      private bool _quitGame = false;
      private bool _currentPlayerTurn = true;

      public Game()
      {
          _board = new Board();
          _player1 = new Player('X');
          _player2 = new Player('O');
      }

      public void Start()
      {
          while (true)
          {
              _board = new Board();

              while (!_quitGame)
              {
                  char currentPlayerSymbol = _currentPlayerTurn ? _player1.Symbol : _player2.Symbol;
                  HandlePlayerTurn(currentPlayerSymbol, Board.EmptyCell);

                  if (_board.checkVictory(currentPlayerSymbol))
                  {
                      endOfGame($"Le joueur {(_currentPlayerTurn ? 1 : 2)} à gagné !");
                      break;
                  }

                  _currentPlayerTurn = !_currentPlayerTurn;

                  if (_board.checkTie())
                  {
                      endOfGame("Aucun vainqueur, la partie se termine sur une égalité.");
                      break;
                  }
              }

              if (!_quitGame)
              {
                  Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                  GetKey:
                      switch (Console.ReadKey(true).Key)
                      {
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

      public void endOfGame(string msg)
      {
          Console.Clear();
          _board.Display();
          Console.WriteLine(msg);
      }


      private (int row, int column) HandlePlayerTurn(char playerSymbol, char EmptyCell)
      {
          var (row, column) = (0, 0);
          bool moved = false;

          while (!_quitGame && !moved)
          {
              Console.Clear();
              _board.Display();
              Console.WriteLine();
              Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
              Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

              var key = Console.ReadKey(true).Key;

              switch (key)
              {
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
                      if (_board.Grid[row, column] == EmptyCell)
                      {
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