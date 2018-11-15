//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using PackageClassement;

namespace PackagePersistant
{
    interface IPersistant<T>
    {
        void Save(T t);
        T Load();
    }
}
