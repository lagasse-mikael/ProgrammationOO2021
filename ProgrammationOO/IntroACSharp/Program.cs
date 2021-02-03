// Premier programme en C#


using System;
using System.Text;      // Pour le StringBuilder
// est la meme chose que : 
// using namespace std;

// L'ordre des fonctions n'est pas importante

class Program
{
    static void Main()
    {
        //TestDeBase();
        //TestDeControles();
        //TestDeValeurs();
        //TestDeTableaux();
        TestDeChainesDeCaracteres();

        Console.ReadKey();
        Console.Clear();

        // Readline prend ce qu'on ecrit sur la ligne
        Console.WriteLine("Veuillez ecrire quelque chose : ");
        string String = Console.ReadLine();
        Console.WriteLine("Input : " + String);

        // ?
        Console.ReadKey();

        // Il y a deja une pause a la fin du programme , donc dois-je en mettre une autre?
        // Oui , car cette pause est juste presente si activer sur Visual Studio.


    }
    static void TestDeBase()
    {
        // Simple message avec ) inclus.
        Console.WriteLine("Hello World");

        // Pause jusqu'a ce qu'on appuie sur une touche quelconque
        Console.WriteLine("Pause avec ReadKey()");
        Console.ReadKey();

        // system("cls")
        Console.Clear();

        // Types de base
        int entier = 12;
        double nombreReel = 34.56;
        char caractere = 'C';
        bool booleen = true;

        // Type complexe
        string chaineDeCaracteres = "Bonjour";

        // Constantes
        const double Pi = 3.1415;

        Console.WriteLine("Entier: " + entier + ", Réel: " + nombreReel + ", Caractère: " + caractere
        + ", Booléen: " + booleen + ", Chaine: " + chaineDeCaracteres);

        // Fait un peu penser au C.
        Console.WriteLine("Entier : {0} , Réel : {1} , Chaine: {2}, entier est toujours : {0}",entier,nombreReel,chaineDeCaracteres);
        /*
         * Position 0 : enter;
         * Position 1 : nombreReel;
         * Position 2 : chaineDeCaracteres;
         * 
         * On peut les reutiliser plus qu'une fois dans la meme chaine.
         * 
         */

        // On pourrait utiliser Console.Write() a la place de ConsoleWriteLine() , on ne changerais pas de ligne par contre!

        Console.ReadKey();

    }
    // Lit une chaine de caractères et retourne sa conversion en entier
    static int ObtenirEntier(int min, int max)
    {

        Console.WriteLine("Entrez un entier entre " + min + " et " + max + ": ");

        string ligne = Console.ReadLine();

        // On ne valide pas les erreurs, mais le programme va quand meme planter si l'utilisateur n'est pas gentil
        
      //return stoi(ligne);
        return Convert.ToInt32(ligne);
    }

