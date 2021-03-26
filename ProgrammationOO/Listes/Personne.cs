using System;

namespace Listes
{
   /// <summary>
   /// Représentation d'une personne
   /// </summary>
   class Personne
   {
      /// <summary>
      /// Constructeur
      /// </summary>
      /// <param name="prenom">Le prénom de la personne</param>
      /// <param name="nom">Le nom de la personne</param>
      /// <param name="age">L'âge de la personne</param>
      public Personne(string prenom, string nom, int age)
      {
         Prenom = prenom;
         Nom = nom;
         Age = age;
      }

      /// <summary>
      /// Caractéristiques d'une personne
      /// </summary>
      public string Prenom { get; set; }
      public string Nom { get; set; }
      public int Age { get; set; }

      /// <summary>
      /// Affiche l'information de la personne
      /// </summary>
      public void Afficher()
      {
         // 'this' représente l'objet courant
         // Soit les objets:
         //  Personne p1;
         //  Personne p2;
         // Lors de l'appel p1.Afficher(), 'this' correspond à 'p1'
         // Lors de l'appel p2.Afficher(), 'this' correspond à 'p2'
         Console.WriteLine("{0} {1}, {2} ans", this.Prenom, this.Nom, this.Age);
         // Identique à
         // Console.WriteLine("{0} {1}, {2} ans", Prenom, Nom, Age);
      }
   }
}
