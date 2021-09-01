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
            string str = string.Empty;
            //CardsMEF pro = new CardsMEF();
            //BaseComposeMEF baseCompose = new BaseComposeMEF();
            //baseCompose.Compose();
            //if (baseCompose.t != null)
            //{
            //    foreach (var c in pro.cards)
            //    {
            //        str += c.GetCountInfo();
            //    }
            //}
          //  str = CardsMEF.GetData();
            return str;
           // return  CardsMEF.GetData();
        }
 



        

    }


   
}
