using System;

namespace Listes
{
   /// <summary>
   /// Grille en 2 dimensions pour conserver les déplacements dans la console
   /// Aucune validation de paramètre n'est faite
   /// </summary>
   class Grille
   {
      /// <summary>
      /// Constructeur
      /// </summary>
      public Grille()
      {
         Console.CursorVisible = false;
         Console.Write("x");
         --Console.CursorLeft;
         _etat[0, 0] = true;
      }

      /// <summary>
      /// Indique si la case aux coordonnées données est libre
      /// </summary>
      public bool EstLibre(int x, int y)
      {
         return _etat[x, y] == false;
      }

      /// <summary>
      /// Marque la case aux coordonnées données comme étant occupée
      /// </summary>
      public void Occuper(int x, int y)
      {
         _etat[x, y] = true;
      }

      /// <summary>
      /// Marque la case aux coordonnées données comme étant libre
      /// </summary>
      public void Liberer(int x, int y)
      {
         _etat[x, y] = false;
      }

      // Devrait être assez grand peu importe la taille de la fenêtre
      private bool[,] _etat = new bool[200, 500];
   }
}
