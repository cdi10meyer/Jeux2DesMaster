using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using PackageJeu;
using PackagePersistance;

namespace Testeur
{
    class Testeur
    {
        
        public static void Main(string[] args)
        {
            bool charger;
            bool supprimer;
            bool sauvegarder;
            string key;
            TypesPersistances type;
            Jeu MonJeu;

            Console.WriteLine(Jeu.Sauvegarde);

            if (Jeu.Sauvegarde)
            {
                Console.WriteLine("Voulez-vous charger la dernère partie sauvergardée? Press O pour oui");
                key = Console.ReadKey().Key.ToString();
                charger = key.ToUpper() == "O" ? true : false;
                MonJeu = new Jeu(charger);
            }
            else
            {
                MonJeu = new Jeu();
            }
            //Le jeu est crée(avec ses 2 des et son classement)
            Console.WriteLine();
            MonJeu.VoirResultat();//Affichage du jeu entier
            Console.WriteLine();
            Console.WriteLine("Jouons quelques parties....");
            Console.ReadKey();
            //Jouons quelques parties....
            MonJeu.JouerPartie(); //1ere partie avec un joueur par défaut
            MonJeu.JouerPartie(); //2eme partie avec un joueur par défaut
            MonJeu.JouerPartie("Sasha"); //3eme partie
            MonJeu.JouerPartie("Josephine"); //Encore une partie 

            Console.WriteLine();
            MonJeu.VoirResultat();//Affichage du jeu entier
            Console.WriteLine("Voulez-vous sauvegarder la partie? Press O pour oui");
            key = Console.ReadKey().Key.ToString();
            sauvegarder = key.ToUpper() == "O" ? true : false;
            Console.WriteLine();
            if (sauvegarder)
            {
                Console.WriteLine("En quel format? 1 pour Binaire, 2 pour Xml, 3 pour Json");
                int Bowl; // Variable to hold number

                ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input

                // We check input for a Digit
                if (char.IsDigit(UserInput.KeyChar))
                {
                    Bowl = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                }
                else
                {
                    Bowl = -1;  // Else we assign a default value
                }
                if(Bowl==(int)TypesPersistances.Json)
                {
                    type = TypesPersistances.Json;
                }
                else if(Bowl  == (int)TypesPersistances.Xml)
                {
                    type = TypesPersistances.Xml;
                }
                else
                {
                    type = TypesPersistances.Binaire;
                }
                MonJeu.TerminerJeu(type);
            }
            Console.WriteLine();
            if (Jeu.Sauvegarde)
            {
                Console.WriteLine("Voulez-vous supprimer la dernière sauvegarde? Press O pour oui");
                key = Console.ReadKey().Key.ToString();
                supprimer = key.ToUpper() == "O" ? true : false;
                Jeu.Delete(supprimer);
            }
            
            Console.ReadKey();            
        }
    }
}
