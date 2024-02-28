using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
        GetKey:
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.X:
                    Morpion morpion = new Morpion();
                    morpion.BoucleJeu();
                    break;
                case ConsoleKey.P:
                    PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
                    puissanceQuatre.BoucleJeu();
                    break;
                default:
                    goto GetKey;
            }
            Console.WriteLine("Jouer à un autre jeu ? Taper [R] pour changer de jeu. Taper [Echap] pour quitter.");
        GetKey1:
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.R:
                    Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
                GetKey2:
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.X:
                            Morpion morpion = new Morpion();
                            morpion.BoucleJeu();
                            break;
                        case ConsoleKey.P:
                            PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
                            puissanceQuatre.BoucleJeu();
                            break;
                        default:
                            goto GetKey2;
                    }
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    goto GetKey1;
            }
        }        
    }
}
