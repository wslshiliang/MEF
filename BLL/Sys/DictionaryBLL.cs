using EntityModel.Sys;
using DAL.Sys;
using DB;
using System.Linq;
using System;
using Enums;

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


        public dynamic AddDictionaryEx(string uName, dynamic args)
        {
            string name = args.Name;
            string namePy = args.NamePy;
            string sysType = args.SysType;
            int loaDlev = Convert.ToInt32(args.LoaDlev);
            string secType = args.SecType;
            string secName = args.SecName;
            string categoryName = args.CategoryName;
            string categoryCode = args.CategoryCode;
            int value = Convert.ToInt32(args.Value);
            int loadIdx = Convert.ToInt32(args.LoadIdx);
            string remark = args.Remark;
            string code = args.Code;
            int valueType = args.ValueType;
            E_ValueType vType = (E_ValueType)valueType;

            DictionaryModel model = new DictionaryModel(code, name, namePy, sysType, loaDlev, secType, secName, categoryName, categoryCode, value, loadIdx, vType, name,remark);
            base.Add(model);
            var res = base.Commit();
            if (res > 0) return Ret.Success();
            else return Ret.Error(-1, "添加数据失败");
        }

        public dynamic GetDictionaryByIdEx(string id)
        {
            int iid = Convert.ToInt32(id);
            var res = Context.DictionaryDb.FirstOrDefault(c => c.Id == iid);
            return Ret<dynamic>.Success(res);
        }

        public dynamic ChangeDictionaryEx(string uName, dynamic args)
        {
            throw new System.NotImplementedException();
        }

        public dynamic DeleteDictionaryEx(string uName, string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
