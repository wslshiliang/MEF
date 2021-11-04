using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public partial class RoleModel:BaseModel
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; private set; }

        public Nullable<int> roleDepId { get; set; }

        public virtual DepartModel Depart { get; set; }

        public virtual ICollection<RoleModuleModel> RoleModules { get; set; } = new List<RoleModuleModel>(); 
        public virtual ICollection<UserRoleModel> UserRole { get; set; } = new List<UserRoleModel>();
    }
}
