using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroOO
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestRectangle();
            //TestHorloge();
            TestAleatoire();

            //SimulateurBanque simulateur = new SimulateurBanque();
            //simulateur.Simuler();

            Pause();
        }

        #region Autres
        static void TestRectangle()
        {
            Rectangle rec = new Rectangle();

            rec.Nom = "Notre rectangle!";
            
            // On l'utilise comme une variable.
            Console.Write("Hauteur? ");
            rec.Hauteur = Convert.ToInt32(Console.ReadLine());

            // Tandis qu'ici c'est plutot comme une methode
            Console.Write("Largeur? ");
            rec.SetLargeur(Convert.ToInt32(Console.ReadLine()));

            // Oriente Objet
            rec.Dessiner('O');

            // Procedural
            // RectangleDessiner(rec);

            // Et pour cree un nouvel objet :
            Rectangle rec2 = new Rectangle();

            rec.Nom = "Notre deuxieme rectangle!";
            rec.Hauteur = 20;
            rec.SetLargeur(20);

            rec.Dessiner();

            // Un autre objet de type rectangle
            // Constructeur different , il fait tout "one shot"

            Rectangle rec3 = new Rectangle(20,30);

            ModifierRectangle(rec3);
            Console.WriteLine("Apres avoir modifier le Rectangle #4");
            rec3.Dessiner();
        }

        static void ModifierRectangle(Rectangle rec)
        {
            // Un objet ( une variable de type d'une classe ) sera toujours considere comme une reference
            // lorsque passer en parametre , meme sans specifier 'ref'.
            rec.SetLargeur(3);
            rec.Hauteur = 7;
        }
                

        static void TestHorloge()
        {
            // Definit une horloge a 0 heure , 0 minute et 0 seconde
            Horloge h0 = new Horloge();

            h0.Afficher();      // 00:00:00

            // Definit une horloge a 12 heure , 0 minute et 0 seconde
            Horloge h1 = new Horloge(12);

            h1.Afficher();      // 12:00:00

            // Definit une horloge a 12 heure , 34 minute et 0 seconde
            Horloge h2 = new Horloge(12,34);

            h2.Afficher();      // 12:34:00

            // Definit une horloge a 12 heure , 34 minute et 0 seconde
            Horloge h3 = new Horloge(12,34,56);

            h3.Afficher();      // 12:34:56

            Console.WriteLine("Heures de Horloge #3 : {0}", h3.Heures);
            Console.WriteLine("Heures de Horloge #3 : {0}", h3.Minutes);
            Console.WriteLine("Heures de Horloge #3 : {0}", h3.Secondes);

            // L'horloge doit valider les parametres
            // Heures entre 0 et 23
            // Minutes et seondes entre 0 et 59

            // Valeurs invalide sont ignorer silencieusement

            Horloge h4 = new Horloge(3, -5, 67);
            h4.Afficher();      //03:00:00

            Horloge h5 = new Horloge(12, 34, 0);
            h5.Afficher();      // 12:34:00


            if(h2.EstEgaleA(h5))
            {
                Console.WriteLine("h2 est egales a h5");        // Resultat attendu!
            }
            else
            {
                Console.WriteLine("h2 n'est pas egales a h5");
            }

            if (h2.EstEgaleA(h3))
            {
                Console.WriteLine("h2 est egales a h3");
            }
            else
            {
                Console.WriteLine("h2 n'est pas egales a h3");        // Resultat attendu!
            }

            // Contraintes
            // La classe horloge ne doit contenir qu'un seul attribut : int_secondes;
            // Contient la valeur de l'horloge sous la forme d'un nombre total de secondes
            // 60 secondes par minutes , 3600 seondes par heure

        }
        #endregion
        static void Pause()
        {
            Console.WriteLine("Appuyez sur une touche pour continuer..");
            Console.ReadKey(true);
        }
        static void TestAleatoire()
        {
            Random aleatoire = new Random();

            Console.WriteLine("Generation de 5 nombre entier aleatoire");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0}", aleatoire.Next(100));
            }
        }

        static void TestVar()
        {
            // Utiliser var detecte quel type de variable que c'est.

            var i = 5;          // int , long , uint ???
            var reel = 3.4;     // float , double , decimal ???

            int[] tableau = { 1, 2, 3 };

            foreach (var item in tableau)
            {
                // On peut laisser var , il vas detecter avec le tableau
            }
        }
    }
}
