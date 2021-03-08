using System;

namespace Exceptions
{
   /// <summary>
   /// Spécialiation d'une évaluation pour les examens
   /// </summary>
   class Examen
   {
      /// <summary>
      /// Constructeur
      /// </summary>
      /// <param name="nom">Nom de l'évalution</param>
      /// <param name="ponderation">Pondération, sous forme d'une chaine de caractères</param>
      /// <param name="date">Date, sous forme d'une chaine de caractères</param>
      /// <param name="duree">La durée, sous forme d'une chaine de caractères</param>
      public Examen(string nom, string ponderation, string date, string duree)
      {
         string[] valeurs = duree.Split(':');
         _heures = ValiderValeur(valeurs[0], 0, 3, "Heures");
         _minutes = ValiderValeur(valeurs[1], 0, 59, "Minutes");

         // Doit être fait une fois toutes les validations terminées pour ne pas compter
         // une évaluation invalide
         AjouterPonderation(_ponderation);
      }

      /// <summary>
      /// Affiche l'information de l'examen
      /// </summary>
      public void Afficher()
      {
         AfficherEvaluation();
         Console.WriteLine(", durée: {0:D2}:{1:D2}", _heures, _minutes);
      }

      // TODO: Les heures et les minutes ne doivent pas être modifiables après l'initialisation
      private int _heures;
      private int _minutes;
   }
}
