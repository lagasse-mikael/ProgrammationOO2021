using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne marc = new Personne("Marc","Labreche",18);

            marc.direBonjour();

            Etudiant jo = new Etudiant("Jo","Labreche",24,12342);

            jo.informationEtudiant();

            Etudiant bob = new Etudiant("Bob","Roy",17,111111);

            bob.informationEtudiant();

            Enseignant hebert = new Enseignant("Hebert", "Belanger", 38, 1234, "Francais");

            hebert.informationEnseignant();

            Console.WriteLine("\n");
            Console.ReadKey();

        }
    }
}
