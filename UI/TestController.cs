using DAL;
using EntityModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WYQ.MEF;

namespace WYQ.UI
{ 
    /// <summary>
    /// example
    /// </summary>
    public class TestController : System.Web.Http.ApiController
    {
        

        public string Get() 
        {
            return "WepApi connect success"; 
        }

        public string Get(int id)
        {
            DemoModel demoClass = new DemoModel();
            MEF<ITest> baseCompose = new MEF<ITest>();
            baseCompose.Compose();
            if (baseCompose.call != null)
            {
                demoClass = baseCompose.call.GetData(id);
            }

           // var res= TestMEF.GetData(id);
            return JsonConvert.SerializeObject(demoClass);
        }
 


        public string Post(int id)
        {
            return id.ToString();
        }

        #region post[frombody]接收的参数只能是一个
        //public string Post([FromBody] TestModel test)
        //{
        //    return test.id;
        //} 
        //public string Post([FromBody] JObject test)
        //{
        //    TestModel t = (TestModel)test.ToObject(typeof(TestModel));
        //    return t.id;
        //}

         /// <summary>
        /// 最优写法
        /// </summary> 
        public string Post([FromBody] dynamic test)
        {
            return test.id;
        }
        #endregion

       
    }

    public class TestModel
    {
        public string id;
    }
}
