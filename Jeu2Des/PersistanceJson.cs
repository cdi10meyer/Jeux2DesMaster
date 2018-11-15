using PackageClassement;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;


namespace PackagePersistant
{
    public class PersistanceJson<T> : IPersistant<T>
    {
        
        #region "Constructeurs"
        internal PersistanceJson()
        {

        }
        #endregion "Constructeurs"

        #region "Méthodes d'interface"
        public T Load()
        {
            Stream fichier = File.OpenRead("savJson.json");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            Object obj = serializer.ReadObject(fichier);
            fichier.Close();
            return (T)obj;
        }

        public void Save(T t)
        {
            File.Delete("savBinaire.txt");
            File.Delete("savXml.txt");

            Stream fichier = File.Create("savJson.json");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(t.GetType());
            serializer.WriteObject(fichier, t);
            fichier.Close();
        }

        #endregion "Méthodes d'interface" 

    }
}

