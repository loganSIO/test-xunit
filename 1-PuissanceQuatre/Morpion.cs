using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Morpion
    {
        private const int BoardSizeRows = 3;
        private const int BoardSizeColumns = 3;
        private const char EmptyCell = ' ';
        private const char Player1Symbol = 'X';
        private const char Player2Symbol = 'O';
        private bool _quitGame = false;
        private bool _playerTurn = true;
        private char[,] _grid;

        public bool QuiterJeu { get { return _quitGame; } }
        public bool TourDuJoueur { get { return _playerTurn; } }
        public char[,] Grille { get { return _grid; } }

        public Morpion()
        {
            _grid = new char[BoardSizeColumns, BoardSizeRows];
        }

        private void InitializeGameBoard()
        {
            for (int row = 0; row < BoardSizeRows; row++)
            {
                for (int col = 0; col < BoardSizeColumns; col++)
                {
                    _grid[row, col] = EmptyCell;
                }
            }
        }

        public void Game()
        {
            _grid = new char[BoardSizeColumns, BoardSizeRows];

            while (true)
            {
                InitializeGameBoard();

                while (!_quitGame)
                {
                    if (_playerTurn)
                    {
                        playerTurn();
                        if (checkVictory(Player1Symbol))
                        {
                            endOfGame("Le joueur 1 à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        playerTurn2();
                        if (checkVictory(Player2Symbol))
                        {
                            endOfGame("Le joueur 2 à gagné !");
                            break;
                        }
                    }
                    _playerTurn = !_playerTurn;
                    if (checkTie())
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


        private (int row, int column) HandlePlayerTurn(char playerSymbol)
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!_quitGame && !moved)
            {
                Console.Clear();
                affichePlateau();
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
                        if (_grid[row, column] == EmptyCell)
                        {
                            _grid[row, column] = playerSymbol;
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

        public void playerTurn()
        {
            HandlePlayerTurn(Player1Symbol);
        }

        public void playerTurn2()
        {
            HandlePlayerTurn(Player2Symbol);
        }


        public void affichePlateau()
        {
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

        private bool CheckRowWin(char playerSymbol)
        {
            for (int row = 0; row < BoardSizeRows; row++)
            {
                if (_grid[row, 0] == playerSymbol && _grid[row, 1] == playerSymbol && _grid[row, 2] == playerSymbol)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckColumnWin(char playerSymbol)
        {
            for (int col = 0; col < BoardSizeColumns; col++)
            {
                if (_grid[0, col] == playerSymbol && _grid[1, col] == playerSymbol && _grid[2, col] == playerSymbol)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckDiagonalWin(char playerSymbol)
        {
            return (_grid[0, 0] == playerSymbol && _grid[1, 1] == playerSymbol && _grid[2, 2] == playerSymbol) ||
                (_grid[0, 2] == playerSymbol && _grid[1, 1] == playerSymbol && _grid[2, 0] == playerSymbol);
        }

        public bool checkVictory(char playerSymbol)
        {
            return CheckRowWin(playerSymbol) || CheckColumnWin(playerSymbol) || CheckDiagonalWin(playerSymbol);
        }

        public bool checkTie() =>
            _grid[0, 0] != EmptyCell && _grid[1, 0] != EmptyCell && _grid[2, 0] != EmptyCell &&
            _grid[0, 1] != EmptyCell && _grid[1, 1] != EmptyCell && _grid[2, 1] != EmptyCell &&
            _grid[0, 2] != EmptyCell && _grid[1, 2] != EmptyCell && _grid[2, 2] != EmptyCell;


        public void endOfGame(string msg)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine(msg);
        }
    }
}
