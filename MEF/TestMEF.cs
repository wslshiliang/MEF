using DAL;
using EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYQ.MEF
{
    public class TestMEF : BaseMEF<ITest>
    { 

        public static DemoModel GetData(int id)
        {
            DemoModel demoClass = new DemoModel();

            TestMEF pro = new TestMEF();
            pro.Compose();
            if (pro.test != null)
            {
                demoClass = pro.test.GetData(id);
            }
            return demoClass;
        }
    }
}
