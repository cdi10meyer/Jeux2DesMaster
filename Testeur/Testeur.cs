using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Jeu2Des;


namespace Testeur
{
    class Testeur
    {
        
        public static void Main(string[] args)
        {
            bool charger;
            //bool supprimer;
            bool sauvegarder;
            string key;
            Jeu MonJeu;

            Console.WriteLine(Jeu.Sauvegarde);
            //Jeu.SupprimerSauvegarde();
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
            if (sauvegarder)
            {
                Console.WriteLine("En quel format? B pour Binaire, X pour Xml, J pour Json");
                key = Console.ReadKey().Key.ToString();
                MonJeu.TerminerJeu(key);
            }
            
            //if (Jeu.Sauvegarde)
            //{
            //    Console.WriteLine("Voulez-vous supprimer la dernière sauvegarde? Press O pour oui");
            //    key = Console.ReadKey().Key.ToString();
            //    supprimer = key.ToUpper() == "O" ? true : false;
            //    Jeu.SupprimerSauvegarde(supprimer);
            //}


            Console.ReadKey();            
        }
    }
}
