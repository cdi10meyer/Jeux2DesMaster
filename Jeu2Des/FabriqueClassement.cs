using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageClassement
{
    public class FabriqueClassement
    {
        internal ClassementXml CreateClassementXml(Classement classement)
        {
            ClassementXml newClassement = new ClassementXml(classement.Entrees);
            return newClassement;
        }
        internal ClassementBinaire CreateClassementBinaire(Classement classement)
        {
            ClassementBinaire newClassement = new ClassementBinaire(classement.Entrees);
            return newClassement;
        }
        internal ClassementJson CreateClassementJson(Classement classement)
        {
            ClassementJson newClassement = new ClassementJson(classement.Entrees);
            return newClassement;
        }
    }
}
