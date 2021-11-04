using DAL.Sys;
using DB;
using EntityModel.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Sys
{
    [System.ComponentModel.Composition.Export(typeof(IRoleModule))]
    public class RoleModuleBLL : BaseDal<RoleModuleModel>, IRoleModule
    {
        public void RemoveRoleModuleData(List<RoleModuleModel> list)
        {
            foreach (RoleModuleModel item in list)
            {
                base.Remove(item);
            } 
        }

        public void AddRoleModuleData(int[] ids,int rId,string uName)
        {
            List<int> pIds = new List<int>();
           // ids还要去重
            for (int i = 0; i < ids.Length; i++)
            {
                int iids = ids[i];
                var rmd = Context.Module.FirstOrDefault(c => c.Id == iids);

                if (rmd != null && rmd.ParentId == null)
                {
                    RoleModuleModel model = new RoleModuleModel(rId, rmd.Id, uName);
                    base.Add(model);
                    pIds.Add(rmd.Id);
                }
                else if (rmd != null && !pIds.Contains((int)rmd.ParentId))
                {
                    int pId= (int)rmd.ParentId;
                    RoleModuleModel model = new RoleModuleModel(rId, pId, uName);
                    base.Add(model);
                    model = new RoleModuleModel(rId, rmd.Id, uName);
                    base.Add(model);
                    pIds.Add(pId);
                }
                else
                {
                    RoleModuleModel model = new RoleModuleModel(rId, ids[i], uName);
                    base.Add(model);
                }
            } 
        }
    }
}
