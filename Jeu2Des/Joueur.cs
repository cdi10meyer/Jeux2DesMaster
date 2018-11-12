using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{
    /// <summary>
    /// Décrit un joueur du Jeu2Des
    /// </summary>
    /// <remarks></remarks>class Joueur
    public class Joueur
    {
     
      private static int  _Compteur = 1 ; //Pour donner un nom par défaut au joueur

      //Idée : on pourrait ajouter ici une liste pour garder les résultats de tous les lancers du joueur

      private string _Nom ;
      /// <summary>
      /// Nom du joueur
      /// </summary>
      /// <value>Un nom</value>
      /// <returns>Le nom du joueur</returns>
      /// <remarks></remarks>
      public string Nom
      {
        get{return _Nom;}      
        set {_Nom = value;}       
      }

      private int _Score  = 0;
      /// <summary>
      /// Le score du joueur vaut 0 quand le joueur n'a pas encore joué, est égal au total qaund la partie est terminée 
      /// Cette propriété est en lecture seule, seule la méthode jouer le modifie
      /// </summary>
      /// <returns>Le score du joueur</returns>
      /// <remarks></remarks>
      public int Score
      {
            get{ return _Score ;}       
      }

       /// <summary>
       /// Crée un nouveau joueur à partir de son nom  
       /// </summary>
       /// <param name="nom">Le nom du joueur</param>
       
       public Joueur(string nom)
       {
            _Nom = nom.ToUpper();
            _Score = 0;
       }

        /// <summary>
        /// Crée un nouveau joueur avec un nom par défaut : Joueur 1, Joueur 2, ...
        /// Le numero attribué est géré automatiquement 
        /// </summary>
        /// <remarks></remarks>
        public Joueur() : this("Joueur" + _Compteur)
        { _Compteur ++; }
        

        /// <summary>
        /// Joue une partie : lance les 2 Des 10 fois et calacule le score du joueur
        /// A chaque lancer :  si le total des 2 Des est égal à 7 le joueur marque 10 points sinon 0 
        /// </summary>
        /// <param name="des">Les 2 dés</param>
        /// <returns>Le score du joueur</returns>
        /// <remarks></remarks>
        public int Jouer(De[] des)
        {

            for (int i = 1; i < 10; i++)
            {
                int total = des[0].Lancer() + des[1].Lancer();
                if (total == 7)
                    _Score = _Score + 10;
            }

            //TODO : dans cette version le résutat est affiché à la console
            //TODO : en attendant la mise e place du classement 
            Console.WriteLine(this.ToString()); 
            return _Score;
        }

        /// <summary>
        /// Affiche le nom du joueur et son score 
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public override string ToString()
        {
            return base.ToString() + " " + Nom + ", score= " + Score;
        }
    }
}
