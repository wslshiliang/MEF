using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
  public  class ModuleModel:BaseModel
    {
        public int? ParentId { get; set; }
        public string Icon { get; set; }
        /// <summary>
        /// iframe页面或内嵌页面
        /// </summary>
        public string TargetType { get; set; }
        /// <summary>
        /// 菜单链接
        /// </summary>
        public string Url { get; set; } 
        /// <summary>
        /// 路由组件
        /// </summary>
        public string RouteComponent { get; set; }
        /// <summary>
        /// 路由地址
        /// </summary>
        public string RoutePath { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单类型
        /// </summary>
        public E_ModuleType ModuleType { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public string Idx { get; set; }

        /// <summary>
        /// 父级模块
        /// </summary>
        public virtual ModuleModel Parent { get; private set; }
        public virtual ICollection<ModuleModel> Childs { get; private set; } = new List<ModuleModel>();

        public virtual ICollection<RoleModuleModel> ModuleRole { get; private set; } = new List<RoleModuleModel>();
    }
}
