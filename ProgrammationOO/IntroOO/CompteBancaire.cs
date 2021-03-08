using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntroOO
{
    enum TypeCompte
    {
        Epargne,        // 0
        Cheque          // 1
    }
    class CompteBancaire
    {
        public CompteBancaire(string ligneFichier)
        {
            // Prenons comme exemple : Cheque;Mikael;100
            string[] elements = ligneFichier.Split(';');

            switch(elements[0])
            {
                case "Epargne":
                    _type = 0;
                    break;
                case "Cheque":
                    _type = 1;
                    break;
            }
            _nom = elements[1];         // ReadOnly , doit etre initialiser dans le constructeur.
            _solde = Convert.ToDouble(elements[2]);     //100
        }

        public void Afficher()
        {
            //_nom = "test";      // Impossible de modifier un readonly apres la construction.
            
            Console.WriteLine("Compte {0} de {1} : {2} $",( _type == 0 ? "Epargne" : "Cheque"),_nom,_solde);
        }

        public bool estEgaleA(string nom)
        {
            return _nom == nom;
        }
        public void AfficherSolde()
        {
            // Format C c'est pour la currency selon l'ordinateur ( $ ).
            Console.WriteLine("{0} possede {1:C} dans son compte {2}", _nom, _solde, (_type == 0 ? "Epargne" : "Cheque"));
        }

        public void Deposer(double montant)
        {
            _solde += montant;
        }

        public void Retirer(double montant)
        {
            if (montant > _solde)
                Console.WriteLine("Impossible de retirer un tel montant! Avez vous assez?");
            else
                _solde -= montant;
        }

        public string Enregistrer()
        {
            StringBuilder ligne = new StringBuilder();
            ligne.AppendFormat("{0};{1};{2}", (_type == 0 ? "Epargne" : "Cheque"), _nom, _solde);
            return ligne.ToString();
        }

        private readonly int _type;
        private readonly string _nom;
        private double _solde;

    }
}
