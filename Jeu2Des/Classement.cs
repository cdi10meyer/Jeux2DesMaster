using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{
    public class Classement
    {
        public List<Entree> Entrees { get; private set; }

        internal Classement()
        {
            Entrees = new List<Entree>();
        }

        internal void AjouterEntree(Entree entree)
        {
            Entrees.Add(entree);
        }

       
        internal void TopN(int n)
        {
            int nbLigne = n>Entrees.Count?Entrees.Count:n;
            Console.WriteLine(Environment.NewLine+$"TOP{nbLigne}");

            if (nbLigne > 0)
            {
                this.Entrees.Sort();
                this.Entrees.Reverse();
                for(int i = 0; i< nbLigne;i++)
                {
                    Console.WriteLine($"Place N°{i+1} : {Entrees[i]}");
                }
            }
            else
            {
                Console.WriteLine($"Rien à afficher");
            }
        }

        internal void TopN()
        {
            TopN(Entrees.Count());
        }
    }
}
