using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
     public partial class ModuleModel:BaseModel
    {
        public ModuleModel() : base() { }

        public ModuleModel(string name,bool isUsed, string idx, string icon, E_ModuleType moduleType, int? parentId, bool routeCache, string routeComponent, string routeName, string routePath, 
            string targetType, string url, string crtUser, string remark) :base( crtUser,remark)
        { 
            this.Name = name;
            this.IsUsed = isUsed;
            this.Idx = idx;
            this.Icon = icon;
            this.ModuleType = moduleType;
            this.ParentId = parentId;
            this.RouteCache = routeCache;
            this.RouteComponent = routeComponent;
            this.RouteName = routeName;
            this.RoutePath = routePath;
            this.TargetType = targetType;
            this.Url = url; 
        }




    }
}
