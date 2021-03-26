using System;
using System.Collections.Generic;       // Pour la classe Liste
using Listes;

namespace Listes
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestListeEntiers();
            //TestListeString();
            // TestListeDates();
            //TestListePersonnes();
            //TestFile();
            //TestPile();
            //Exercices.TestDeplacement();
            Exercices.TestEtudiants();

            Pause();
        }
        static void TestListeEntiers()
        {
            // Initialisation d'une liste d'entier
            List<int> liste = new List<int>();

            Random generateur = new Random();

            for (int i = 0; i < 10; i++)
            {
                // .Add fait la meme chose que .push_back
                // 10 chiffres random a mettre dans ma liste , ses chiffres seront entre 0 et 100.

                liste.Add(generateur.Next(100));
            }

            // Count indique le nombre d'elements dans la liste.
            Console.WriteLine("Taille de la liste : " + liste.Count);
            Console.WriteLine("Voici les chiffres obtenues : ");

            foreach (var chiffre in liste)
            {
                Console.WriteLine(chiffre);
            }

            // S'utilise litteralment comme un array.
            Console.WriteLine("Premier element : {0}", liste[0]);
            Console.WriteLine("Dernier element : {0}", liste[liste.Count - 1]);

            // Changement a la deuxieme position
            liste[2] = 200;

            // Trier
            liste.Sort();

            Console.WriteLine("Apres les modifications : ");
            foreach (var chiffre in liste)
            {
                Console.WriteLine(chiffre);
            }

        }
        static void TestListeString()
        {
            List<string> listeString = new List<string>() { "Zero", "Deux", "Trois", "Quatre", "Trois" };

            AfficherListeString(listeString);

            // .Insert(index,string) INSERT a l'index et repousse le tout ,
            // tandis que [index] = string REMPLACE a l'index.
            Console.WriteLine("Insertion de Deux a la position 1");
            listeString.Insert(1, "Un");
            AfficherListeString(listeString);

            // Nous retourne l'index du string trouver.
            // Nous indiqueras -1 s'il ne trouve pas le string dans la liste.
            int index = listeString.IndexOf("Trois");

            Console.WriteLine("Premiere position de 'Trois' : {0}", index);
            Console.WriteLine("Prochaine position de 'Trois' : {0}", listeString.IndexOf("Trois", index + 1));
            Console.WriteLine("Derniere position de 'Trois' : {0}", listeString.LastIndexOf("Trois"));

            Console.WriteLine("---------------------------");
            Console.WriteLine("Enleve la derniere occurence de 'Trois'");
            // Enleve seulement la PREMIERE occuruence.
            // Il faudrais utiliser .RemoveAll(aEnlever) pour tout les supprimer.
            listeString.Remove("Trois");

            AfficherListeString(listeString);

            Console.WriteLine("Element a la position 3 : {0}", listeString[3]);
            Console.WriteLine("On enleve l'element a la postion 3");

            listeString.RemoveAt(3);
            AfficherListeString(listeString);

            // On peut utiliser .Insert() avec .Count , car on "sort" 
            // en etant positionner directement apres la derniere valeur de notre liste.

            // C'est la seule fois ou on pourra "sortir" de notre liste , mais .Add est plus appropriere de toute maniere.

            listeString.Insert(listeString.Count, "Cinq");
            AfficherListeString(listeString);

            Console.WriteLine("En ordre decroissant");

            // Pour trier en ordre decroissant , on doit : 
            // Trie en ordre croissant 
            listeString.Sort();
            // Et reverse le tout.
            listeString.Reverse();

            AfficherListeString(listeString);

            // Pour vider la liste.
            Console.WriteLine("On supprime tout les elements de notre liste");
            listeString.Clear();

            AfficherListeString(listeString);

            // Pour enlever un 'range' , on utilise .RemoveRange(index,range)
            listeString.RemoveRange(3, 4);

        }
        static void AfficherListeString(List<string> ls)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Taille de la liste : {0}", ls.Count);
            foreach (var item in ls)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------");
        }

        static void TestListeDates()
        {
            List<DateTime> listeDate = new List<DateTime>()
            {
                // Annee , Mois , Jour
                new DateTime(2021 , 03 , 10),
                new DateTime(2022 , 01 , 20),
                new DateTime(2005 , 03 , 05),
                // Annee , Mois , Jour , Heure , Minute, Secondes
                new DateTime(1999 , 06 , 13 , 22 , 29 , 30)
            };

            // la propriete static Now nous retourne un nouvel objet 'DateTime' initialiser a l'heure actuel de l'ordinateur.
            // On ne pourrait pas faire "objet.Now" , .'Now' doit etre appeler sur la classe DIRECTEMENT.

            // Ceci nous cree un objet avec l'heure actuel de l'ordinateur.
            // Donc inutile de faire 'new DateTime()' , car DateTime.Now nous retournes un objet.
            DateTime maintenant = DateTime.Now;
            Console.WriteLine("En ce moment meme : {0}", maintenant);

            DateTime aujourdhui = DateTime.Today;
            Console.WriteLine("Aujourdhui : {0}", aujourdhui.DayOfWeek);

            try
            {
                Console.WriteLine("Veuillez entrer une date (A/M/J) : Exemple de reponse -> '2002/08/12'");

                DateTime reponse = Convert.ToDateTime(Console.ReadLine());

                skip();

                Console.WriteLine("Date courte : {0}", reponse.ToShortDateString());
                Console.WriteLine("Date longue : {0}", reponse.ToLongDateString());

                if (reponse == DateTime.Now)
                    Console.WriteLine("C'est aujoudhui ca...");
                else if (reponse < DateTime.Now)
                {
                    TimeSpan diff = DateTime.Now - reponse;
                    Console.WriteLine("C'est dans le passer de {0} jours.", diff.Days);
                }
                else
                {
                    TimeSpan diff = reponse - DateTime.Now;
                    Console.WriteLine("C'est dans le futur de {0} jours",diff.Days);
                }

                if (DateTime.IsLeapYear(reponse.Year))
                    Console.WriteLine("C'est une annee bisextille!");
                else
                    Console.WriteLine("Ce n'est pas une annee bisextille");

                Console.WriteLine("Le mois de {0} compte {1} jours", reponse.ToString("MMMM"), DateTime.DaysInMonth(reponse.Year,reponse.Month));

                Console.WriteLine("Date ajouter a la liste de dates!");
                listeDate.Add(reponse);
                skip();

                Console.WriteLine("Veuillez entrer une date ainsi que l'heure (A/M/J) et (H:M:S) : Exemple de reponse -> ' 2002/08/12 12:30:0 '");

                reponse = Convert.ToDateTime(Console.ReadLine());

                skip();

                Console.WriteLine("Date courte : {0}", reponse.ToShortDateString());
                Console.WriteLine("Date longue : {0}", reponse.ToLongDateString());
                Console.WriteLine("Heure courte : {0}", reponse.ToShortTimeString());
                Console.WriteLine("Heure longue : {0}", reponse.ToLongTimeString());

                Console.WriteLine("Date ajouter a la liste de dates!");
                listeDate.Add(reponse);
                skip();

            }
            catch (FormatException e)
            {
                Console.WriteLine("Bien essayer...");
            }

            listeDate.Sort();

            Console.WriteLine("Notre liste de date : ");
            skip();

            foreach (var date in listeDate)
            {
                // Attention de ne pas faire 'date.ToShortTimeString()'
                Console.WriteLine("Date courte : {0}", date.ToShortDateString());
                Console.WriteLine("Date longue : {0}", date.ToLongDateString());
                Console.WriteLine();
            }


        }

        static void TestListePersonnes()
        {
            List<Personne> listePersonne = new List<Personne>();

            listePersonne.Add(new Personne("Mikael", "Lagasse", 18));
            listePersonne.Add(new Personne("Jacque", "Lagasse", 79));
            listePersonne.Add(new Personne("Bernadine", "Lagasse", 26));

            // Faute dans le prenom , c'est voulu
            Personne donatien = new Personne("Donatn", "Dallaire", 19);

            listePersonne.Add(donatien);

            foreach (var personne in listePersonne)
            {
                personne.Afficher();
            }

            // On remarque l'erreur , donc on veux la corriger.
            donatien.Prenom = "Donatien";

            skip();

            Console.WriteLine("Apres la modification : ");

            skip();

            foreach (var personne in listePersonne)
            {
                personne.Afficher();
            }

            skip();

            // On remarque donc que lorsque nous avons ajouter 'donatien' dans notre liste, on a enfait ajouter une reference a l'objet 'donatien'.
            // Ce qui veux dire que tout changement apporter a 'donatien' seront aussi fait dans la liste.

            // Donc lorsqu'on insert/ajoute un objet dans une liste , on ajoute pas un nouvel objet ( d'ou la raison pourquoi il n'y a pas de 'new' ) , mais bien une reference a notre objet.

            if(listePersonne.Contains(donatien))
            {
                Console.WriteLine("SALUT DONATIEN!!!!");
            }
            else
            {
                Console.WriteLine("holy fuck y'est ou Donatien?!?");
            }

            Personne donatien2 = new Personne("Donatien", "Dallaire", 19);
            donatien2.Afficher();

            if (listePersonne.Contains(donatien2))
            {
                Console.WriteLine("SALUT DONATIEN!!!!");
            }
            else
            {
                Console.WriteLine("holy FUCK y'est ou Donatien?!?");
            }

            // Ici , on trouve pas donatien.
            // On pourrait prendre cette comparaison suivante pour expliquer pourquoi ca ne fonctionne pas :
            // On compare un Rectangle de 3x3 avec un Carre de 3x3 , oui , ils ont les memes valeurs / proprietes 
            // , mais ceux-ci sont deux objets differents.

        }

        static void TestFile()
        {
            // une file est une structure dans laquelle il n'est possible d'ajouter qu'a la fin,
            // et de retirer qu'au début 
            // exemple : une file d'attente

            Queue<string> clients = new Queue<string>();

            //Enqueue = enfiler
            clients.Enqueue("Arthur");
            clients.Enqueue("Beatrice");
            clients.Enqueue("Clovis");

            afficherFile(clients);

            Console.WriteLine("Le client en tête de la file: " + clients.Peek());

            // .RemoveAt(0)
            string clientAServir = clients.Dequeue();

            Console.WriteLine("On a servi le client : " + clientAServir);

            Console.WriteLine("La queue apres avoir servis Arthur : ");

            afficherFile(clients);

            // On utilise Queue si on veux garder l'ordre de nos objets/elements.

            // Premier arrivee , premier servie. ( FIFO = First in , first out )
        }

        static void afficherFile(Queue<string> file)
        {
            foreach (var item in file)
            {
                Console.WriteLine(item);
            }
        }

        static void TestPile()
        {
            // Stack ( Pile ) est assez "self-explanatory" , on peut comparer ca a une pile de carte / d'assiette.
            // On "joue" seulement avec le debut de la pile ( le plus recent de la pile ) .

            Stack<CarteAJouer> cartes = new Stack<CarteAJouer>();

            // Push nous mets un elements X au debut de la pile.

            cartes.Push(new CarteAJouer(2,Suite.Carreau));
            cartes.Push(new CarteAJouer(10, Suite.Trefle));
            cartes.Push(new CarteAJouer(13, Suite.Pique));
            cartes.Push(new CarteAJouer(1, Suite.Coeur));
            // Donc celle-ci "lead"
            cartes.Push(new CarteAJouer(5, Suite.Trefle));

            foreach (var item in cartes)
            {
                Console.WriteLine(item.Description);
            }

            // Peek nous donne l'objet au sommet de la pile.
            Console.WriteLine("Au dessus , c'est le {0}", cartes.Peek().Description);

            // Pop retire l'objet ce qui est au dessus.
            CarteAJouer retirer = cartes.Pop();
            Console.WriteLine("Le {0} a ete retirer du paquet.", retirer.Description);

            Console.WriteLine("Ajout d'une nouvelle carte!");
            cartes.Push(new CarteAJouer(12, Suite.Pique));

            Console.WriteLine("Au dessus , c'est maintenant le {0}", cartes.Peek().Description);

            foreach (var item in cartes)
            {
                Console.WriteLine(item.Description);
            }

            // Dernier arrive , premier servi ( LIFO : Last In , First Out );

        }
        static void Pause()
        {
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true);
        }

        static void skip()
        {
            Console.WriteLine();
        }
    }
}
