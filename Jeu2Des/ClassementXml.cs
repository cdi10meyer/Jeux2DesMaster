using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PackageClassement
{
    [Serializable]
    public class ClassementXml : Classement
    {
        internal static bool ChoixXml;

        internal ClassementXml() : base()
        {

        }
        internal ClassementXml(List<Entree> entrees):base(entrees)
        {

        }
        internal void Save()
        {
            File.Delete("savBinaire.txt");
            File.Delete("savXml.txt");
            File.Delete("savJson.json");
            Stream fichier = File.Create("savXml.txt");
            XmlSerializer serializer = new XmlSerializer(typeof(ClassementXml));
            serializer.Serialize(fichier, this);
            fichier.Close();
            ChoixXml = true;
        }
        public override Classement Load()
        {
            Stream fichier = File.OpenRead("savXml.txt");
            XmlSerializer serializer = new XmlSerializer(typeof(ClassementXml));
            Object obj = serializer.Deserialize(fichier);
            fichier.Close();
            return (Classement)obj;
        }
    }
}
