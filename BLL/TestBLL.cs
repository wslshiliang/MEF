using DAL;
using DB;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [System.ComponentModel.Composition.Export(typeof(ITest))]
    public class TestBLL : BaseDal, ITest
    {
        public DemoModel GetData(int id)
        { 
            //var res = context.Database.SqlQuery<DemoModel>("select * from W_DemoClass;").FirstOrDefault();
            var res = Context.DemoClasses.FirstOrDefault(c => c.Id == id);
            return res;
        }
    }
}
