/*
 * Les fichiers Validateurs.cs, Evaluation.cs, Examen.cs et TP.cs contiennent
 * une implémentation partielle du programme que vous devez compléter.
 * 
 * Le but est de lire le fichier 'evaluations.txt' qui contient une liste d'évaluations
 * d'un cours. Pour chaque évaluation, le programme demande à l'utilisateur la note
 * obtenue par un étudiant. À la fin, il affiche la note finale de l'étudiant.
 * 
 * Le fichier fourni contient des commentaires décrivant le format de chaque ligne.
 * 
 * Si une ligne ne respectant pas le format attendu est lue par le programme,
 * un message d'erreur informe l'utilisateur en indiquant le numéro de la ligne, la ligne
 * est ignorée et le programme se poursuit.
 * 
 * Le programme demande le nom du fichier à lire et ouvre celui-ci. Il se termine si le 
 * fichier est introuvable. Il lit ensuite toutes les lignes, en ignorant les lignes vides
 * et les lignes de commentaires, qui correspondent aux évaluations.
 * Il existe 2 types d'évaluations: des examens et des tp (travaux pratiques).
 * Un objet du bon type est créé ('Examen' ou 'TP') selon le type de l'évaluation. Puis
 * les détails de l'évaluation sont affichés. Le programme demande alors à l'utilisateur
 * la note obtenue par l'étudiant, entre 0 et 100. Si la note n'est pas valide, le
 * programme affiche une erreur et la redemande tant qu'une note valide n'est pas donnée.
 * 
 * Lorsque la fin du fichier est atteinte, le programme valide que la somme des pondérations
 * de toutes les évaluations valides est de 100. Si oui, il affiche la note totale de l'étudiant et
 * se termine. Sinon, un message d'erreur est affiché.
 * 
 * Les classes:
 *  - Evaluation: classe de base de toutes les évaluations
 *  - Examen: spécialisation d'une évaluation pour les examens
 *  - TP: spécialisation d'une évaluation pour les travaux pratiques
 *  - Validateur: classe principale du programme
 *  
 *  Certaines des modifications requises sont identifiéees par le jeton TODO, mais pas toutes!!!
 *  
 * Le fichier Exceptions.exe correspond au résultat attendu que vous devez reproduire.
 */

using System;
using System.IO;

namespace Exceptions
{
   class Validateur
   {
      public void Executer()
      {
         Console.Write("Indiquez le nom du fichier contenant les évaluations: ");
         string nomFichier = Console.ReadLine();

         using (StreamReader fichier = new StreamReader(nomFichier))
         {
            double noteFinale = 0;
            int numeroLigne = 1;
            string ligne = fichier.ReadLine();

            // Traite chaque ligne du fichier
            while (ligne != null)
            {
               // Enlève les espaces surperflues
               ligne = ligne.Trim();
               // Une ligne qui commence par # est un commentaire
               if (ligne.Length == 0 || ligne.StartsWith("#"))
               {
                  // On ignore les lignes vides et les commentaires
                  ligne = fichier.ReadLine();
                  ++numeroLigne;
                  continue;
               }

               // Divise les éléments de la ligne pour extraire le type
               string[] valeurs = ligne.Split(';');
               char type = ValiderType(valeurs[0]);

               // 'E' = Examen
               if (type == 'E')
               {
                  Examen examen = new Examen(valeurs[1], valeurs[2], valeurs[3], valeurs[4]);
                  examen.Afficher();
                  noteFinale += examen.DemanderNote();
               }
               else // Il n'y a que 2 types valides, donc 'T'
               {
                  TP tp = new TP(valeurs[1], valeurs[2], valeurs[3], valeurs[4]);
                  tp.Afficher();
                  noteFinale += tp.DemanderNote();
               }

               // Lit la prochaine ligne du fichier
               ligne = fichier.ReadLine();
               ++numeroLigne;
            }

            Evaluation.ValiderPonderation();

            Console.WriteLine("\n\n------------------------------");
            Console.WriteLine("Note finale: " + noteFinale);
         }
      }

      /// <summary>
      /// Valide le type donné
      /// </summary>
      /// <param name="valeur">Le type, sous forme d'une chaine de caractères</param>
      /// <returns>Le caractère représentant le type</returns>
      /// <exception cref="ArgumentException">Si le type n'est pas valide</exception>
      private char ValiderType(string valeur)
      {
         switch (valeur)
         {
            case "T":
            case "E":
               return valeur[0];
         }
      }

      /// <summary>
      /// Effectue une pause du programme
      /// </summary>
      private void Pause()
      {
         Console.WriteLine("Appuyez sur une touche pour continuer...");
         Console.ReadKey(true);
      }
   }
}
