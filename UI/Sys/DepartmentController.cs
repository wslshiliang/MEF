using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WYQ.MEF;

namespace WYQ.UI.Sys
{
   public class DepartmentController : System.Web.Http.ApiController
    {
        [Route("api/Department/QueryAllDepartEx")]
        [HttpPost]
        public dynamic QueryAllDepartEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string name = args.model?.Name;
            string isUsed = args.model?.IsUsed;
            int page = args.page==null ? 0: args.page.Page;
            int pagesize = args.page == null ? 0 : args.page.Pagesize;

            MEF<IDepartment> mef = new MEF<IDepartment>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.QueryAllDepart(name, isUsed, page, pagesize);
            }
            return result;
        }

        [Route("api/Department/AddDepartEx")]
        [HttpPost]
        public dynamic AddDepartEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string uName = args.uName;

            MEF<IDepartment> mef = new MEF<IDepartment>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.AddDepartEx(uName,args);
            }
            return result;
        }

        [Route("api/Department/QueryDepartByIdEx")]
        [HttpPost]
        public dynamic QueryDepartByIdEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            int id = args.Id;

            MEF<IDepartment> mef = new MEF<IDepartment>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.QueryDepartByIdEx(id);
            }
            return result;
        }

        [Route("api/Department/UpdateDepartEx")]
        [HttpPost]
        public dynamic UpdateDepartEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string uName = args.uName;

            MEF<IDepartment> mef = new MEF<IDepartment>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.UpdateDepartEx(uName,args);
            }
            return result;
        }


        [Route("api/Department/DeleteDepartEx")]
        [HttpPost]
        public dynamic DeleteDepartEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic); 
            int id = args.Id;
            string uName = args.uName;

            MEF<IDepartment> mef = new MEF<IDepartment>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.DeleteDepartEx(id, uName);
            }
            return result;
        }

    }



}
