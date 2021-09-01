using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Sys
{
    public interface IDictionary : IBase
    {
        dynamic GetDictEx(string secType, bool isUsed =true);

        dynamic GetDictionaryAllEx();
    }
}
