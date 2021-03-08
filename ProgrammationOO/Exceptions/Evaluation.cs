using System;
using System.Text;

namespace Exceptions
{
   /// <summary>
   /// Classe de base de toutes les évaluations
   /// </summary>
   class Evaluation
   {
      /// <summary>
      /// Valide que la somme des pondérations de toutes les évaluations est 100
      /// </summary>
      /// <exception cref="ArgumentException">Si la somme des pondérations n'est pas valide</exception>
      public void ValiderPonderation()
      {
         if (_ponderationTotal != 100)
         {
            // TODO: Lancer une exception
         }
      }

      /// <summary>
      /// Constructeur
      /// </summary>
      /// <param name="nom">Nom de l'évalution</param>
      /// <param name="ponderation">Pondération, sous forme d'une chaine de caractères</param>
      /// <param name="date">Date, sous forme d'une chaine de caractères</param>
      public Evaluation(string nom, string ponderation, string date)
      {
         _nom = nom;
         _ponderation = ValiderValeur(ponderation, 0, 100, "Pondération");
         _date = Convert.ToDateTime(date);
      }

      /// <summary>
      /// Demande la note obtenue à l'évaluation
      /// </summary>
      /// <returns>Retourne la portion de la note finale, basée sur la pondération</returns>
      public double DemanderNote()
      {
         Console.Write("Note (entre 0 et 100): ");
         int note = ValiderValeur(Console.ReadLine(), 0, 100, "Note");
         double noteFinale = (note * _ponderation) / 100.00;
         return noteFinale;
      }

      /// <summary>
      /// Ajoute la pondération donnée à la pondération totale
      /// </summary>
      /// <param name="ponderation">La pondération à ajouter</param>
      /// <remarks>
      /// Dois être appellée dans le constructeur de la classe dérivée
      /// une fois toutes les validations terminées.
      /// </remarks>
      // TODO: Ne doit pouvoir être appelée que par une classe dérivée d'Evaluation
      private void AjouterPonderation(int ponderation)
      {
         _ponderationTotal += ponderation;
      }

      /// <summary>
      /// Affiche l'information de l'évaluation
      /// </summary>
      // TODO: Ne doit pouvoir être appelée que par une classe dérivée d'Evaluation
      private void AfficherEvaluation()
      {
         // ToLongDateString de DateTime va afficher la date comme "26 février 2021"
         Console.Write("{0} ({1}%) {2}", _nom, _ponderation, _date.ToLongDateString());
      }

      /// <summary>
      /// Convertit et valide la valeur donnée en entier
      /// </summary>
      /// <param name="valeur">La valeur, sous forme d'une chaine de caractères</param>
      /// <param name="min">La valeur minimale acceptable</param>
      /// <param name="max">La valeur maximale acceptable</param>
      /// <param name="description">La description de la valeur</param>
      /// <returns>La valeur convertit</returns>
      /// <exception cref="FormatException">Si la chaine de caractères ne représente pas une valeur entière</exception>
      /// <exception cref="ArgumentException">Si la valeur ne respecte pas les limites</exception>
      // TODO: Ne doit pouvoir être appelée que par une classe dérivée d'Evaluation
      private int ValiderValeur(string valeur, int min, int max, string description)
      {
         int resultat = Convert.ToInt32(valeur);
         if (resultat < min || resultat > max)
         {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} invalide, doit être un entier entre {1} et {2}",
               description, min, max);
            // TODO: Lancer une exception
         }
         return resultat;
      }

      // !!! Aucun attribut ne doit être public
      private int _ponderationTotal = 0;

      // TODO: Ne doivent pas être modifiables après l'initialisation
      private int _ponderation;
      private string _nom;
      private DateTime _date;
   }
}
