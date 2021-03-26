using System;
using System.Collections.Generic;
using System.Linq;

namespace Listes
{
    class Exercices
    {
        /// <summary>
        /// Déplace un caractère dans la console selon les touches appuyées par l'utilisateur
        /// </summary>
        public static void TestDeplacement()
        {
            Grille grille = new Grille();
            Stack<Deplacement> historique = new Stack<Deplacement>();

            // Tant que l'utilisteur indique un déplacement
            while (Deplacement.Lire(out int deltaX, out int deltaY, out bool annuler))
            {
                // Si CTRL + Z a été appuyé, on annule le dernier déplacement
                if (annuler)
                {
                    try
                    {
                        historique.Pop().Effectuer();
                    }
                    catch(Exception)
                    {
                        throw new Exception("Impossible de revenir en arriere!");
                    }
                }
                else // Une flèche
                {
                    // Crée un objet déplacement avec l'info lue, et s'il est valide, on l'effectue
                    Deplacement d = new Deplacement(grille, deltaX, deltaY);
                    if (d.EstValide())
                    {
                        historique.Push(d);
                        d.Effectuer();
                    }
                    // S'il n'est pas valide, on ne fait rien
                }
            }
        }


        /// <summary>
        /// Ajoute des étudiants à une liste, puis les affiche
        /// </summary>
        public static void TestEtudiants()
        {

            List<Etudiant> etudiants = new List<Etudiant>();

            try
            {
                while (true)
                {
                    // Crée un nouvel étudiant
                    Etudiant e = new Etudiant();

                    // Si un étudiant avec le même matricule n'existe pas déjà, on l'ajoute à la liste
                    // Sinon, on affiche un message d'erreur

                    // TODO
                    AjouterEtudiant(etudiants, e);
                }
            }
            catch (Exception)
            {
                // On termine la boucle lorsqu'un étudiant n'est pas construit correctement
            }

            // Affiche la liste des étudiants

            // TODO
            AfficherEtudiants(etudiants);

            // S'il y a au moins un étudiant, affiche l'étudiant avec la plus faible note
            Etudiant etudiantNoteMin = null;

            // TODO
            etudiantNoteMin = TrouverNoteMin(etudiants);

            if (etudiantNoteMin != null)
            {
                Console.WriteLine("Étudiant avec la plus faible note: " + etudiantNoteMin.Matricule);
            }
        }

        private static void AjouterEtudiant(List<Etudiant> etudiants,Etudiant e)
        {
            // On verifie tout les etudiants et si le matricule de 'e' n'est pas present , on l'ajoute apres la boucle.

            foreach (var etudiant in etudiants)
            {
                if (etudiant.Matricule == e.Matricule)
                {
                    Console.WriteLine("Ce matricule existe deja.");
                    return;
                }
            }

            etudiants.Add(e);
        }

        private static void AfficherEtudiants(List<Etudiant> etudiants)
        {
            foreach (var etudiant in etudiants)
            {
                etudiant.Afficher();
            }
        }

        private static Etudiant TrouverNoteMin(List<Etudiant> etudiants)
        {
            if (etudiants.Count != 0)
            {
                List<Etudiant> ListeCroissante = etudiants.OrderBy(o => o.Note).ToList();
                return ListeCroissante[0];
            }
            throw new Exception("Est vide yo.");
        }
    }
}
