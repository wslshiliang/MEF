using DAL;
using Newtonsoft.Json;
using System.Web.Http;
using Utility;
using WYQ.MEF;

namespace WYQ.UI
{
    public class UserController : System.Web.Http.ApiController
    {
         [Route("api/User/Login")]
        [HttpPost]
        public dynamic Login([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string userId = args.userId;
            string userPwd = args.password;
            string token = args.token;

            var userInfo = TokenHelper.GetUserInfo(token, "");
            if (userInfo.userId != "")
            {
                return Ret<dynamic>.Success(new { userInfo.userId, userInfo.userName, args.token });
            }

            MEF<IUser> mef = new MEF<IUser>();
            mef.Compose();
            if (mef.call!= null)
            {
                result = mef.call.Login(userId, userPwd);
            }
            return  result;
        }

        [Route("api/User/QueryUserListByDepartIdEx")]
        [HttpPost]
        public dynamic QueryUserListByDepartIdEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic); 

            MEF<IUser> mef = new MEF<IUser>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.QueryUserListByDepartIdEx(args);
            }
            return result;
        }
 

     }
}
