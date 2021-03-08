using System;
using System.Collections.Generic;       // Pour la classe Liste

namespace Listes
{
    class Program
    {
        static void Main(string[] args)
        {
            TestListeEntiers();

            Pause();
        }
        static void TestListeEntiers()
        {
            // Initialisation d'une liste d'entier
            List<int> liste = new List<int>();

            Random generateur = new Random();

            for (int i = 0; i < 10; i++)
            {
                // .Add fait la meme chose que .push_back
                // 10 chiffres random a mettre dans ma liste , ses chiffres seront entre 0 et 100.

                liste.Add(generateur.Next(100));
            }

            // Count indique le nombre d'elements dans la liste.
            Console.WriteLine("Taille de la liste : " + liste.Count);
            Console.WriteLine("Voici les chiffres obtenues : ");

            foreach (var chiffre in liste)
            {
                Console.WriteLine(chiffre);
            }
        }
        static void Pause()
        {
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true);
        }
    }
}
