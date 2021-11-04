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
                var list = Context.DepartDb.Select(c=>new DepartDto
                {
                    Id=c.Id,
                    ParentDepartId=c.ParentDepartId,
                    Name = c.Name,
                    IsUsed = c.IsUsed ? 1 : 0,
                    Leader = c.Leader,
                    CrtUser = c.CrtUser,
                    CrtTime = c.CrtTime,
                    EdtUser = c.EdtUser,
                    EdtTime = c.EdtTime,
                    Remark = c.Remark
                }).OrderBy(c => c.Id).ToList();
                var res = GetDepartTreeData(list, null);
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
                           select new DepartDto
                           {
                               Id = c.Id,
                               ParentDepartId = c.ParentDepartId,
                               Name = c.Name,
                               IsUsed = c.IsUsed ? 1 : 0,
                               Leader = c.Leader,
                               CrtUser = c.CrtUser,
                               CrtTime = c.CrtTime,
                               EdtUser = c.EdtUser,
                               EdtTime = c.EdtTime,
                               Remark = c.Remark
                           };
                var list = linq.AsEnumerable().OrderBy(c => c.Id).Skip(sPage).Take(tPage).ToList();
                var res = GetDepartTreeData(list, null);

                var total = linq.Count();

                return Ret<dynamic>.Success(new
                {
                    list = res,
                    page = new { total_count = total }
                });
            }
        }


        #region 角色tree
        List<DepartDto> GetDepartTreeData(List<DepartDto> list, int? id)
        {
            var res = list.Where(c => c.ParentDepartId == id).ToList();
            List<DepartDto> departList = new List<DepartDto>();
            foreach (var item in res)
            {
                DepartDto departDto = new DepartDto();
                departDto.Id = item.Id;
                departDto.ParentDepartId = item.ParentDepartId;
                departDto.Name = item.Name;
                departDto.IsUsed = item.IsUsed;
                departDto.Leader = item.Leader;
                departDto.CrtUser = item.CrtUser;
                departDto.CrtTime = item.CrtTime;
                departDto.EdtUser = item.EdtUser;
                departDto.EdtTime = item.EdtTime;
                departDto.Remark = item.Remark;
                departDto.children_list = GetDepartChildList(list, item);
                departList.Add(departDto);
            }
            return departList;
        }
        List<DepartDto> GetDepartChildList(List<DepartDto> list, DepartDto moduleDto)
        {
            if (!list.Exists(x => x.ParentDepartId == moduleDto.Id))
            {
                return null;
            }
            else
            {
                return GetDepartTreeData(list, moduleDto.Id);
            }
        } 
        #endregion

        public dynamic AddDepartEx(string uName, dynamic args)
        { 
            string name = args.Name;
            string parentDepartId = args.ParentDepartId;
            string leader = args.Leader; 
            string remark = args.Remark;
            int? pId=null;
            if (parentDepartId!="0") pId = Convert.ToInt32(parentDepartId);

            DepartModel model = new DepartModel(name,leader, pId, uName,remark); 
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


        public dynamic DeleteDepartEx(int id,string uName)
        { 
            var model = Context.DepartDb.FirstOrDefault(c=>c.Id==id);
            model.SetIsUsed(false, uName);
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
