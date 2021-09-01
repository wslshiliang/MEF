using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public partial class UserModel: BaseModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; private set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; private set; }
        /// <summary>
        /// 密码 MD5加密
        /// </summary>
        public string UserPwd { get; private set; } 
        /// <summary>
        /// 手机
        /// </summary>
        public string MPhone { get; private set; } 
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; private set; } 
       
        public Nullable<int> DepartId { get; private set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnLine { get; set; } = false;
        /// <summary>
        /// 所属部门
        /// </summary>
        public virtual DepartModel Depart { get; private set; }

        public virtual ICollection<UserRoleModel> UserRole { get; private set; } = new List<UserRoleModel>();
    }
}
