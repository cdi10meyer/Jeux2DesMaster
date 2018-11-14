using PackageClassement;
using System;
using System.IO;
using System.Xml.Serialization;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace PackagePersistant
{
    public class PersistanceXml : IPersistant
    {
        #region "Propriétés propre à la classe"

        internal static bool ChoixXml;

        #endregion "Propriétés propre à la classe"

        #region "Constructeurs"
        internal PersistanceXml()
        {

        }

        #endregion "Constructeurs"

        #region "Méthodes d'interface"
        public Classement Load()
        {
            Stream fichier = File.OpenRead("savXml.txt");
            XmlSerializer serializer = new XmlSerializer(typeof(Classement));
            Object obj = serializer.Deserialize(fichier);
            fichier.Close();
            return (Classement)obj;
        }

        public void Save(Classement classement)
        {
            File.Delete("savBinaire.txt");
            File.Delete("savJson.json");
            Stream fichier = File.Create("savXml.txt");
            XmlSerializer serializer = new XmlSerializer(classement.GetType());
            serializer.Serialize(fichier, classement);
            fichier.Close();
            ChoixXml = true;
        }

        #endregion "Méthodes d'interface" 
    }
}
