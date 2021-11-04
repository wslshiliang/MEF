using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Sys
{
   public interface IModule : IBase
    {
        /// <summary>
        /// 查询
        /// </summary> 
        dynamic QueryAllModuleEx(string name, string isUsed, int page, int pagesize);
        /// <summary>
        /// 新增
        /// </summary> 
        dynamic AddModuleEx(string uName, dynamic args);
        /// <summary>
        /// 根据用户获取菜单权限
        /// </summary> 
        dynamic QueryPageModuleByUserIdEx( string userId);
        /// <summary>
        ///获取所有菜单的层级关系
        /// </summary> 
        dynamic QueryAllModuleTreeEx();

    }
}
