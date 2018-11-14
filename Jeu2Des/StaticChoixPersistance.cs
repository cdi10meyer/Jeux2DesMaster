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
        private static PersistanceXml newXml = new PersistanceXml();
        private static PersistanceJson newJson = new PersistanceJson();
        private static PersistanceBinaire newBinaire = new PersistanceBinaire();

        #region "Méthodes static"

        internal static IPersistant CreatePersistance()
        {
            if (File.Exists("savXml.txt"))
            {
                return newXml;
            }
            else if (File.Exists("savJson.json"))
            {
                return newJson;
            }
            else if (File.Exists("savBinaire.txt"))
            {
                return newBinaire;
            }
            return newBinaire;
        }

        internal static void CreatePersistance(string choix, Classement classement)
        {
            if (choix == "X")
            {
                newXml.Save(classement);
                PersistanceXml.ChoixXml = true;
            }
            else if (choix == "J")
            {
                newJson.Save(classement);
                PersistanceJson.ChoixJson = true;
            }
            else
            {
                newBinaire.Save(classement);
                PersistanceBinaire.ChoixBinaire = true;
            }
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
