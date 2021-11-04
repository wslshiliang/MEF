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
            var list = Context.DictionaryDb.Where(c => c.Code == secType && c.IsUsed == isUsed)
                .GroupBy(c=>new { c.SecName ,c.SecType,c.ValueType}).Select(c => new
            {
                    CategoryName = c.Key.SecName,
                    CategoryCode = c.Key.SecType 
                }).ToList();
          
            if (list.Count>0) return Ret<dynamic>.Success(list);//字典管理查字典编码的值
           var res = Context.DictionaryDb.Where(c => c.SecType == secType && c.IsUsed == isUsed).Select(c => new
            {
                c.CategoryName,
                c.CategoryCode,
                c.Value,
                c.ValueType
            }).ToList();
            return Ret<dynamic>.Success(res);
        }

        public dynamic GetDictionaryAllEx(dynamic args)
        {
            string categoryCode = args.model.CategoryCode;
            string code = args.model.Code;
            string secType = args.model.SecType;
            string isUsed = args.model.IsUsed;
            int page = args.page.Page;
            int pagesize= args.page.Pagesize;

            var sPage = (page - 1) * pagesize;
            var tPage = page * pagesize;
            bool used = true;
            if (isUsed != "-1" && isUsed != null) used = isUsed == "1" ? true : false;

            var linq = from c in Context.DictionaryDb
                     where (string.IsNullOrEmpty(categoryCode)==true ? true : c.CategoryCode.Contains(categoryCode))
                      && (string.IsNullOrEmpty(code) == true ? true : c.Code==code)
                      && (string.IsNullOrEmpty(secType) == true ? true : c.SecType==secType)
                     && ((isUsed == "-1" || isUsed == null) ? true : c.IsUsed == used)
                     select new
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
            } ;

            var res = linq.AsEnumerable().OrderBy(c => c.Id).Skip(sPage).Take(tPage).ToList();
            var total = linq.Count();


            return Ret<dynamic>.Success(new
            {
                list = res,
                page =new { total_count = total }
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
            var res = Context.DictionaryDb.Select(x=> new { 
            x.Id,
            x.Code,
            x.Name,
            x.SecType,
            x.SecName,
            x.CategoryCode,
            x.CategoryName,
            x.NamePy,
            x.Value,
            x.ValueType,
            x.LoaDlev,
            x.SysType,
            IsUsed=x.IsUsed?1:0,
            x.Remark 
            }).FirstOrDefault(c => c.Id == iid);
            return Ret<dynamic>.Success(res);
        }

        public dynamic ChangeDictionaryEx(string uName, dynamic args)
        {
            int id = Convert.ToInt32(args.Id);
            var model = Context.DictionaryDb.FirstOrDefault(c => c.Id == id);
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

            model.ModifyDictionaryModel(code, name, namePy, sysType, loaDlev, secType, secName, categoryName, categoryCode, value, loadIdx, vType, name, remark);
            base.Update(model);
            int res = Context.SaveChanges();
            if (res > 0)
            {
                return Ret.Success();
            }
            else
            {
                return Ret.Error(-1, "数据操作失败");
            }
        }

        public dynamic DeleteDictionaryEx(string uName, string id)
        {
            int iid = Convert.ToInt32(id);
            var model = Context.DictionaryDb.FirstOrDefault(c => c.Id == iid);
            base.Remove(model);
            int res = Context.SaveChanges();
            if (res > 0)
            {
                return Ret.Success(); 
            }
            else
            {
                return Ret.Error(-1, "数据删除失败");
            }
        }
    }
}
