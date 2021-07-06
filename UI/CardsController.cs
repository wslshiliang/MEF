using DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
    public class CardsController : System.Web.Http.ApiController
    {
        public string Get()
        {
          return  CardsMEF.GetData();
        }
 



        

    }


   
}
