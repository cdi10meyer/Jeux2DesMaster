using PackagePersistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Xml.Serialization;

namespace PackageClassement
{
    [Serializable]
    [DataContract]
    public class Classement
    {
        #region "Propriétés d'instance"
        [DataMember]
        public List<Entree> Entrees { get; private set; }

        //public IPersistant MyProperty { get; set; }
        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        internal Classement()
        {
            Entrees = new List<Entree>();
        }
        internal Classement(List<Entree> entrees)
        {
            Entrees = entrees;
        }
        #endregion "Constructeurs"

        #region "Méthodes propres à la classe"
        internal void AjouterEntree(Entree entree)
        {
            Entrees.Add(entree);
        }
        internal void TopN(int n)
        {
            int nbLigne = n > Entrees.Count ? Entrees.Count : n;
            Console.WriteLine(Environment.NewLine + $"TOP{nbLigne}");

            if (nbLigne > 0)
            {
                this.Entrees.Sort();
                for (int i = 0; i < nbLigne; i++)
                {
                    Console.WriteLine($"N°{i + 1} : {Entrees[i]}");
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
        public static void Delete()
        {
            StaticChoixPersistance.Delete();
        }
        internal void Save(string choix)
        {
            StaticChoixPersistance.Save(choix, this);
        }
        public virtual Classement Load()
        {
            return StaticChoixPersistance.Load();
        }
        #endregion "Méthodes propres à la classe"

    }
}