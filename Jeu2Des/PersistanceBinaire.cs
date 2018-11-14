using PackageClassement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace PackagePersistant
{
    public class PersistanceBinaire : IPersistant
    {

        #region "Propriétés propre à la classe"

        internal static bool ChoixBinaire;

        #endregion "Propriétés propre à la classe"

        #region "Constructeurs"
        internal PersistanceBinaire()
        {

        }

        #endregion "Constructeurs"

        #region "Méthodes d'interface"

        public void Save(Classement classement)
        {
            File.Delete("savXml.txt");
            File.Delete("savJson.json");

            Stream fichier = File.Create("savBinaire.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fichier, classement);
            fichier.Close();
            ChoixBinaire = true;
        }

        public Classement Load()
        {
            Stream fichier = File.OpenRead("savBinaire.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            Object obj = serializer.Deserialize(fichier);
            fichier.Close();
            return (Classement)obj;
        }
        #endregion "Méthodes d'interface" 

    }
}


