using DAL.Sys;
using DB;
using EntityModel.Sys;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Sys
{
    [System.ComponentModel.Composition.Export(typeof(IRole))]
    public class RoleBLL : BaseDal<RoleModel>, IRole
    {
        public dynamic AddRoleEx(dynamic args)
        {
            int[] rIds = new int[] { };
            string name = args.Name;
            string uName = args.uName;
            string remark = args.Remark;
            bool isUsed = args.IsUsed;
            var role=Context.Role.FirstOrDefault(c => c.Name == name);
            if(role!=null) return Ret.Error(-1, "已存在相同的角色名称");
 
                string roleModus = JsonConvert.SerializeObject(args.RoleModules);
                if (!string.IsNullOrWhiteSpace(roleModus) && roleModus.IndexOf("[") < 0)
                {
                    roleModus = roleModus.Replace('"', ' ');
                    string[] strIds = roleModus.Split(',');
                    rIds = Array.ConvertAll(strIds, int.Parse);
                }
         

            RoleModel roleModel = new RoleModel(name,isUsed,uName,remark);
            base.Add(roleModel);
            var res = base.Commit();
            if (res > 0 && rIds.Count() > 0)
            { 
                    role = Context.Role.FirstOrDefault(c => c.Name == name);

                    RoleModuleBLL roleModuleBLL = new RoleModuleBLL();
                    roleModuleBLL.AddRoleModuleData(rIds, role.Id, uName); 
                    res = base.Commit();  
            }

            if (res > 0) return Ret.Success();
            else return Ret.Error(-1, "保存数据失败");
        }

        public dynamic DeleteRoleEx(dynamic args)
        {
            int id = args.Id;
            string uName = args.uName;
            var role = Context.Role.FirstOrDefault(c => c.Id == id);
            role.SetIsUsed(false, uName);

            var res = base.Commit();
            if (res > 0) return Ret.Success();
            else return Ret.Error(-1, "删除数据失败");
        }

        public dynamic QueryAllRoleEx(dynamic args)
        {
            string name = args.model.Name;
            string secType = args.model.SecType;
            if (secType == "user_role")
            {
                var linq = from a in Context.Role
                           select new
                           {
                               a.Id,
                               a.Name,
                               a.Remark,
                               a.IsUsed,
                               a.CrtUser,
                               a.CrtTime,
                               a.EdtUser,
                               a.EdtTime,
                           };

                var res = linq.AsEnumerable().OrderBy(c => c.Id).ToList();
                var total = linq.Count();

                return Ret<dynamic>.Success(new
                {
                    list = res,
                    page = new { total_count = total }
                });
            }
            else
            {
                string isUsed = args.model.IsUsed;
                int page = args.page.Page;
                int pagesize = args.page.Pagesize;

                var sPage = (page - 1) * pagesize;
                var tPage = page * pagesize;
                bool used = true;
                if (isUsed != "-1" && isUsed != null) used = isUsed == "1" ? true : false;

                var linq = from a in Context.Role
                           where (string.IsNullOrEmpty(name) == true ? true : a.Name.Contains(name))
                           && ((isUsed == "-1" || isUsed == null) ? true : a.IsUsed == used)
                           select new
                           {
                               a.Id,
                               a.Name,
                               a.Remark,
                               a.IsUsed,
                               a.CrtUser,
                               a.CrtTime,
                               a.EdtUser,
                               a.EdtTime,
                           };

                var res = linq.AsEnumerable().OrderBy(c => c.Id).Skip(sPage).Take(tPage).ToList();
                var total = linq.Count();

                return Ret<dynamic>.Success(new
                {
                    list = res,
                    page = new { total_count = total }
                });
            }
        }

        public dynamic QueryRoleByIdEx(dynamic args)
        {
            int id = args.Id;

            var linq = (from a in Context.Role.Where(c => c.Id == id)
                        select new
                        {
                            a.Id,
                            a.Name,
                            a.Remark,
                            RoleModules = a.RoleModules.Where(c => c.RoleId == a.Id && c.Module.ParentId!=null).Select(c => c.ModuleId).ToList()
                        }).FirstOrDefault();
            return Ret<dynamic>.Success(linq);
        }

        public dynamic UpdateRoleEx(dynamic args)
        {
            int[] rIds = new int[] { };
            int id = args.Id;
            string name = args.Name;
            string uName = args.uName;
            string remark = args.Remark;
            bool isUsed = args.IsUsed;
            string roleModus =JsonConvert.SerializeObject( args.RoleModules);

            if (!string.IsNullOrWhiteSpace(roleModus) && roleModus!= "\"\"")
            {
                if (roleModus.IndexOf("[") < 0)
                {
                    roleModus = roleModus.Replace('"', ' ');
                    string[] strIds = roleModus.Split(',');
                    rIds = Array.ConvertAll(strIds, int.Parse);
                }
                else
                {
                    JArray jArray = JArray.Parse(roleModus);
                    rIds = (int[])jArray.ToObject(typeof(int[]));
                }
            }

           var rmList= Context.RoleModule.Where(c => c.RoleId == id).ToList();

                RoleModuleBLL roleModuleBLL = new RoleModuleBLL();
                roleModuleBLL.RemoveRoleModuleData(rmList);
            if (rIds.Count() > 0)
            {
                roleModuleBLL.AddRoleModuleData(rIds, id, uName);
            }

            var role = Context.Role.FirstOrDefault(c => c.Id == id);
            role.UpdateRoleModel(name, uName, remark, isUsed);
            base.Update(role);

            var res = base.Commit();
            if (res > 0) return Ret.Success();
            else return Ret.Error(-1, "保存数据失败");
        }
    }
}
