using PackageClassement;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;


namespace PackagePersistant
{
    public class PersistanceJson : IPersistant
    {

        #region "Propriétés propre à la classe"

        internal static bool ChoixJson;

        #endregion "Propriétés propre à la classe"

        #region "Constructeurs"
        internal PersistanceJson()
        {

        }
        #endregion "Constructeurs"

        #region "Méthodes d'interface"
        public Classement Load()
        {
            Stream fichier = File.OpenRead("savJson.json");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Classement));
            Object obj = serializer.ReadObject(fichier);
            fichier.Close();
            return (Classement)obj;
        }

        public void Save(Classement classement)
        {
            File.Delete("savBinaire.txt");
            File.Delete("savXml.txt");

            Stream fichier = File.Create("savJson.json");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(classement.GetType());
            serializer.WriteObject(fichier, classement);
            fichier.Close();
            ChoixJson = true;
        }

        #endregion "Méthodes d'interface" 

    }
}

