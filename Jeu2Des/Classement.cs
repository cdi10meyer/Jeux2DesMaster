using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Jeu2Des
{
    [Serializable]
    public class Classement
    {
        public List<Entree> Entrees { get; private set; }

        internal Classement()
        {
            Entrees = new List<Entree>();
        }
        internal Classement(List<Entree> entrees)
        {
            Entrees = entrees;
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
                for(int i = 0; i< nbLigne;i++)
                {
                    Console.WriteLine($"N°{i+1} : {Entrees[i]}");
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
        internal void Save(string choix)
        {
            FabriqueClassement fabrique = new FabriqueClassement();
            if(choix=="X")
            {
                ClassementXml newXml = fabrique.CreateClassementXml(this);
                newXml.Save();
                ClassementXml.ChoixXml = true;
            }
            else if(choix=="J")
            {
                ClassementJson newXml = fabrique.CreateClassementJson(this);
                newXml.Save();
                ClassementJson.ChoixJson = true;
            }
            else
            {
                ClassementBinaire newBinaire = fabrique.CreateClassementBinaire(this);
                newBinaire.Save();
                ClassementBinaire.ChoixBinaire = true;
            }
        }
        public virtual Classement Load()
        {
            if(File.Exists("savXml.txt"))
            {
                ClassementXml newXml = new ClassementXml();
                return newXml.Load();
            }
            else if (File.Exists("savBinaire.txt"))
            {
                ClassementBinaire newBinaire = new ClassementBinaire();
                return newBinaire.Load();
            }
            else if (File.Exists("savJson.json"))
            {
                ClassementJson newJson = new ClassementJson();
                return newJson.Load();
            }
            return new Classement();
        }
    }
}
