using System;

namespace Listes
{
   /// <summary>
   /// Représente un déplacement dans la console
   /// </summary>
   class Deplacement
   {
      /// <summary>
      /// Constructeur
      /// </summary>
      /// <param name="grille">La grille représentant l'état de la console</param>
      /// <param name="deltaX">Le déplacement horizontal</param>
      /// <param name="deltaY">Le déplacement vertical</param>
      public Deplacement(Grille grille, int deltaX, int deltaY)
      {
         _grille = grille;
         _deltaX = deltaX;
         _deltaY = deltaY;
      }

      /// <summary>
      /// Indique si le déplacement est valide
      /// </summary>
      public bool EstValide()
      {
         int x = Console.CursorLeft + _deltaX;
         int y = Console.CursorTop + _deltaY;
         // Doit être dans les limites de la fenêtre, et la case doit être libre
         if (x >= 0 && x < Console.WindowWidth - 1 && y >= 0 && y <= Console.WindowHeight - 1 && _grille.EstLibre(x, y))
         {
            return true;
         }
         return false;
      }

      /// <summary>
      /// Effectue le déplacement
      /// </summary>
      public void Effectuer()
      {
         Console.Write(".");
         --Console.CursorLeft;

         Console.CursorLeft += _deltaX;
         Console.CursorTop += _deltaY;

         Console.Write("x");
         --Console.CursorLeft;

         _grille.Occuper(Console.CursorLeft, Console.CursorTop);
      }

      /// <summary>
      /// Annule le déplacement
      /// </summary>
      public void Annuler()
      {
         _grille.Liberer(Console.CursorLeft, Console.CursorTop);

         Console.Write(" ");
         --Console.CursorLeft;

         Console.CursorLeft -= _deltaX;
         Console.CursorTop -= _deltaY;

         Console.Write("x");
         --Console.CursorLeft;
      }

      /// <summary>
      /// Lit un déplacement, donné avec les flèches du clavier
      /// </summary>
      /// <param name="deltaX">Le déplacement horizontal</param>
      /// <param name="deltaY">Le déplacement vertical</param>
      /// <param name="annuler">Indique si le dernier déplacement doit être annuler</param>
      /// <returns>Vrai si un déplacement a été lu, faux sinon</returns>
      public static bool Lire(out int deltaX, out int deltaY, out bool annuler)
      {
         deltaX = 0;
         deltaY = 0;
         annuler = false;

         ConsoleKeyInfo keyInfo = Console.ReadKey(true);
         switch (keyInfo.Key)
         {
            case ConsoleKey.LeftArrow:
               deltaX = -1;
               break;
            case ConsoleKey.UpArrow:
               deltaY = -1;
               break;
            case ConsoleKey.RightArrow:
               deltaX = 1;
               break;
            case ConsoleKey.DownArrow:
               deltaY = 1;
               break;
            case ConsoleKey.Z:
               if (keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control))
               {
                  // CTRL + Z
                  annuler = true;
               }
               else
               {
                  return false;
               }
               break;
            default:
               return false;
         }

         return true;
      }

      private Grille _grille;
      private readonly int _deltaX;
      private readonly int _deltaY;
   }
}
