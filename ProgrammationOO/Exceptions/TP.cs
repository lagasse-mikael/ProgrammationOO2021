using System;

namespace Exceptions
{
   /// <summary>
   /// Spécialiation d'une évaluation pour les travaux pratiques
   /// </summary>
   class TP
   {
      /// <summary>
      /// Constructeur
      /// </summary>
      /// <param name="nom">Nom de l'évalution</param>
      /// <param name="ponderation">Pondération, sous forme d'une chaine de caractères</param>
      /// <param name="date">Date, sous forme d'une chaine de caractères</param>
      /// <param name="remise">La date de remise, sous forme d'une chaine de caractères</param>
      public TP(string nom, string ponderation, string date, string remise)
      {
         _remise = Convert.ToDateTime(remise);

         // Doit être fait une fois toutes les validations terminées pour ne pas compter
         // une évaluation invalide
         AjouterPonderation(_ponderation);
      }

      /// <summary>
      /// Affiche l'information du TP
      /// </summary>
      public void Afficher()
      {
         AfficherEvaluation();
         Console.WriteLine(", remise: {0}", _remise.ToLongDateString());
      }

      // DateTime représente une date
      // TODO: Ne doit pas être modifiable après l'initialisation
      private DateTime _remise;
   }
}
