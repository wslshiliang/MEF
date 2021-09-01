using EntityModel.Sys;
using DAL.Sys;
using DB;
using System.Linq;

namespace BLL.Sys
{
    [System.ComponentModel.Composition.Export(typeof(IDictionary))]
    public class DictionaryBLL : BaseDal<DictionaryModel>, IDictionary
    {
        public dynamic GetDictEx(string secType, bool isUsed = true)
        {
           var res= Context.DictionaryDb.Where(c => c.SecType == secType && c.IsUsed == isUsed).Select(c => new
            {
                c.CategoryName,
                c.CategoryCode,
                c.Value,
                c.ValueType
            }).ToList();
            return Ret<dynamic>.Success(res);
        }

        public dynamic GetDictionaryAllEx()
        {
            var res = Context.DictionaryDb.Select(c => new
            {
                c.Id,
                c.Code,
                c.Name,
                c.SecType,
                c.SecName,
                c.CategoryCode,
                c.CategoryName,
                c.Value,
                c.IsUsed
            }).ToList();
           
            return Ret<dynamic>.Success(new
            {
                list = res,
                page =new { total_count = 5}
            });
        }
    }
}
