using PackageClassement;
using System.IO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace PackagePersistant
{
    public static class StaticChoixPersistance
    {
        #region "Méthodes static"
        internal static void Save(string choix, Classement classement)
        {
            if (choix == "X")
            {
                PersistanceXml newXml = new PersistanceXml();
                newXml.Save(classement);
                PersistanceXml.ChoixXml = true;
            }
            else if (choix == "J")
            {
                PersistanceJson newXml = new PersistanceJson();
                newXml.Save(classement);
                PersistanceJson.ChoixJson = true;
            }
            else
            {
                PersistanceBinaire newBinaire = new PersistanceBinaire();
                newBinaire.Save(classement);
                PersistanceBinaire.ChoixBinaire = true;
            }
        }

        internal static Classement Load()
        {
            if (File.Exists("savXml.txt"))
            {
                PersistanceXml newXml = new PersistanceXml();
                return newXml.Load();
            }
            else if (File.Exists("savBinaire.txt"))
            {
                PersistanceBinaire newBinaire = new PersistanceBinaire();
                return newBinaire.Load();
            }
            else if (File.Exists("savJson.json"))
            {
                PersistanceJson newJson = new PersistanceJson();
                return newJson.Load();
            }
            return new Classement();
        }
        public static void Delete()
        {
            File.Delete("savXml.txt");
            File.Delete("savBinaire.txt");
            File.Delete("savJson.json");
            PersistanceBinaire.ChoixBinaire = false;
            PersistanceXml.ChoixXml = false;
            PersistanceJson.ChoixJson = false;
        }
        #endregion "Méthodes static"
    }
}
