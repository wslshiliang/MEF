using DAL.Sys;
using System.Web.Http;
using WYQ.MEF;

namespace WYQ.UI.Sys
{
    public class DictionaryController : System.Web.Http.ApiController
    {
        [Route("api/Dictionary/GetDictEx")]
        [HttpPost]
        public dynamic GetDictEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string secType = args.secType; 

            MEF<IDictionary> mef = new MEF<IDictionary>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.GetDictEx(secType);
            }
            return result;
        }
 
        [Route("api/Dictionary/GetDictionaryAllEx")]
        [HttpPost]
        public dynamic GetDictionaryAllEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            

            MEF<IDictionary> mef = new MEF<IDictionary>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.GetDictionaryAllEx();
            }
            return result;
        }

    }
}
