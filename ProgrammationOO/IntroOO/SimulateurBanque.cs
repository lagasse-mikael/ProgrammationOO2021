using System;

//
// IMPORTANT:
//  - Ne pas modifier ce fichier
//
//  - Les classes Banque et CompteBancaires ne doivent contenir
//    aucune propriété, aucun accesseur et aucun mutateur
//

namespace IntroOO
{
   class SimulateurBanque
   {
      /// <summary>
      /// Exécute un petit programme qui simule des opérations bancaires
      /// </summary>
      public void Simuler()
      {
         // La banque est initialisée avec le nom du fichier contenant l'information des comptes
         Banque banque = new Banque("banque.txt");

         string nom;
         double montant;

         // On boucle tant que l'utilisateur n'indique pas la fin du programme
         while (true)
         {
            string operation = AfficherMenu();

            switch (operation)
            {
               case "L":
			      // Affiche l'information de tous les comptes
                  banque.ListerComptes();
                  break;

               case "S":
                  nom = DemanderNom();
                  // Demande à la banque d'afficher le solde du compte portant le nom donné.
                  // Affichera un message d'erreur si le compte est introuvable.
                  banque.AfficherSolde(nom);
                  break;

               case "D":
                  nom = DemanderNom();
                  montant = DemanderMontant();
                  // Demande à la banque d'effectuer un dépôt du montant donné dans le compte donné.
                  // Affichera un message d'erreur si le compte est introuvable.
                  banque.Deposer(nom, montant);
                  break;

               case "R":
                  nom = DemanderNom();
                  montant = DemanderMontant();
                  // Demande à la banque d'effectuer un retrait du montant donné du compte donné.
                  // Affichera un message d'erreur si le compte est introuvable.
                  // Affichera un message d'erreur si le solde est insuffisant.
                  banque.Retirer(nom, montant);
                  break;

               case "Q":
                  Console.WriteLine("Fermeture de la banque");
                  // Avant de quitter, on demande à la banque de sauvegarder l'infomation des comptes dans le fichier
                  banque.Sauvegarder("banque.txt");
                  return;

               default:
                  Console.WriteLine("Opération invalide");
                  break;
            }

            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true);
         }
      }


      // Affiche la liste des opérations possibles et demande le choix de l'utilisateur.
      // Le choix de l'utilisateur, en majuscules, sans espaces surperflues
      private string AfficherMenu()
      {
         Console.Clear();
         Console.WriteLine("Opérations");
         Console.WriteLine("----------");
         Console.WriteLine("L: Lister les comptes");
         Console.WriteLine("S: Afficher le solde");
         Console.WriteLine("D: Effectuer un dépôt");
         Console.WriteLine("R: Effectuer un retrait");
         Console.WriteLine("Q: Quitter\n");
         Console.Write("Choix: ");

         // On convertit le choix en majuscule pour limiter les comparaisons
         // et on supprimer les espaces superflues
         return Console.ReadLine().ToUpper().Trim();
      }

      // Demande le nom d'un comte bancaire à l'utilisateur et retourne la valeur donnée.
      private string DemanderNom()
      {
         Console.Write("Indiquez le nom du compte: ");
         return Console.ReadLine();
      }

      // Demande un montant à l'utilisateur et retourne la valeur donnée.
      // Ne fait pas de validation!!!
      // Le programme va planter si l'utilisateur n'entre pas un nombre!
      private double DemanderMontant()
      {
         Console.Write("Indiquez le montant: ");
         string texte = Console.ReadLine();
         return Convert.ToDouble(texte);
      }
   }
}
