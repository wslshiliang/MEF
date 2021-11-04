using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Sys
{
   public interface IRole : IBase
    {
        /// <summary>
        /// 查询
        /// </summary>
        dynamic QueryAllRoleEx(dynamic args);
        /// <summary>
        /// 角色详情
        /// </summary>
        dynamic QueryRoleByIdEx(dynamic args);
        /// <summary>
        /// 角色编辑
        /// </summary>
        dynamic UpdateRoleEx(dynamic args);
        /// <summary>
        /// 角色创建
        /// </summary>
        dynamic AddRoleEx(dynamic args);
        /// <summary>
        /// 角色删除
        /// </summary>
        dynamic DeleteRoleEx(dynamic args);
    }
}
