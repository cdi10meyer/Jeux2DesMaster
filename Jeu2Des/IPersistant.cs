//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using PackageClassement;

namespace PackagePersistant
{
    interface IPersistant
    {
        void Save(Classement classement);
        Classement Load();
    }
}
