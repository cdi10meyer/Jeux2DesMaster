using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{
     /// <summary>
     /// La classe De décrit le comportement d'un Dé à 6 faces
     /// Le De est lancé pour obtenir une valeur aléatoire comprise entre 1 et 6  
     ///</summary>
    public class De
    {
      //On crée des Des à 6 faces
      private const int _NB_FACES = 6;
      
      //Permet d'identifier chaque instance de De par un texte du type : De n°1, De n° 2, ...
      private string _Texte = "Dé n°";     
      private static int _Compteur  = 0;
      
      //L'objet Random est initialisé à partir d'une unité de temps
      //Il sera utilisé par le Dé à chaque lancer pour obtenir une valeur aléatoire
      private static Random rnd = new Random();

      private int _Valeur = 0;

      /// <summary>
      /// Valeur du Dé
      /// <list type="Bullet">
      /// <item>0 si le Dé n'a pas été lancé</item>
      /// <item>Un entier aléatoire entre 1 et 6 aprés le lancer du De</item>
      /// </list>
      /// </summary>
      /// <returns>Un entier</returns>
      public int Valeur
      {
          get { return _Valeur; }
          //Pas de set s€inon la valeur du Dé pourrait être changée sans le lancer
      }
        
      /// <summary>
      /// Construit un De : chaque Dé porte un texte qui permet de l'identifier De n°1, De n°2, ... 
      /// </summary>    
      public De()
      {
        //Constructeur par défaut : Le texte permet de différencier les dés
        _Compteur ++ ;
        _Texte = _Texte + _Compteur ;
      }

      /// <summary>
      /// Lance le De
      /// </summary>
      /// <returns>Une valeur entière aléatoire comprise entre 1 et 6 (bornes incluses)</returns>   
      public int Lancer() 
      {
        _Valeur = rnd.Next(1, _NB_FACES + 1);        
        return _Valeur;
      }

      /// <returns><see cref="T:System.String" /> Affiche un texte. Exemple : De n°1 = 4</returns>
      public override string ToString()
      {
        return _Texte + " = " + _Valeur;
      }

    }
}
