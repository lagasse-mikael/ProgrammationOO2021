using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestExceptions();
            //DemanderValeur();

            Validateur v = new Validateur();
            v.Executer();


            Console.WriteLine("Fin du main()");
            Console.ReadKey();
        }

        static void TestExceptions()
        {
            int[] tableau = { 43,12,35,66,26 };

            bool erreur = true;

            // On pretend qu'il y a deja une erreur , simplement pour rentrer dans la boucle while()
            while (erreur)
            {

                try
                {
                    // C'qui est initialiser dans le try ,est effacer a la fin du try.

                    Console.Write("Entrez un index : ");

                    int index = Convert.ToInt32(Console.ReadLine());

                    ValiderValeur(index);

                    Console.Clear();

                    Console.WriteLine("Valeur a l'index " + index + " : " + tableau[index]);

                    Console.WriteLine("Division de la valeur par l'index : " + tableau[index] / index);
                    erreur = false;     // break;
                }
                // Classe derivee d'Exception
                catch (FormatException f_e)
                {
                    Console.WriteLine("Conversion non possible");
                    Console.WriteLine("Veuillez vous assurer de nous donner un chiffre qui fait du sens.");
                }
                catch (DivideByZeroException z_e)
                {
                    Console.WriteLine("Division par 0 non possible");
                    Console.WriteLine("Le chiffre entrer etait bon , par-contre il est impossible de diviser un chiffre par 0.");
                }
                catch (IndexOutOfRangeException i_e)
                {
                    Console.WriteLine("Hors de l'index.");
                    Console.WriteLine("Le chiffre entrer n'est pas une position valide dans notre array de chiffre.");
                }
                // Classe mere , elle prend en compte toute les exceptions
                // Doit etre en dernier.
                // Sinon c'est le premier executer , donc il serait inutile d'avoir d'autre types
                catch (Exception ex)
                {
                    Console.WriteLine("Something's not right.");
                    Console.WriteLine("Exception de type : " + ex.GetType());
                    Console.WriteLine("Exception : " + ex.Message);

                }

                Console.WriteLine("L'execution continue apres le bloc try/catch");

                try
                {
                    DemanderValeur();
                    // S'il y a eu une exception autre qu'ArgumentOutOfRangeException/MonException , elle sera traiter par l'autre catch juste ici.
                    Console.WriteLine("Valeur demander!");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception de base.");
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void DemanderValeur()
        {
            try
            {
                Console.Write("Entrez un nombre entre 1 et 10 : ");

                int nombre = Convert.ToInt32(Console.ReadLine());
                ValiderValeur(nombre);

                // On sauterais a partir d'ici s'il y a eu une exception

                Console.WriteLine("La valeur {0} est valide!", nombre);
            }
            //catch(ArgumentException a_e)
            catch (MonException m_e)
            {
                Console.WriteLine(m_e.Message);
            }

            // Un seul type attraper, les autres vont continuer.
        }

        /// <summary>
        /// Valide que la valeur demander est entre 1 et 10
        /// </summary>
        /// <param name="valeur"></param>
        /// <exception cref="MonException">Si la valeur est invalide</exception>
        static void ValiderValeur(int valeur)
        {
            if(valeur < 1 || valeur > 10)
            {
                throw new MonException("Valeur n'est pas situer entre 1 et 10");
            }

            Console.WriteLine("Validation terminer!");
        }
    }

    class MonException : Exception
    {
        // Prend un message , qu'il donne au constructeur d'Exception
        public MonException(string description) : base(description)
        { }
    }
}
