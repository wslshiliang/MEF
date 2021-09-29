﻿using DAL.Sys;
using DB;
using EntityModel.Sys;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Sys
{
    [System.ComponentModel.Composition.Export(typeof(IModule))]
    public class ModuleBLL : BaseDal<ModuleModel>, IModule
    {
        public dynamic AddModuleEx(string uName, dynamic args)
        {
            string name = args.Name;
            bool isUsed = args.IsUsed;
            string idx = args.Idx;
            string icon = args.Icon;
            E_ModuleType moduleType = args.ModuleType;
            int? parentId = args.ParentId == 0 ? null : args.ParentId;
            bool routeCache = args.RouteCache;
            string routeComponent = args.RouteComponent;
            string routeName = args.RouteName;
            string routePath = args.RoutePath;
            string targetType = args.TargetType;
            string url = args.Url;
            string remark = args.Remark;
            string crtUser= args.uName;
             
            ModuleModel module = new ModuleModel(name, isUsed, idx, icon, moduleType, parentId, routeCache, routeComponent, routeName, routePath, targetType, url, crtUser, remark);
            base.Add(module);
            var res = base.Commit();
            if (res > 0) return Ret.Success();
            else return Ret.Error(-1, "添加数据失败");
        }

        public dynamic QueryAllModuleEx(string name, string isUsed, int page, int pagesize)
        {
            var sPage = (page - 1) * pagesize;
            var tPage = page * pagesize;
            bool used = true;
            if (isUsed != "-1" && isUsed != null) used = isUsed == "1" ? true : false;

            var linq = from c in Context.Module
                        where (string.IsNullOrEmpty(name) ? true : c.Name.Contains(name))
                        && (isUsed == "-1" || isUsed == null) ? true : c.IsUsed == used
                        select c;
            var list = linq.AsEnumerable().OrderBy(c => c.Id).Skip(sPage).Take(tPage).ToList();

            var res = GetModuleData(list, null);



            var total = (from c in Context.Module
                         where (string.IsNullOrEmpty(name) ? true : c.Name.Contains(name))
                         && string.IsNullOrEmpty(isUsed) ? true : c.IsUsed == used
                         select c.Id).Count();

            return Ret<dynamic>.Success(new
            {
                list = res,
                page = new { total_count = total }
            }); 
        }

      List<ModuleDto> GetModuleData(List<ModuleModel> list,int? id)
        {
           var res= list.Where(c => c.ParentId == id).ToList();
            List<ModuleDto> modules = new List<ModuleDto>();
            foreach (var item in res)
            {
                ModuleDto moduleDto = new ModuleDto();
                moduleDto.Id = item.Id;
                moduleDto.Name = item.Name;
                moduleDto.IsUsed = item.IsUsed ? 1 : 0;
                moduleDto.Idx = item.Idx;
                moduleDto.Icon = item.Icon;
                moduleDto.ModuleType = item.ModuleType;
                moduleDto.ParentId = item.ParentId;
                moduleDto.RouteCache = item.RouteCache;
                moduleDto.RouteComponent = item.RouteComponent;
                moduleDto.RouteName = item.RouteName;
                moduleDto.RoutePath = item.RoutePath;
                moduleDto.TargetType = item.TargetType;
                moduleDto.Url = item.Url;
                moduleDto.CrtTime = item.CrtTime;
                moduleDto.CrtUser = item.CrtUser;
                moduleDto.EdtTime = item.EdtTime;
                moduleDto.EdtUser = item.EdtUser;
                moduleDto.Remark = item.Remark;
                moduleDto.children_list = null;
                modules.Add(moduleDto);
            }
            return modules;
        }
        List<ModuleDto> GetChildList(List<ModuleModel> list,ModuleDto moduleDto)
        {
            if (!list.Exists(x => x.ParentId == moduleDto.Id))
            {
                return null;
            }
            else
            {
                return GetModuleData( list, moduleDto.Id);
            }
        }


    }






    public class ModuleDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int IsUsed { get; set; }
        public string Idx { get; set; }
        public string Icon { get; set; }
        public Enums.E_ModuleType ModuleType { get; set; }
        public int? ParentId { get; set; }
        public bool RouteCache { get; set; }
        public string RouteComponent { get; set; }
        public string RouteName { get; set; }
        public string RoutePath { get; set; }
        public string TargetType { get; set; }
        public string Url { get; set; }
        public string CrtUser { get; set; }
        public DateTime CrtTime { get; set; }
        public string EdtUser { get; set; }
        public DateTime? EdtTime { get; set; }
        public string Remark { get; set; }

        public List<ModuleDto> children_list { get; set; }
    }
}
