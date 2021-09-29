using DAL;
using DB;
using EntityModel.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace BLL.Sys
{
    [System.ComponentModel.Composition.Export(typeof(IDepartment))]
    public class DepartmentBLL : BaseDal<DepartModel>, IDepartment
    {
        public dynamic QueryAllDepart(string name, string isUsed, int page, int pagesize)
        {
            if (page ==0 && pagesize == 0)
            {
                var res = Context.DepartDb.Select(c=>new {
                    Id=c.Id,
                   // ParentDepartId=null,
                    Name = c.Name,
                    IsUsed = c.IsUsed ? 1 : 0,
                    Leader = c.Leader,
                    CrtUser = c.CrtUser,
                    CrtTime = c.CrtTime,
                    EdtUser = c.EdtUser,
                    EdtTime = c.EdtTime,
                    Remark = c.Remark,
                  //  children_list=null
                }).OrderBy(c => c.Id).ToList();
                return Ret<dynamic>.Success(res);
            }
            else
            {
                var sPage = (page - 1) * pagesize;
                var tPage = page * pagesize;
                bool used = true;
                if (isUsed != "-1" && isUsed != null) used = isUsed == "1" ? true : false;

                var linq = from c in Context.DepartDb
                           where (string.IsNullOrEmpty(name) ? true : c.Name.Contains(name))
                           && (isUsed == "-1" || isUsed == null) ? true : c.IsUsed == used
                           select new
                           {
                               c.Id,
                               c.Name,
                               IsUsed = c.IsUsed ? 1 : 0,
                               c.Leader,
                               c.CrtUser,
                               c.CrtTime,
                               c.EdtUser,
                               c.EdtTime,
                               c.Remark
                           };
                var res = linq.AsEnumerable().OrderBy(c => c.Id).Skip(sPage).Take(tPage).ToList();

                var total = (from c in Context.DepartDb
                             where (string.IsNullOrEmpty(name) ? true : c.Name.Contains(name))
                             && string.IsNullOrEmpty(isUsed) ? true : c.IsUsed == used
                             select c.Id).Count();

                return Ret<dynamic>.Success(new
                {
                    list = res,
                    page = new { total_count = total }
                });
            }
        }

        public dynamic AddDepartEx(string uName, dynamic args)
        { 
            string name = args.Name;
            string parentDepartId = args.ParentDepartId;
            string leader = args.Leader; 
            string remark = args.Remark;

            DepartModel model = new DepartModel(name,leader,uName,remark); 
            base.Add(model);
            var res = base.Commit();
            if (res > 0) return Ret.Success();
            else return Ret.Error(-1, "添加数据失败");
        }

        public dynamic QueryDepartByIdEx(int id)
        { 
            var model = Context.DepartDb.Where(c => c.Id == id).Select(c=>new { 
                 c.Id,
                 c.Name,
                 c.Leader,
                IsUsed=c.IsUsed?1:0,
                c.Remark
            }).FirstOrDefault();
            return Ret<dynamic>.Success(model);
        }

        public dynamic UpdateDepartEx(string uName,dynamic args)
        {
            int id = args.Id;
            string name = args.Name;
            string parentDepartId = args.ParentDepartId;
            string leader = args.Leader;
            bool isUsed = args.IsUsed;
            string remark = args.Remark;

            var model = Context.DepartDb.FirstOrDefault(c => c.Id == id);
            model.UpdateModel(name, leader, isUsed, uName, remark);
            base.Update(model);
            var res = base.Commit();
            if (res > 0) return Ret.Success();
            else return Ret.Error(-1, "修改数据失败");
        }


        public dynamic DeleteDepartEx(int id)
        {
            var model = Context.DepartDb.FirstOrDefault(c=>c.Id==id);
            base.Remove(model);
            var res = base.Commit();
            if (res > 0) return Ret.Success();
            else return Ret.Error(-1, "删除数据失败");
        }

    }


    public class DepartDto
    {
        public int Id { get; set; }
        public int? ParentDepartId { get; set; }
        public string Name { get; set; }
        public int IsUsed { get; set; }
        public string Leader { get; set; }
        public string CrtUser { get; set; }
        public DateTime CrtTime { get; set; }
        public string EdtUser { get; set; }
        public DateTime? EdtTime { get; set; }
        public string Remark { get; set; }

        public List<DepartDto> children_list { get; set; }
    }
}
