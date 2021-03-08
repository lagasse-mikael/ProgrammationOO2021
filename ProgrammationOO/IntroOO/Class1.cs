using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroOO
{
    /// <summary>
    /// Fournis plusieurs utilites afin d'obtenir un Rectangle personnalise.
    /// </summary>
    /// <remarks>Remarque optionelle , comment l'utiliser par exemple!</remarks>
    class Rectangle
    {

        // Constructeur
        // Qui run a la ligne "... = new Rectangle();"

        /// <summary>
        /// Constructeur par defaut qui nous donneras un Rectangle de 4,2.
        /// </summary>
        public Rectangle()
        {
            _x = 4;
            _y = 2;
            Console.WriteLine("constructeur default");
        }

        /// <summary>
        /// Constructeur qui nous permet de donner nos valeurs et d'afficher le resultat final , tout dans la meme ligne.
        /// </summary>
        /// <param name="x">Largeur</param>
        /// <param name="y">Hauteur</param>
        public Rectangle(int x,int y)
        {
            Console.WriteLine("constructeur #2");
            SetLargeur(x);
            Hauteur = y;
            Dessiner();
        }
        
        
        // Accesseur (getter)
        /// <summary>
        /// Nous permet d'obtenir la largeur du Rectangle qui a ete initialiser.
        /// </summary>
        /// <returns>La largeur du Rectangle</returns>
        public int GetLargeur()
        {
            return _x;
        }

        // Mutateur (setter)

        public void SetLargeur(int value)
        {
            if(value>1)
            {
                _x = value;
            }
        }

        // Propriete 
        /// <summary>
        /// Propriete qui accedera/initialisera la hauteur du Rectangle.
        /// </summary>
        /// <remarks>Sera toujours plus grande que 0</remarks>
        public int Hauteur      // Pas de parentheses ()
        {
            // Dans le bloc de ma propriete , il est possible de definir 2 simili-methodes.

            // Accesseur 
            get { return _y; }

            // Mutateur
            set     // Valeur int value cacher?
            {
                if (value > 1)
                {
                    _y = value;
                }
            }
        }

        // Propriete automatique
        // Une valeur interne utilisee implicitement sans qu'on doive definir un attribut ( variable ) nom.
        public string Nom { get; set; } = "Rectangle";

        // = Lecture seule de l'exterieur , mais ecriture dans la classe ( Rectangle ) seulement.
        public int Couleur { get; private set; } = 15;

        // Une methode qui retourne la surface du rectangle
        public int CalculerSurface() { return _x * _y; }

        // Propriete pour recuperer la surface , en lecture seule.
        // Donc pas besoin de la methode set;
        public int Surface { get { return _x * _y; } }

        public void Dessiner(char symbol)
        {
            Console.WriteLine();
            for (int i = 0; i < Hauteur; i++)
            {
                for (int j = 0; j < GetLargeur(); j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            AfficherDetails();
        }
        // Et avec le caractere par defaut , on repete pas le meme code , on lui donne l'autre methode avec * comme parametre.
        public void Dessiner()
        {
            Dessiner('*');
        }

        private void AfficherDetails()
        {
            Console.WriteLine();
            Console.WriteLine(Nom);
            Console.WriteLine("Largeur = {0} , Hauteur = {1} , Surface = {2}u , Couleur = {3}", GetLargeur(), Hauteur, Surface, Couleur);
            Console.WriteLine();
        }

        public const int maConstante = 20;

        private int _x;
        private int _y;
    }

    class Horloge
    {
        // Notion du premier cours :
        // 0:D_ : Chiffre decimaux , mettre des 0 devant un nombre _ de fois.

        /// <summary>
        /// Initialisation vide.
        /// </summary>

        //public Horloge() : this(0, 0, 0) { }

        /// <summary>
        /// Initialisation de l'heure seulement.
        /// </summary>

        //public Horloge(int heure) : this(heure, 0, 0) { }

        /// <summary>
        /// Initialisation de l'heure et des minutes seulement.
        /// </summary>

        //public Horloge(int heure, int minutes) : this(heure, minutes, 0) { }

        /// <summary>
        /// Initialisation de l'heure , des minutes et des secondes.
        /// </summary>
        /// <remarks>La totale dans le fond!</remarks>

        public Horloge(int heure = 0, int minutes = 0, int secondes = 0)
        {
            if (heure > 0 && heure < 60)
                int_secondes += heure * heuresSec;
            if (minutes > 0 && heure < 60)
                int_secondes += minutes * minutesSec;
            if (secondes > 0 && secondes < 60)
                int_secondes += secondes;
        }

        /// <summary>
        /// Heures de notre Horloge en lecture seule.
        /// </summary>

        public int Heures
        {
            get { return int_secondes / heuresSec; }
        }

        /// <summary>
        /// Minutes de notre Horloge en lecture seule.
        /// </summary>
        public int Minutes
        {
            get { return (int_secondes - Heures * heuresSec) / minutesSec; }
        }

        /// <summary>
        /// Secondes de notre Horloge en lecture seule.
        /// </summary>
        public int Secondes
        {
            get { return (int_secondes - (Heures * heuresSec + Minutes * minutesSec)); }
        }

        /// <summary>
        /// Nous affiche l'heure selon l'initialisation fait au tout debut.
        /// </summary>
        public void Afficher()
        {
            Console.WriteLine("{0:D2}:{1:D2}:{2:D2}", Heures, Minutes, Secondes);
        }
        /// <summary>
        /// Nous permets de comparer deux horloges.
        /// </summary>
        public bool EstEgaleA(Horloge compH)
        {
            return this.int_secondes == compH.int_secondes;
        }

        private const int heuresSec = 3600;
        private const int minutesSec = 60;

        private int int_secondes = 0;
    }
}
