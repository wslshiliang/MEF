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

        dynamic AddDictionaryEx(string uName, dynamic args);

        dynamic GetDictionaryByIdEx(string id);

        dynamic ChangeDictionaryEx(string uName, dynamic args);

        dynamic DeleteDictionaryEx(string uName, string id);
    }
}