    static void TestDeControles()
    {
        const int MIN = 1;
        const int MAX = 10;

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("Nombre #" + i + 1);

            while (true)
            {

                int entier = ObtenirEntier(MIN, MAX);

                if (entier >= MIN && entier <= MAX)
                {
                    switch (entier)
                    {
                        case 1:
                            Console.WriteLine("Un");
                            break;
                        case 2:
                            Console.WriteLine("Deux");
                            break;
                        case 3:
                            Console.WriteLine("Trois");
                            break;
                        default:
                            Console.WriteLine("Hein?");
                            break;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Ishh , recommence dont..");
                }
            }
        }
        Console.Write("Entrez un chiffre textuellement : ");
        string Nombre = Console.ReadLine();

        switch(Nombre)
        {
            case "un":
            case "Un":
                Console.WriteLine("1");
                break;
            case "deux":
            case "Deux":
                Console.WriteLine("2");
                break;
            case "trois":
            case "Trois":
                Console.WriteLine("3");
                break;
            default:
                Console.WriteLine("Et ainsi de suite..");
                break;
        }
    }
    static void TestDeValeurs()
    {
        int nbre1;
        int nbre2;
        int nbre3;

        ObtenirValeurs(out nbre1,out nbre2,out nbre3);

        Console.WriteLine("Apres ObtenirValeurs() : ");
        Console.WriteLine("Nombre 1 : " + nbre1);
        Console.WriteLine("Nombre 2 : " + nbre2);
        Console.WriteLine("Nombre 3 : " + nbre3);

        // Comparer au C++ , on doit le mentionner ici aussi qu'on les passe en reference , contrairement au C++ ou c'est seulement dans les parametres de la fonction
        ModifierValeur(ref nbre1, ref nbre2, ref nbre3);

        Console.WriteLine("Apres ModifierValeurs() : ");
        Console.WriteLine("Nombre 1 : " + nbre1);
        Console.WriteLine("Nombre 2 : " + nbre2);
        Console.WriteLine("Nombre 3 : " + nbre3);
    }
    //                  C++ : (int& nbre1, int& nbre2, int& nbre3)
    static void ModifierValeur(ref int nbre1, ref int nbre2, ref int nbre3)
    {
        // On pourrait utiliser n'importe quel operateur : + - * / % 
        // Ou une variante d'assignation : += -= /= *= %=
        // Ou une incrementation / decrementation : ++ --

        nbre1 = nbre2 * 5;
        nbre2 += 100;
        nbre3 = (nbre2 + 3) % 7;
    }
    static void ObtenirValeurs(out int nbre1, out int nbre2, out int nbre3)
    {
        nbre1 = 17;
        nbre2 = 42;
        nbre3 = 49;

        // nbre3 , aucun changement.

    }

    static void TestDeTableaux()
    {
        // Array , enfin.

        int[] tableauEntiers = { 0, 1, 2, 3, 5, 8, 13 };        // Tableau de 7 element , de taille 6. On ne peut pas le redimensionner.

        Console.WriteLine("Mon premier entier est " + tableauEntiers[0]);
        Console.WriteLine("La longueur de ma table est de " + tableauEntiers.Length);
        Console.WriteLine("Et mon dernier entier est " + tableauEntiers[(tableauEntiers.Length - 1)]);

        // Console.WriteLine("Et apres mon dernier entier , on a " + tableauEntiers[(tableauEntiers.Length)]);

        for (int i = 0; i < tableauEntiers.Length; i++)
        {
            Console.WriteLine("Tableau Index #" + (i + 1) + " : " + tableauEntiers[i]);
        }

        Console.WriteLine();

        foreach (int item in tableauEntiers)
        {
            Console.Write(item + ",");
        }

        Console.WriteLine();

        // Modification dans un tableau.

        string[] nomsMois = { "Janvier", "Fevrier", "Mars", "Mai" };

        Console.WriteLine("Mon deuxieme mois est " + tableauEntiers[1]);

        nomsMois[3] = "Avril";

        foreach (string item in nomsMois)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

    }

