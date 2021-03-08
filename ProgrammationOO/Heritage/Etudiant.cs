using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    // Cette declaration nous indique qu'Etudiant est derive de Personne
    // Cette utilisation de deriver , on doit avoir des constructeurs par defaut. OBLIGATOIRE


    /* protected : exemple 
    
        Class parent
                    en descendant : protected int numero;
        Class enfant
                    Correct!
    */


    class Etudiant : Personne
    {
        public Etudiant() { Console.WriteLine("OK.. ETUDIANT()"); }

                                                                        // Appel le constructeur de base dans Personne.
        public Etudiant(string prenom,string nom,int age , int matricule) : base(prenom,nom)        // <-- 'base()' , important!
        { 
            Console.WriteLine("OK.. ETUDIANT() - 1 ARGUMENT + BASE(3 ARGUMENTS)");

            Matricule = matricule;

            // Accessible dans la classe derivee , car protected.
            _adresse = "13300 Rue Leveille";

            // private ne donne pas acces meme dans une classe deriver
            // _numeroAssuranceMaladie = "ABC1234";
        }

        public int Matricule { get; protected set; }

        protected int NumeroDeTelephone { get; set; }

        public void informationEtudiant()
        {
            direBonjour();
            Console.WriteLine("Mon matricule est le {0}", Matricule);
        }

    }
}
