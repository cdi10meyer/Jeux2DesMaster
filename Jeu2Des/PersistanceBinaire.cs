using PackageClassement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace PackagePersistant
{
    public class PersistanceBinaire<T> : IPersistant<T>
    {

        #region "Constructeurs"
        internal PersistanceBinaire()
        {

        }

        #endregion "Constructeurs"

        #region "Méthodes d'interface"

        public void Save(T t)
        {
            File.Delete("savXml.txt");
            File.Delete("savJson.json");

            Stream fichier = File.Create("savBinaire.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fichier, t);
            fichier.Close();
        }

        public T Load()
        {
            Stream fichier = File.OpenRead("savBinaire.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            Object obj = serializer.Deserialize(fichier);
            fichier.Close();
            return (T)obj;
        }
        #endregion "Méthodes d'interface" 

    }
}


