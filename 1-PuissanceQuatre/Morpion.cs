using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Morpion
    {
        private bool _quiterJeu = false;
        private bool _tourDuJoueur = true;
        private char[,] _grille;

        public bool QuiterJeu { get { return _quiterJeu; } }
        public bool TourDuJoueur { get { return _tourDuJoueur; } }
        public char[,] Grille { get { return _grille; } }

        public Morpion()
        {
            _grille = new char[3, 3];
        }

        private void InitializeGameBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    _grille[row, col] = ' ';
                }
            }
        }

        public void BoucleJeu()
        {
            _grille = new char[3, 3];

            while (true)
            {
                InitializeGameBoard();

                while (!_quiterJeu)
                {
                    if (_tourDuJoueur)
                    {
                        tourJoueur();
                        if (verifVictoire('X'))
                        {
                            finPartie("Le joueur 1 à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        tourJoueur2();
                        if (verifVictoire('O'))
                        {
                            finPartie("Le joueur 2 à gagné !");
                            break;
                        }
                    }
                    _tourDuJoueur = !_tourDuJoueur;
                    if (verifEgalite())
                    {
                        finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                }
                if (!_quiterJeu)
                {
                    Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                    GetKey:
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.Enter:
                                break;
                            case ConsoleKey.Escape:
                                _quiterJeu = true;
                                Console.Clear();
                                break;
                            default:
                                goto GetKey;
                        }
                }

            }
        }


        private bool HandlePlayerTurn(char playerSymbol)
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!_quiterJeu && !moved)
            {
                Console.Clear();
                affichePlateau();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        _quiterJeu = true;
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
                        if (_grille[row, column] == ' ')
                        {
                            _grille[row, column] = playerSymbol;
                            moved = true;
                            _quiterJeu = false;
                        }
                        break;
                }
            }

            return moved;
        }

        public void tourJoueur()
        {
            HandlePlayerTurn('X');
        }

        public void tourJoueur2()
        {
            HandlePlayerTurn('O');
        }


        public void affichePlateau()
        {
            Console.WriteLine();
            Console.WriteLine($" {_grille[0, 0]}  |  {_grille[0, 1]}  |  {_grille[0, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {_grille[1, 0]}  |  {_grille[1, 1]}  |  {_grille[1, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {_grille[2, 0]}  |  {_grille[1, 1]}  |  {_grille[0, 2]}");
        }

        private bool CheckRowWin(char playerSymbol)
        {
            for (int row = 0; row < 3; row++)
            {
                if (_grille[row, 0] == playerSymbol && _grille[row, 1] == playerSymbol && _grille[row, 2] == playerSymbol)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckColumnWin(char playerSymbol)
        {
            for (int col = 0; col < 3; col++)
            {
                if (_grille[0, col] == playerSymbol && _grille[1, col] == playerSymbol && _grille[2, col] == playerSymbol)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckDiagonalWin(char playerSymbol)
        {
            return (_grille[0, 0] == playerSymbol && _grille[1, 1] == playerSymbol && _grille[2, 2] == playerSymbol) ||
                (_grille[0, 2] == playerSymbol && _grille[1, 1] == playerSymbol && _grille[2, 0] == playerSymbol);
        }

        public bool verifVictoire(char playerSymbol)
        {
            return CheckRowWin(playerSymbol) || CheckColumnWin(playerSymbol) || CheckDiagonalWin(playerSymbol);
        }

        public bool verifEgalite() =>
            _grille[0, 0] != ' ' && _grille[1, 0] != ' ' && _grille[2, 0] != ' ' &&
            _grille[0, 1] != ' ' && _grille[1, 1] != ' ' && _grille[2, 1] != ' ' &&
            _grille[0, 2] != ' ' && _grille[1, 2] != ' ' && _grille[2, 2] != ' ';


        public void finPartie(string msg)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine(msg);
        }
    }
}
