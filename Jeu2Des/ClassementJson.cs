using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Jeu2Des
{
    public class ClassementJson : Classement
    {
        internal static bool ChoixJson;
        internal ClassementJson()
        {
        }

        internal ClassementJson(List<Entree> entrees) : base(entrees)
        {
        }
        internal void Save()
        {
            File.Delete("savBinaire.txt");
            File.Delete("savXml.txt");
            File.Delete("savJson.json");

            Stream fichier = File.Create("savJson.json");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ClassementJson));
            serializer.WriteObject(fichier, this);
            fichier.Close();
            ChoixJson = true;
        }
        public override Classement Load()
        {
            Stream fichier = File.OpenRead("savJson.json");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ClassementXml));
            Object obj = serializer.ReadObject(fichier);
            fichier.Close();
            return (Classement)obj;

        }
    }
}
