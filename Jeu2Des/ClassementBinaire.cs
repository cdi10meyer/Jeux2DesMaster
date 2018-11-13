using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Jeu2Des
{
    [Serializable]
    public class ClassementBinaire : Classement
    {
        internal static bool ChoixBinaire;

        internal ClassementBinaire() : base()
        {

        }
        internal ClassementBinaire(List<Entree> entrees) : base(entrees)
        {

        }

        internal void Save()
        {
            File.Delete("savBinaire.txt");
            File.Delete("savXml.txt");
            File.Delete("savJson.json");

            Stream fichier = File.Create("savBinaire.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fichier, this);
            fichier.Close();
            ChoixBinaire = true;
        }
        public override Classement Load()
        {
            Stream fichier = File.OpenRead("savBinaire.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            Object obj = serializer.Deserialize(fichier);
            fichier.Close();
            return (Classement)obj;
        }
    }
}
