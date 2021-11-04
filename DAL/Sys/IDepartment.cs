using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  interface IDepartment : IBase
    {
        /// <summary>
        /// 查询
        /// </summary> 
        dynamic QueryAllDepart(string name, string isUsed,int page, int pagesize);

        /// <summary>
        /// 新增
        /// </summary> 
        dynamic AddDepartEx(string uName, dynamic args);

        /// <summary>
        /// 修改查询
        /// </summary> 
        dynamic QueryDepartByIdEx(int id);

        /// <summary>
        /// 修改确认
        /// </summary> 

        dynamic UpdateDepartEx(string uName, dynamic args);

        /// <summary>
        /// 删除
        /// </summary> 

        dynamic DeleteDepartEx(int id, string uName);
    }
}
