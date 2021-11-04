using DAL.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WYQ.MEF;

namespace WYQ.UI.Sys
{
    public class ModuleController : System.Web.Http.ApiController
    {
        [Route("api/Module/QueryAllModuleEx")]
        [HttpPost]
        public dynamic QueryAllModuleEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string name = args.model.Name;
            string isUsed = args.model.IsUsed;
            int page = args.page.Page;
            int pagesize = args.page.Pagesize;

            MEF<IModule> mef = new MEF<IModule>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.QueryAllModuleEx(name, isUsed, page, pagesize);
            }
            return result;
        }

        [Route("api/Module/AddModuleEx")]
        [HttpPost]
        public dynamic AddModuleEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string uName = args.uName;

            MEF<IModule> mef = new MEF<IModule>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.AddModuleEx(uName, args);
            }
            return result;
        }

        [Route("api/Module/QueryPageModuleByUserIdEx")]
        [HttpPost]
        public dynamic QueryPageModuleByUserIdEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string userId = args.userId;

            MEF<IModule> mef = new MEF<IModule>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.QueryPageModuleByUserIdEx( userId);
            }
            return result;
        }

        [Route("api/Module/QueryAllModuleTreeEx")]
        [HttpPost]
        public dynamic QueryAllModuleTreeEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string userId = args.userId;

            MEF<IModule> mef = new MEF<IModule>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.QueryAllModuleTreeEx();
            }
            return result;
        }

    } 
}
