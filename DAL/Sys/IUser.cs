using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  interface IUser : IBase
    {
        dynamic Login(string userId, string userPwd);
    }
}
