using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    class Personne
    {
        public Personne() { Console.WriteLine("OK.. PERSONNE() - DEFAUT"); }

        public Personne(string prenom,string nom)
        {

        }

        public Personne(string prenom,string nom,int age)
        {
            Console.WriteLine("OK.. PERSONNE() - 3 ARGUMENTS");
            Prenom = prenom;
            Nom = nom;
            Age = age;
        }

        // Proprietes d'une personne
        public string Prenom { get; set; }

        public string Nom { get; set; }

        public int Age { get; set; }

        public void direBonjour()
        {
            Console.WriteLine("Bonjour! Je m'apelle {0} {1} et j'ai {2} ans.", Prenom, Nom, Age);
        }

        // protected est entre public et private , pour donner acces aux classes derivees.
        protected string _adresse;

        private string _numeroAssuranceMaladie;
    }
}
