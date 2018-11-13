using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{
    [Serializable]
    public class Entree : IComparable<Entree>
    {
        private string _Nom;
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        private int _Score = 0;
        
        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
        }
        internal Entree(string nom, int score)
        {
            _Nom = nom;
            _Score = score;
        }
        internal Entree():this(null,0)
        {
        }

        public int CompareTo(Entree other)
        {
            if (this.Score.CompareTo(other.Score) == 0)
            {
                return this.Nom.CompareTo(other.Nom);
            }
            else
            {
                return this.Score.CompareTo(other.Score)*-1;
            }
            
        }

        public override string ToString()
        {
            return $"{_Nom} - {_Score}";
        }
    }
}
