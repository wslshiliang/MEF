using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
  public partial class RoleModuleModel:BaseModel
    {
        public RoleModuleModel() : base() { }

        public RoleModuleModel(int roleId,int moduleId,string uName)
        {
            this.RoleId = roleId;
            this.ModuleId = moduleId;
            this.IsUsed = true;
            this.CrtTime = DateTime.Now;
            this.CrtUser = uName;
        }

    }
}
