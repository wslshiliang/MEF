using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public partial class RoleModel:BaseModel
    {
        public RoleModel() : base() { }

        public RoleModel(string name,bool isUsed,string crtUser, string remark):base(crtUser,remark)
        {
            this.Name = name;
            this.IsUsed = isUsed;
        }
        public void UpdateRoleModel(string name, string uName, string remark,bool isUsed)
        {
            this.Name = name;
            this.ChangeRemark(remark, uName);
            this.SetIsUsed(IsUsed, uName);
        }

    }
}
