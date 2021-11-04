using DAL.Sys;
using System.Web.Http;
using WYQ.MEF;

namespace WYQ.UI.Sys
{
    public class RoleController : System.Web.Http.ApiController
    {
        [Route("api/Role/QueryAllRoleEx")]
        [HttpPost]
        public dynamic QueryAllRoleEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);

            MEF<IRole> mef = new MEF<IRole>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.QueryAllRoleEx(args);
            }
            return result;
        }

        [Route("api/Role/QueryRoleByIdEx")]
        [HttpPost]
        public dynamic QueryRoleByIdEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);

            MEF<IRole> mef = new MEF<IRole>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.QueryRoleByIdEx(args);
            }
            return result;
        }

        [Route("api/Role/UpdateRoleEx")]
        [HttpPost]
        public dynamic UpdateRoleEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);

            MEF<IRole> mef = new MEF<IRole>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.UpdateRoleEx(args);
            }
            return result;
        }

        [Route("api/Role/AddRoleEx")]
        [HttpPost]
        public dynamic AddRoleEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);

            MEF<IRole> mef = new MEF<IRole>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.AddRoleEx(args);
            }
            return result;
        }

        [Route("api/Role/DeleteRoleEx")]
        [HttpPost]
        public dynamic DeleteRoleEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);

            MEF<IRole> mef = new MEF<IRole>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.DeleteRoleEx(args);
            }
            return result;
        }

    }
}
