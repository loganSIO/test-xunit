using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Morpion
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public char[,] grille;

        public Morpion()
        {
            grille = new char[3, 3];
        }

        public void BoucleJeu()
        {
            while (!quiterJeu)
            {
                grille = new char[3, 3]
                {
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
                };
                while (!quiterJeu)
                {
                    if (tourDuJoueur)
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
                    tourDuJoueur = !tourDuJoueur;
                    if (verifEgalite())
                    {
                        finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                }
                if (!quiterJeu)
                {
                    Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                    GetKey:
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.Enter:
                                break;
                            case ConsoleKey.Escape:
                                quiterJeu = true;
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

            while (!quiterJeu && !moved)
            {
                Console.Clear();
                affichePlateau();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
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
                        if (grille[row, column] == ' ')
                        {
                            grille[row, column] = playerSymbol;
                            moved = true;
                            quiterJeu = false;
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
            Console.WriteLine($" {grille[0, 0]}  |  {grille[0, 1]}  |  {grille[0, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grille[1, 0]}  |  {grille[1, 1]}  |  {grille[1, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grille[2, 0]}  |  {grille[1, 1]}  |  {grille[0, 2]}");
        }

        public bool verifVictoire(char c) =>
             grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c ||
             grille[0, 1] == c && grille[1, 1] == c && grille[2, 1] == c ||
             grille[0, 2] == c && grille[1, 2] == c && grille[2, 2] == c ||
             grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c ||
             grille[1, 0] == c && grille[1, 1] == c && grille[1, 2] == c ||
             grille[2, 0] == c && grille[2, 1] == c && grille[2, 2] == c ||
             grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c ||
             grille[2, 0] == c && grille[1, 1] == c && grille[0, 2] == c;

        public bool verifEgalite() =>
            grille[0, 0] != ' ' && grille[1, 0] != ' ' && grille[2, 0] != ' ' &&
            grille[0, 1] != ' ' && grille[1, 1] != ' ' && grille[2, 1] != ' ' &&
            grille[0, 2] != ' ' && grille[1, 2] != ' ' && grille[2, 2] != ' ';


        public void finPartie(string msg)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine(msg);
        }
    }
}
