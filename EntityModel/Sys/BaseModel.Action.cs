using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public partial class BaseModel
    {
        public BaseModel() { }
        public BaseModel(string crtUser, string remark = "")
        {
            IsUsed = true;
            CrtTime = DateTime.Now;
            CrtUser = crtUser;
            this.Remark = remark;
        }

        public void UpdateUser_Time(string edtUser)
        {
            EdtTime = DateTime.Now;
            EdtUser = edtUser;
        }

        public void SetIsUsed(bool isUsed, string edtUser)
        {
            this.IsUsed = isUsed;
            UpdateUser_Time(edtUser);
        }

        public void ChangeRemark(string remark, string edtUser)
        {
            this.Remark = remark;
            UpdateUser_Time(edtUser);
        }
    }
}
