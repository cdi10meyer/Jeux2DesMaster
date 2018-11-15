using PackageClassement;
using System;
using System.IO;
using System.Xml.Serialization;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace PackagePersistant
{
    public class PersistanceXml<T> : IPersistant<T>
    {

        #region "Constructeurs"
        internal PersistanceXml()
        {

        }

        #endregion "Constructeurs"

        #region "Méthodes d'interface"
        public T Load()
        {
            Stream fichier = File.OpenRead("savXml.txt");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            Object obj = serializer.Deserialize(fichier);
            fichier.Close();
            return (T)obj;
        }

        public void Save(T t)
        {
            File.Delete("savBinaire.txt");
            File.Delete("savJson.json");
            Stream fichier = File.Create("savXml.txt");
            XmlSerializer serializer = new XmlSerializer(t.GetType());
            serializer.Serialize(fichier, t);
            fichier.Close();
        }

        #endregion "Méthodes d'interface" 
    }
}
