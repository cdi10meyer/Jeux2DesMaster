using System.IO;
using PackageClassement;
using PackagePersistant;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace PackageJeu
{
    /// <summary>
    /// La classe Jeu2Des décrit un jeu de Dés très simple. 
    /// Le jeu comprend 2 dés et un classement pour enregistrer les scores des joueur
    /// Quand un joueur fait une partie : il indique son nom puis il lance les 2 dés 10 fois de suite
    /// A chaque lancer, si le total des dés est égal à 7 ==> le joueur marque 10 points à son score
    /// Une fois la partie terminée le nom du jouer et son score sont enregistrés dans le classement 
    /// </summary>   
    public class Jeu
    {
        #region "Propriétés propre à la classe"
        private static bool _Sauvegarde = File.Exists("savXml.txt") || File.Exists("savBinaire.txt") || File.Exists("savJson.json");
        public static bool Sauvegarde
        {
            get { return _Sauvegarde; }
            private set { _Sauvegarde = value; }
        }
        #endregion "Propriétés propre à la classe"

        #region "Propriétés d'instance"
        private Joueur _Joueur;
        public Joueur Joueur
        {
            get { return _Joueur; }
        }

        private De[] _Des = new De[2];

        private Classement Classement;

        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        public Jeu() : this(false)
        {
        }

        public Jeu(bool load)
        {
            Classement = new Classement();
            _Des[0] = new De();
            _Des[1] = new De();
            if (load)
            {
                Classement = Classement.Load();
            }

        }
        #endregion "Constructeurs"

        #region "Méthodes propres à la classe"
        public void JouerPartie(string nom)
        {
            //Le joueur est créé quand la partie démarre
            _Joueur = new Joueur(nom);

            //On fait jouer le joueur en lui passant les 2 dés
            int resultat = _Joueur.Jouer(_Des);

            //On ajoute l'entree dans le classement
            Classement.AjouterEntree(_Joueur.Nom, resultat);

        }

        /// <summary>
        /// Permet de faire une partie du jeu de dés
        /// Le nom du joueur n'est pas donnée en entrée : il sera généré exemple : Joueur 1, Joueur 2, ...  
        /// </summary>    

        public void JouerPartie()
        {
            JouerPartie(null);

        }
        public void VoirResultat()
        {
            Classement.TopN();
        }

        public void VoirResultat(int nombreLigne)
        {
            Classement.TopN(nombreLigne);
        }

        public static void Delete(bool suppression)
        {
            if (suppression)
            {
                Classement.Delete();
                Sauvegarde = false;
            }
        }
        public static void Delete()
        {
            Delete(true);
        }
        public void TerminerJeu(bool sauvegarde, TypesPersistances type)
        {
            if (sauvegarde)
            {
                this.Classement.Save(type);
                Sauvegarde = true;
            }
        }

        public void TerminerJeu(TypesPersistances type)
        {
            TerminerJeu(true, type);
        }
        #endregion "Méthodes propres à la classe"
    }
}




