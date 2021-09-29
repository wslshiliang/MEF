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

        [Route("api/Dictionary/AddDictionaryEx")]
        [HttpPost]
        public dynamic AddDictionaryEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string uName = args.uName;

            MEF<IDictionary> mef = new MEF<IDictionary>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.AddDictionaryEx(uName,args);
            }
            return result;
        }

        [Route("api/Dictionary/GetDictionaryByIdEx")]
        [HttpPost]
        public dynamic GetDictionaryByIdEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string id = args.Id;

            MEF<IDictionary> mef = new MEF<IDictionary>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.GetDictionaryByIdEx(id);
            }
            return result;
        }

        [Route("api/Dictionary/ChangeDictionaryEx")]
        [HttpPost]
        public dynamic ChangeDictionaryEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string uName = args.uName;

            MEF<IDictionary> mef = new MEF<IDictionary>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.ChangeDictionaryEx(uName, args);
            }
            return result;
        }

        [Route("api/Dictionary/DeleteDictionaryEx")]
        [HttpPost]
        public dynamic DeleteDictionaryEx([FromBody] dynamic args)
        {
            dynamic result = default(dynamic);
            string uName = args.uName;
            string id = args.Id;

            MEF<IDictionary> mef = new MEF<IDictionary>();
            mef.Compose();
            if (mef.call != null)
            {
                result = mef.call.DeleteDictionaryEx(uName, id);
            }
            return result;
        }

    }
}
