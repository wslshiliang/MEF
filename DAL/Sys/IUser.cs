using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  interface IUser : IBase
    {
        /// <summary>
        /// 登陆
        /// </summary>
        dynamic Login(string userId, string userPwd);

        /// <summary>
        /// 查询
        /// </summary>
        dynamic QueryUserListByDepartIdEx(dynamic args);
    }
}
