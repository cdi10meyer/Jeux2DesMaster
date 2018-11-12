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
                       
            //Le jeu est crée (avec ses 2 des et son classement)
            Jeu MonJeu = new Jeu();         

            //Jouons quelques parties ....
            MonJeu.JouerPartie(); //1ere partie avec un joueur par défaut
            MonJeu.JouerPartie(); //2eme partie avec un joueur par défaut
            MonJeu.JouerPartie("David"); //3eme partie
            MonJeu.JouerPartie("David"); //Encore une partie  
            MonJeu.JouerPartie("Sarah"); //Encore une partie 
            MonJeu.JouerPartie("Lucie"); //Encore une partie
            MonJeu.JouerPartie(); //Encore une partie 
            
            Console.ReadKey();            
        }
    }
}
