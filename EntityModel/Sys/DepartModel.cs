using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public partial class DepartModel:BaseModel
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string Leader { get; private set; }
         
        public int? ParentDepartId { get; private set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual ICollection<UserModel> Users { get; private set; } = new List<UserModel>();
        public virtual ICollection<RoleModel> Roles { get; private set; } = new List<RoleModel>(); 
    }
}
