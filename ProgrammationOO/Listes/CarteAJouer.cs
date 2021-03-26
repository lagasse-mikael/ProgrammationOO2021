using System.Text;

namespace Listes
{
   /// <summary>
   /// Les 4 suites d'un jeu de cartes standard
   /// </summary>
   enum Suite
   {
      Coeur,
      Carreau,
      Trefle,
      Pique
   }

   /// <summary>
   /// Représente une carte à jouer, définie par sa suite et sa valeur
   /// </summary>
   class CarteAJouer
   {
      /// <summary>
      /// Constructeur
      /// </summary>
      /// <param name="valeur">La valeur de la carte</param>
      /// <param name="suite">La suite de la carte</param>
      public CarteAJouer(int valeur, Suite suite)
      {
         _valeur = valeur;
         _suite = suite;
      }

      /// <summary>
      /// Représentation textuelle de la carte
      /// </summary>
      public string Description
      {
         get
         {
            StringBuilder sb = new StringBuilder();
            switch (_valeur)
            {
               case 1:
                  sb.Append("As");
                  break;
               case 11:
                  sb.Append("Valet");
                  break;
               case 12:
                  sb.Append("Reine");
                  break;
               case 13:
                  sb.Append("Roi");
                  break;
               default:
                  sb.Append(_valeur);
                  break;
            }

            sb.Append(" de " + _suite);
            return sb.ToString();
         }
      }

      private readonly int _valeur;
      private readonly Suite _suite;
   }
}
