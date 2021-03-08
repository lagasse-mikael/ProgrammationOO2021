
// Un espace de noms (namespace) délimite une zone dans laquelle les identifiants doivent être uniques
namespace Astronomie
{
   class Jupiter
   {
      public static string Description()
      {
         return "Plus grosse planète du système solaire";
      }
   }

   class Mercure
   {
      // Deux classes différentes peuvent utiliser les mêmes noms
      public static string Description()
      {
         return "Planète la plus proche de soleil";
      }
   }

   // Interdit, le namespace contient déjà une classe "Jupiter"
   //class Jupiter { }
}


// Différents namespaces peuvent utiliser les mêmes noms
namespace Mythologie
{
   class Jupiter
   {
      public static string Description()
      {
         return "Dieu du ciel et maître des autres dieux";
      }
   }

   class Mercure
   {
      public static string Description()
      {
         return "Dieu du commerce";
      }
   }

   class Neptune
   {
      public static string Description()
      {
         return "Dieu des eaux vives et des sources";
      }
   }
}

// La définition d'un namespace peut être divisée à plusieurs endroits
// et même dans plusieurs fichiers
namespace Astronomie  // Suite du namespace Astronomie débuté ci-dessus
{
   class Neptune
   {
      public static string Description()
      {
         return "Planète la plus éloignée du soleil";
      }
   }

   // Interdit, le namespace contient déjà une classe "Jupiter"
   //class Jupiter { }
}


namespace Chimie
{
   // Troisième classe nommée "Mercure"
   // OK car dans 3 namespaces différents
   class Mercure
   {
      public static string Description()
      {
         return "Élément chimique de numéro atomique 80 et de symbole Hg";
      }
   }
}


namespace Quebec
{
   // Un namespace peut être inclus dans un autre
   // On utilise le point "." pour les séparer: Quebec.Histoire
   namespace Histoire
   {
      class JacquesCartier
      {
         public static string Description()
         {
            return "Premier Français à explorer le Canada";
         }
      }

      class SamuelDeChamplain
      {
         public static string Description()
         {
            return "Fondateur de la ville de Québec";
         }
      }
   }

   // Quebec.Pont
   namespace Pont
   {
      class JacquesCartier
      {
         public static string Description()
         {
            return "Pont entre Montréal et Longueuil";
         }
      }

      class SamuelDeChamplain
      {
         public static string Description()
         {
            return "Pont entre Montréal et Brossard";
         }
      }
   }
}
