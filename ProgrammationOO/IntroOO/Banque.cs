using System;
using System.IO;

namespace IntroOO
{
   /// <summary>
   /// Une banque contient 5 comptes bancaires et permet d'effectuer des opérations sur les comptes
   /// </summary>
   class Banque
   {

        public Banque(string fichier)
        {
            using (StreamReader lecture = new StreamReader(fichier))
            {
                // Pas de traitement d'erreur , le fichier aura toujours 5 comptes valide.
                for (int i = 0; i < NbComptes; i++)
                {
                    string ligne = lecture.ReadLine();

                    // Cree un nouveau compte , avec l'information du fichier et on le place dans le tableau.
                    _comptes[i] = new CompteBancaire(ligne);
                }
            }
        }
        
        
        public void ListerComptes()
        {
            foreach (CompteBancaire compte in _comptes)
            {
                compte.Afficher();
            }
        }

        public void AfficherSolde(string nom)
        {
            // On fait une reference vers un autre compte bancaire.
            // En fait on en cherche un avec rechercherCompte();
            // ( Lien direct vers un compte qui existe deja )
            CompteBancaire compte = rechercherCompte(nom);
            if (compte != null)
                compte.AfficherSolde();
            else
                Console.WriteLine("Ce compte n'existe pas.");
        }

        public void Deposer(string nom,double montant)
        {
            CompteBancaire compte = rechercherCompte(nom);
            if (compte != null)
            {
                compte.Deposer(montant);
            }
            else
                Console.WriteLine("Ce compte n'existe pas.");
        }

        public void Retirer(string nom, double montant)
        {
            CompteBancaire compte = rechercherCompte(nom);
            if (compte != null)
            {
                compte.Retirer(montant);
            }
            else
                Console.WriteLine("Ce compte n'existe pas.");
        }

        public void Sauvegarder(string fichier)
        {
            using (StreamWriter ecriture = new StreamWriter(fichier))
            {
                foreach (CompteBancaire compte in _comptes)
                {
                    ecriture.WriteLine(compte.Enregistrer());
                }
            }
        }

        // Methode priver , car elle est uniquement utiliser dans la class.
        // Recherche le compte donner dans le tableau
        // Affiche une erreur si le compte est introuvable
        // Retourne le compte trouver ou null sinon.

        private CompteBancaire rechercherCompte(string nomCompte)
        {
            foreach (CompteBancaire compte in _comptes)
            {
                if (compte.estEgaleA(nomCompte))
                    return compte;
            }
            return null;
        }



        private const int NbComptes = 5;

      // Un tableau de 5 comptes bancaires.
      // Notez que le tableau est vide et que les comptes ne sont pas initialisés.
      // Dans le constructeur, il sera nécessaire de créer chaque objet contenu dans le tableau:
      //   _comptes[0] = new CompteBancaire(...);
      //   ...
      //   _comptes[4] = new CompteBancaire(...);

      private CompteBancaire[] _comptes = new CompteBancaire[NbComptes];        // Nous donnes 5 cases null
   }
}
