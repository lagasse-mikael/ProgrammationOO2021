using System;

namespace Listes
{
   /// <summary>
   /// Représente un étudiant
   /// </summary>
   class Etudiant
   {
      /// <summary>
      /// Constructeur, demande le matricule et la note de l'étudiant
      /// </summary>
      public Etudiant()
      {
         Console.Write("Matricule: ");
         _matricule = Convert.ToInt32(Console.ReadLine());
         Console.Write("Note: ");
         _note = Convert.ToInt32(Console.ReadLine());
      }

      /// <summary>
      /// Caractéristiques de l'étudiant
      /// </summary>
      public int Matricule
      {
         get { return _matricule; }
      }

      public int Note
      {
         get { return _note; }
      }

      /// <summary>
      /// Affiche l'information de l'étudiant
      /// </summary>
      public void Afficher()
      {
         Console.WriteLine("{0,5}: {1}%", _matricule, _note);
      }


      private readonly int _matricule;
      private int _note;
   }
}
