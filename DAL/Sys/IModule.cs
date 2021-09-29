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

    }
}
