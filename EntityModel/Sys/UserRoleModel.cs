﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public class UserRoleModel:BaseModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual UserModel User { get; set; }
        public virtual RoleModel Role { get; set; }
    }
}