    static void TestDeChainesDeCaracteres()
    {
        string maChaine = "Bonjour";
        // maChaine.Length = 6;
        // string[] maChaine = { 'B','o','n','j','o','u','r');

        // Length aussi disponible pour les strings
        Console.WriteLine("Longueur de la chaine : {0}, le premier caractere de ma chaine est {1} et le dernier caractere est {2}", maChaine.Length,maChaine[0],maChaine[maChaine.Length - 1]);
    
        // On peut foreach aussi.
        // On s'entend qu'en prennant les lettres d'un string , on a plusieurs caracteres.
        
        // Bin c'est ca la

        foreach(char lettre in maChaine)
        {
            Console.WriteLine(lettre);
        }

        // Impossible de modifier le contenu d'un string.
        // maChaine[1] = 'a'; 
        // N O N , LECTURE SEULE

        // Il est par contre possible d'assigner du nouveau contenu , de l'ecraser au complet.
        maChaine = "LOLLLL";

        //Ou en rajouter!

        maChaine += " ET MDR";
        maChaine += '!';

        Console.WriteLine(maChaine);

        string[] mots = maChaine.Split(' ');

        foreach (string mot in mots)
        {
            Console.WriteLine(mot);
        }

        maChaine = "                                 Une chaine de caracteres avec des espaces avant et apres                           ";

        Console.WriteLine("Ma chaine originale : .{0}.",maChaine);

        //Trim : Enlever les espaces au debut et a la fin d'un string
        //TrimStart : Enlever les espaces au debut d'un string
        //TrimEnd : Enlever les espaces a la fin d'un string

        maChaine = maChaine.Trim();

        Console.WriteLine("Ma chaine apres Trim : .{0}.", maChaine);

        Console.WriteLine();

        string aChercher = "Une";

        if(maChaine.Contains(aChercher))
        {
            Console.WriteLine("La chaine contient {0}!", aChercher);
            if (maChaine.StartsWith(aChercher))
            {
                Console.WriteLine("La chaine debute par {0}", aChercher);
            }
            else
            {
                Console.WriteLine("La chaine ne debute pas par {0}", aChercher);
            }
        }
        else
        {
            Console.WriteLine("La chaine ne contient pas {0}!", aChercher);
        }

        int index = maChaine.IndexOf("de");

        Console.WriteLine("Le mot 'de' commence a la position : {0}",index);

        // On recherche a partir de la position du "de" (index) + 1

        index = maChaine.IndexOf("de",index+1);

        Console.WriteLine("Le prochain 'de' commence a la position : {0}", index);

        // Encore

        index = maChaine.IndexOf("de", index + 1);

        Console.WriteLine("Le prochain 'de' commence a la position : {0}", index);

        // Ici on recoit un index de  -1 , ce qui veux dire qu'il n'a pas trouver le mot rechercher.

        int l_index = maChaine.LastIndexOf("de");

        Console.WriteLine("Le prochain 'de' commence a la position (LastIndexOf) : {0}", l_index);

        // Extraire du string d'un autre string avec la position et la longueur du string qu'on veut.

        string stringObtenu = maChaine.Substring(4, 6);

        Console.WriteLine("Sous-chaine = {0}", stringObtenu);

        
        // All-caps

        
        Console.WriteLine("Tout en majuscule : {0}", maChaine.ToUpper());

        // Allignement du texte dans la console

        // 0:D_ : Chiffre decimaux , mettre des 0 devant un nombre _ de fois.
        // 0:F_ : un peu comme setprecision en C++ , tres utile!
        // X : Hexadecimal

        // Il y en a plein d'autres! https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings

        Console.WriteLine("Allignement du texte dans la console");
        Console.WriteLine(" |{0,10}|{0,-10}|{1,8:X}|{2,6}|{2}|{3,12}|{3}|","allo",12,5,34.56789);

        // using System.Text

        maChaine = "bonjour le monde";

        //Le StringBuilder garde une copie de la chaine
        StringBuilder builder = new StringBuilder(maChaine);

        builder[0] = 'B';

        // On peut append presque tout les types.

        builder.Append("! ");

        builder.Append(123123);

        // Inserer du texte a une position choisi

        builder.Insert(8, "abcdefg ");

        // Remove , a partir de la position 13 , enleve 2 caracteres

        builder.Remove(13,2);

        // Replace , on dit qu'elle SunString enlever et par quoi le remplacer.

        builder.Replace("abcde", "tout");

        builder.Replace(" ", ", ");

        maChaine = builder.ToString();
        Console.WriteLine(maChaine);

        StringBuilder builder2 = new StringBuilder();   // Chaine vide

        // Prend le format d'affichage de WriteLine()
        builder2.AppendFormat(" |{0,10}|{0,-10}|{1,8:X}|{2,6}|{2}|{3,12}|{3}|", "allo", 12, 5, 34.56789);

        Console.WriteLine(builder2);

    }
}