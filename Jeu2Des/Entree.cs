using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{
    public class Entree : IComparable<Entree>
    {
        private string _Nom;
        public string Nom
        {
            get { return _Nom; }
            internal set { _Nom = value; }
        }

        private int _Score = 0;
        
        public int Score
        {
            get { return _Score; }
            internal set { _Score = value; }
        }
        internal Entree(string nom, int score)
        {
            _Nom = nom;
            _Score = score;
        }

        public int CompareTo(Entree other)
        {
            return this.Score.CompareTo(other.Score);
        }

        public override string ToString()
        {
            return $"{_Nom} - {_Score}";
        }
    }
}
