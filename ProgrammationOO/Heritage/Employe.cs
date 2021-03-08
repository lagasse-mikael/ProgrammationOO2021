using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    class Employe : Personne
    {
        public Employe(string prenom, string nom, int age, int numero) : base(prenom, nom, age)
        {
            Console.WriteLine("CONSTRUCTEUR PARAMETRES - EMPLOYE - 4 ARGUMENTS - 4 BASE()");

            NumeroEmploye = numero;
        }

        public void informationEmploye()
        {
            direBonjour();
            Console.WriteLine("Mon numero d'employe est le {0}", NumeroEmploye);
        }

        public int NumeroEmploye { get; set; }
    }

    class Enseignant : Employe
    {
        public Enseignant(string prenom, string nom, int age, int numero,string cours) : base(prenom, nom, age, numero)
        {
            Console.WriteLine("CONSTRUCTEUR PARAMETRES - ENSEIGNANT - 5 ARGUMENTS - 4 BASE()");
            _cours = cours;
        }
        public void informationEnseignant()
        {
            informationEmploye();
            Console.WriteLine("et mon cours est le {0}", _cours);
        }

        private string _cours;
    }
}
