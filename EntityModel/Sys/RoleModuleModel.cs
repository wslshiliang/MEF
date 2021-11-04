using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
  public partial class RoleModuleModel:BaseModel
    {
        public int RoleId { get; private set; }
        public virtual RoleModel Role { get; private set; }

        public int ModuleId { get; private set; }
        public virtual ModuleModel Module { get; private set; }
    }
}
