using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public partial class DepartModel:BaseModel
    {
        public DepartModel() : base() { }

        public DepartModel(string name, string learder, string userName, string remark = "") : base(userName, remark)
        {
            this.Name = name;
            this.Leader = learder;
        }

        public void UpdateModel(string name, string learder, bool isUsed, string userName, string remark = "") 
        {
            this.Name = name;
            this.Leader = learder;
            this.SetIsUsed(isUsed, userName);
            base.ChangeRemark(remark,userName);
        }
    }
}
