using PackageClassement;
using System.IO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace PackagePersistant
{
    public static class StaticChoixPersistance<T>
    {
        private static PersistanceXml<T> newXml = new PersistanceXml<T>();
        private static PersistanceJson<T> newJson = new PersistanceJson<T>();
        private static PersistanceBinaire<T> newBinaire = new PersistanceBinaire<T>();

        #region "Méthodes static"

        internal static IPersistant<T> CreatePersistanceForLoad()
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

        internal static IPersistant<T> CreatePersistanceForSave(TypesPersistances type)
        {
            if (type == TypesPersistances.Xml)
            {
                return newXml;
                
            }
            else if (type==TypesPersistances.Json)
            {
                return newJson;
                
            }
            else
            {
                return newBinaire;
                
            }
        }
        
        public static void Delete()
        {
            File.Delete("savXml.txt");
            File.Delete("savBinaire.txt");
            File.Delete("savJson.json");
        }
        #endregion "Méthodes static"
    }
}
